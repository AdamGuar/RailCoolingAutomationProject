using Optimalization.Tests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optimization.Tests
{
    public class IntegrationXUnit
    {

        [Fact]
        public void RunIntegrationTestsShouldReturnVoidAndNotThrowAnything()
        {
            Tester.testExcecutionChain();
        }
    }
}
