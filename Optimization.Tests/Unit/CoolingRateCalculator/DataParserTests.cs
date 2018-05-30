using Optimalization.CoolingRateCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optimization.Tests.Unit
{
    public class DataParserTests
    {
        DataParser parser = new DataParser();


        String csv = "0,20\n1,10";
        String expectedOutput = "1\n1 10\n";

        [Fact]
        public void shouldParseDataProperply()
        {
            parser.SilentMode = true;
            String output = parser.createDataForTransE(csv);
            Assert.NotNull(output);
            Assert.Equal(expectedOutput, output);
        }

    }
}
