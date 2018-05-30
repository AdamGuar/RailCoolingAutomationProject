using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.CoolingRateCalculator
{
    public class DataParser
    {

        bool _SilentMode = false;

        public bool SilentMode{
            set { _SilentMode = value; }
        }

        public string createDataForTransE(string CSV)
        {
            if(!_SilentMode) Logger.Logger.logLine("Creating data for Trans E from csv", true);
            List<Value> valuesList = new List<Value>();
            Spliter.pupulateValuesList(valuesList, CSV);
            List<OutPutTypeField> intervals = CoolingRateCalculator.CalculateRates(valuesList);

            string output="";
            output = intervals.Count.ToString() + "\n";
            foreach (OutPutTypeField interval in intervals)
            {

                output = output + interval.IntervalProperty + " " + interval.CoolingRateProperty + "\n";
            }
            if (!_SilentMode) Logger.Logger.logLine("Creating data for Trans E from csv is DONE", true);
            return output;
        }

    }
}
