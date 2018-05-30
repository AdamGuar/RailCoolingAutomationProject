using Optimalization.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optimization.Tests.Unit
{
    public class ConfigLoaderTest
    {

        ConfigLoader loader = new ConfigLoader();

        static String CONFIG_PATH_VALID = "config.txt";
        static String CONFIG_PATH_INVALID = "NONEXISTING.txt";


        [Fact]
        public void ShouldReturnValidConfig()
        {
            Config conf = loader.loadConfiguration(CONFIG_PATH_VALID);
            Assert.NotNull(conf);
            Assert.NotNull(conf.AbaqusDirectory);
            Assert.NotNull(conf.LogsDirectory);
            Assert.NotNull(conf.TransEDirectory);
        }


        [Fact]
        public void ShouldReturnThrowException()
        {
            bool isExThrown = false;
            try { 
                Config conf = loader.loadConfiguration(CONFIG_PATH_INVALID);
            }catch(SystemException e)
            {
                isExThrown = true;
                Assert.Equal("Configuration file cant be readed", e.Message);
            }
            Assert.True(isExThrown);
        }

    }
}
