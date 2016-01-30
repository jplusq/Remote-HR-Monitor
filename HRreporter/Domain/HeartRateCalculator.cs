using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.IoT.Exercises.HR
{
    public class HeartRateCalculator
    {
        public int HeartRate { get; private set; }
        public void Update(int rate)
        {
            HeartRate = rate;
        }
    }
}
