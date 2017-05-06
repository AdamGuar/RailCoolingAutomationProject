using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.CoolingRateCalculator
{
    class Value
    {
        private double Time;
        private double Temp;

        public double ValueTime
        {
            get { return Time; }
            set { Time = value; }
        }

        public double ValueTemp
        {
            get { return Temp; }
            set { Temp = value; }
        }


    }
}
