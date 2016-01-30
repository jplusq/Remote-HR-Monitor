using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q.IoT.Exercises.HR.UI
{
    public partial class HRreportForm : Form, IHRdispalyer
    {
        private HRreporter _reporter;
        public HRreportForm(IHRreceiver reciver)
        {
            InitializeComponent();
            _reporter = new HRreporter(reciver, this);
        }

        public void Update(int bpm, byte[] data)
        {
            this.BeginInvoke(new Action(()=> {
                lblRate.Text = bpm.ToString();
                StringBuilder sb = new StringBuilder();
                foreach(byte b in data)
                {
                    sb.Append(string.Format("[{0:x2}]", b));
                }
                txtData.Text = sb.ToString().ToUpper() + "\r\n" + txtData.Text;
            }));
        }

        public void BeginReport() {
            this.BeginInvoke(new Action(() =>
            {
                lblReport.Text = "Reporting to AWS...";
            }));
        }
        public void EndReport()
        {
            this.BeginInvoke(new Action(() =>
            {
                lblReport.Text = string.Format("Last report at {0}", DateTime.Now.ToString("HH:mm:ss"));
            }));
        }

        private void rdoSimulator_CheckedChanged(object sender, EventArgs e)
        {
            barRange_Scroll(this, EventArgs.Empty);
            barRange.Enabled = true;
            _reporter.ChangeMode(true);
        }

        private void rdoMonitor_CheckedChanged(object sender, EventArgs e)
        {
            lblRate.Text = "---";
            barRange.Enabled = false;
            _reporter.ChangeMode(false);
        }

        private void barRange_Scroll(object sender, EventArgs e)
        {
            _reporter.SetSimulation(barRange.Value);
        }
    }
}
