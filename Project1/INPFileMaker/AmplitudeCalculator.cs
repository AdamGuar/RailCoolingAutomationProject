using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.INPFileMaker
{
    public class AmplitudeCalculator
    {
        //private static double INDICATOR_COOLER = 800;
        private static double INDICATOR_AIR = 10;

        public static string calculateAmplitude(double[] times, double INDICATOR_COOLER)
        {
            Logger.Logger.logLine("Calculating amplitude", true);
            string result = "0.,    "+INDICATOR_COOLER+".,\n";
            double totalCount = 0;
            totalCount = totalCount + times[0];
            result = result+totalCount+".,  " + INDICATOR_COOLER + ".,\n";


            for (int i = 1; i < times.Length; i++)
            {
                totalCount = totalCount + 3;
                if(i % 2 != 0)
                {
                    result = result + totalCount + ".,  " + INDICATOR_AIR + ".,\n";
                    totalCount = totalCount + times[i];
                    result = result + totalCount + ".,  " + INDICATOR_AIR + ".\n";

                }
                else
                {
                    result = result + totalCount + ".,  " + INDICATOR_COOLER + ".,\n";
                    totalCount = totalCount + times[i];
                    result = result + totalCount + ".,  " + INDICATOR_COOLER + ".,\n";
                }
                

            }
            Logger.Logger.logLine("End of amplitude calculation", true);
            return result;
        }
    }
}
