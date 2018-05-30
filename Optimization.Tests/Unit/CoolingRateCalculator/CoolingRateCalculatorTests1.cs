using Optimalization.CoolingRateCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optimization.Tests.Unit
{
    public class CoolingRateCalculatorTests1
    {
        [Fact]
        public void shouldReturnValidRates()
        {

            List<Value> values = new List<Value>();

            values.Add(new Value(0,20));
            values.Add(new Value(1, 10));

            List<OutPutTypeField> rates = CoolingRateCalculator.CalculateRates(values);


            Assert.NotNull(rates);
            Assert.NotEmpty(rates);
            Assert.Equal("1",rates[0].IntervalProperty);
            Assert.Equal("10", rates[0].CoolingRateProperty);
        }

    }
}
