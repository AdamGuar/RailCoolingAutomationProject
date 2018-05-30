using Optimalization.CoolingRateCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optimization.Tests.Unit
{
    public class SpliterTest
    {


        String csv = "0,20\n1,10";

        [Fact]
        public void shouldReturnProperValueList()
        {
            List<Value> expectedList = new List<Value>();
            expectedList.Add(new Value(0, 20));
            expectedList.Add(new Value(1, 10));

            List<Value> splited = new List<Value>();
            Spliter.pupulateValuesList(splited, csv);

            Assert.Equal(expectedList.Count, splited.Count);

            Assert.Equal(expectedList[0].ValueTemp, splited[0].ValueTemp);
            Assert.Equal(expectedList[0].ValueTime, splited[0].ValueTime);
            Assert.Equal(expectedList[1].ValueTemp, splited[1].ValueTemp);
            Assert.Equal(expectedList[1].ValueTime, splited[1].ValueTime);

        }

    }
}
