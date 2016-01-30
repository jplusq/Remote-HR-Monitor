using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.IoT.Exercises.HR;
using ANT_Managed_Library;

namespace Q.IoT.Exercises.ANT
{
    public class AntHRreceiver:AntDevice, IHRreceiver
    {
        public int BeatPerMinute { get; private set; }
        public DateTime? LastUpdatedTime { get; set; }

        public int HardwareVersion { get; private set; }
        public int SoftwareVersion { get; private set; }
        public int ModelNumber { get; private set; }
        public byte[] LastData { get; private set; }

        public AntHRreceiver(ANT_Device device, AntChannels channel = AntChannels.Channel0, byte networkNum = 0)
            : base(device, channel, networkNum)
        {
            //
            ChannelType = ChannelType.BidirectionalSlaveChannel;
            DeviceNumber = 0;// 35032;
            DeviceType = 120;
            TransmissionType = 1;
            RFChannelNumber = 57;
            MessagePeriod = 8070;
            ChannelResponse = onChannelResponse;

            Init();
        }

        protected void onChannelResponse(ANT_Response response)
        {
            try
            {
                if (response.isExtended())                                  // Check if we are dealing with an extended message
                {
                    ANT_ChannelID chID = response.getDeviceIDfromExt();    // Channel ID of the device we just received a message from
                    DeviceNumber = (ushort)chID.deviceNumber;
                }
                Parse(response.getDataPayload());
            }
            catch
            {
            }
        }

        private void Parse(byte[] data)
        {
            if (data.Length != 8)
            {
                return;
            }

            BeatPerMinute = data[7];
            LastData = data;
            LastUpdatedTime = DateTime.Now;
            int pageNo = data[0] & 0x7F;

            switch (pageNo)
            {
                case 3:
                    HardwareVersion = data[1];
                    SoftwareVersion = data[2];
                    ModelNumber = data[3];
                    break;
            }

        }

        public void Start()
        {
            Open();
        }

        public void Stop()
        {
            Close();
        }
    }
}
