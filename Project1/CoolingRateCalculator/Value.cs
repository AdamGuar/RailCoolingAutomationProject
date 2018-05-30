using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.CoolingRateCalculator
{
    public class Value
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

        public Value()
        {

        }

        public Value(double time, double temp)
        {
            Time = time;
            Temp = temp;
        }


    }
}
