using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.IoT.Exercises.HR
{
    public interface IHRreceiver
    {
        int BeatPerMinute { get; }
        DateTime? LastUpdatedTime { get; }
        byte[] LastData { get; }
        void Start();
        void Stop();
    }
}
