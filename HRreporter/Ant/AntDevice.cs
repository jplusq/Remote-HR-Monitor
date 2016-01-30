using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANT_Managed_Library;

namespace Q.IoT.Exercises.ANT
{
    public enum AntChannels
    {
        Channel0 = 0
    }

    public enum ChannelType : byte
    {
        BidirectionalSlaveChannel = 0x10,
        BidirectionalMasterChannel = 0x20,
        SharedBidirectionalSlaveChannel = 0x30,
        SharedBidirectionalMasterChannel = 0x40
    }

    public class AntDevice
    {
        public static byte[] AntNetworkKey = { 0xB9, 0xA5, 0x21, 0xFB, 0xBD, 0x72, 0xC3, 0x45 };

        public ChannelType ChannelType { get; set; }
        public ushort DeviceNumber { get; set; }
        public byte DeviceType { get; set; }
        public byte TransmissionType { get; set; }
        public byte RFChannelNumber { get; set; }
        public ushort MessagePeriod { get; set; }
        public byte NetworkNumber { get; set; }

        public ANT_Device.dDeviceResponseHandler DeviceResponse { get; set; }
        public dChannelResponseHandler ChannelResponse { get; set; }

        private ANT_Device _antDevice = null;
        private ANT_Channel _channel = null;
        public AntDevice(ANT_Device device, AntChannels channel = AntChannels.Channel0, byte networkNum = 0)
        {
            _antDevice = device;
            _channel = _antDevice.getChannel((int)channel);
            NetworkNumber = networkNum;
        }

        public void Init()
        {
            if (_antDevice == null || _channel == null)
            {
                throw new Exception("unassigined device or channel");
            }

            _antDevice.enableRxExtendedMessages(true);

            // Add device response function to receive protocol event 
            if (DeviceResponse != null)
            {
                _antDevice.deviceResponse += new ANT_Device.dDeviceResponseHandler(DeviceResponse);
            }

            // Add channel response function to receive channel event messages
            if (ChannelResponse != null)
            {
                _channel.channelResponse += new dChannelResponseHandler(ChannelResponse);
            }

            ANT_ReferenceLibrary.ChannelType channelType = ANT_ReferenceLibrary.ChannelType.BASE_Slave_Receive_0x00;
            switch (ChannelType)
            {
                case ChannelType.BidirectionalSlaveChannel:
                    channelType = ANT_ReferenceLibrary.ChannelType.BASE_Slave_Receive_0x00;
                    break;
                case ChannelType.BidirectionalMasterChannel:
                    channelType = ANT_ReferenceLibrary.ChannelType.BASE_Master_Transmit_0x10;
                    break;
                default:
                    throw new Exception("unhandled channel type");
            }

            if (!_channel.assignChannel(channelType, NetworkNumber, 500))
            {
                throw new Exception("Error assigning channel");
            }
            if (!_channel.setChannelID(DeviceNumber, false, DeviceType, TransmissionType, 500))
            {
                // Not using pairing bit
                throw new Exception("Error configuring Channel ID");
            }

            if (!_channel.setChannelFreq(RFChannelNumber, 500))
            {
                throw new Exception("Error configuring Radio Frequency");
            }
            if (!_channel.setChannelPeriod(MessagePeriod, 500))
            {
                throw new Exception("Error configuring Channel Period");
            }
        }

        public bool Open()
        {
            if (_channel == null)
            {
                return false;
            }
            return _channel.openChannel(500);
        }

        public bool Close()
        {
            if (_channel == null)
            {
                return false;
            }
            return _channel.closeChannel(500);
        }

        ~AntDevice()
        {
            if (_channel != null)
            {
                _channel.closeChannel(500);
                _channel.unassignChannel(500);
            }
        }
    }
}
