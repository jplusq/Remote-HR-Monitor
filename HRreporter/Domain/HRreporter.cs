using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Q.IoT.Exercises.HR
{
    public class HRreporter
    {
        private IHRreceiver _reciver;
        private IHRdispalyer _displayer;
        private Timer _receiveTimer;
        private bool _isReceiverTimerStarted = false;
        private Timer _reportTimer;
        private bool _isSimulator = false;
        private AwsUpdator _aws = new AwsUpdator();

        private HeartRateCalculator _calculator = new HeartRateCalculator();

        public HRreporter(IHRreceiver receiver, IHRdispalyer displayer)
        {
            _reciver = receiver;
            _displayer = displayer;
            _receiveTimer = new Timer(1000);
            _receiveTimer.Elapsed += Update;
            _receiveTimer.AutoReset = true;

            _reportTimer = new Timer(5000);
            _reportTimer.Elapsed += Report;
            _reportTimer.AutoReset = true;
            _reportTimer.Start();
        }
        private void Report(object sender, ElapsedEventArgs e)
        {
            if(!_isSimulator && !_isReceiverTimerStarted)
            {
                return;
            }

            //add aws code here
            _displayer.BeginReport();
            string state = _aws.Report(_calculator.HeartRate, "HRMonitor");
            _displayer.EndReport();
        }
        private void Update(object sender, ElapsedEventArgs e)
        {
            _calculator.Update(_reciver.BeatPerMinute);
            _displayer.Update(_calculator.HeartRate, _reciver?.LastData ?? new byte[] { });
        }
        public void ChangeMode(bool isSimulator)
        {
            _isSimulator = isSimulator;
            if (_isSimulator)
            {
                StopReceive();
            }
            else
            {
                StartReceive();
            }
        }

        public void SetSimulation(int rate)
        {
            _calculator.Update(rate);
            _displayer.Update(_calculator.HeartRate, _reciver?.LastData ?? new byte[] { });
        }

        private void StartReceive()
        {
            _receiveTimer.Start();
            _isReceiverTimerStarted = true;
            _reciver.Start();
        }

        private void StopReceive()
        {
            _receiveTimer.Stop();
            _isReceiverTimerStarted = false;
            _reciver.Stop();
        }
    }
}
