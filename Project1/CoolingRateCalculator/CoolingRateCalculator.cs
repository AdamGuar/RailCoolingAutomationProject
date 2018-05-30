using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.CoolingRateCalculator
{
    public class CoolingRateCalculator
    {
        public static List<OutPutTypeField> CalculateRates(List<Value> valuesList)
        {
            List<OutPutTypeField> intervals = new List<OutPutTypeField>();

            bool direction = true;

            Value firstOfInterval = valuesList[0];
   

            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                bool temporary_direction;
                if ((valuesList[i].ValueTemp - valuesList[i + 1].ValueTemp) > 0)
                    temporary_direction = true;
                else
                    temporary_direction = false;

                if (temporary_direction != direction)
                {

                    double coolingRateLocal = (firstOfInterval.ValueTemp - valuesList[i].ValueTemp)
                            / (valuesList[i].ValueTime - firstOfInterval.ValueTime);

                    double intervalLocal = valuesList[i].ValueTime - firstOfInterval.ValueTime;

                    // OutPutTypeField elementLocal = new OutPutTypeField(coolingRateLocal.ToString, intervalLocal.ToString);

                    OutPutTypeField elementLocal = new OutPutTypeField();
                    elementLocal.IntervalProperty = intervalLocal.ToString();
                    elementLocal.CoolingRateProperty = coolingRateLocal.ToString();
                    if(intervalLocal!=0&&coolingRateLocal!=0)
                        intervals.Add(elementLocal);

                    direction = temporary_direction;
                    firstOfInterval = valuesList[i + 1];

                }
            }

            double coolingRate = (firstOfInterval.ValueTemp - valuesList[valuesList.Count - 1].ValueTemp)
                    / (valuesList[valuesList.Count - 1].ValueTime - firstOfInterval.ValueTime);

            double interval = valuesList[valuesList.Count - 1].ValueTime - firstOfInterval.ValueTime;
            //OutputTypeField element = new OutputTypeField(String.valueOf(coolingRate), String.valueOf(interval));
            OutPutTypeField element = new OutPutTypeField();
            element.IntervalProperty = interval.ToString();
            element.CoolingRateProperty = coolingRate.ToString();
            if (element.CoolingRateProperty != "0" && element.IntervalProperty != "0") 
                intervals.Add(element);

            return intervals;
        }


      
    }
}
