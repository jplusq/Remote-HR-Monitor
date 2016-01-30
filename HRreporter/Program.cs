using ANT_Managed_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q.IoT.Exercises.ANT;
namespace Q.IoT.Exercises.HR.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ANT_Device usbAntDevice = new ANT_Device();
            usbAntDevice.ResetSystem();             // Soft reset
            System.Threading.Thread.Sleep(500);    // Delay 500ms after a reset
            usbAntDevice.setNetworkKey(0, AntDevice.AntNetworkKey, 500);
            var receiver = new AntHRreceiver(usbAntDevice);
            Application.Run(new HRreportForm(receiver));
        }
    }
}
