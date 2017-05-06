using System;
using System.Collections.Generic;
using System.Globalization;

namespace Optimalization.CoolingRateCalculator
{
    internal class Spliter
    {
        internal static void pupulateValuesList(List<Value> valuesList, string CSV)
        {

            string[] lines = CSV.Split(new[] { '\r', '\n' });
            foreach (string line in lines)
            {
                string[] val = line.Split(new[] { ',' });
                if (val[0] != "" && val[1] != "") { 
                    double time = Double.Parse(val[0], CultureInfo.InvariantCulture);
                    double temp = Double.Parse(val[1], CultureInfo.InvariantCulture);
                    Value temporary = new Value();
                    temporary.ValueTemp = temp;
                    temporary.ValueTime = time;
                    valuesList.Add(temporary);
                }
            }

          
        }
    }
}