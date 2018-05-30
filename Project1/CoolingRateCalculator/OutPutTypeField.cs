using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.CoolingRateCalculator
{
    public class OutPutTypeField
    {
        string Interval;
        string CoolingRate;

        public string IntervalProperty
        {
            get { return Interval; }
            set { Interval = value; }
        }

        public string CoolingRateProperty
        {
            get { return CoolingRate; }
            set { CoolingRate = value; }
        }
    }
}
