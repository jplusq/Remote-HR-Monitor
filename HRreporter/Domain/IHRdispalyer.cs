using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.IoT.Exercises.HR
{
    public interface IHRdispalyer
    {
        void Update(int bpm, byte[] data);
        void BeginReport();
        void EndReport();
    }
}
