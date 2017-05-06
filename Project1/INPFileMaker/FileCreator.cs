using Optimalization.Configuration;
using Optimalization.FileUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.INPFileMaker
{
    class FileCreator
    {

        string AmplitudeString;
        public string AmplitudeProp {
            get { return AmplitudeString; }
            set { AmplitudeString = value; }
        }


        public void CreateINPFile(string filename)
        {
            Logger.Logger.logLine("Creating INP File named: " +filename, true);
            string header = GeneralUtils.readFile(ConfigurationStorage.CONFIGURATION.AbaqusDirectory+ "inp.header");
            string footer = GeneralUtils.readFile(ConfigurationStorage.CONFIGURATION.AbaqusDirectory + "inp.footer");


            string output = header + "\n" + this.AmplitudeString + "\n" + footer;
            System.IO.File.WriteAllText(ConfigurationStorage.CONFIGURATION.AbaqusDirectory + filename, output);
            Logger.Logger.logLine("Creating INP File named: " + filename + " SUCCEDED!", true);
        }
    }
}
