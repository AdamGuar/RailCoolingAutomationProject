using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimalization.FileUtils;
using Optimalization.Configuration;

namespace Optimalization.Logger
{
    class Logger
    {

        public static void logLine(string Line,bool AppendToFile)
        {
            Console.WriteLine(Line);
            if (AppendToFile) appendToFile(Line);
        }


        private  static void appendToFile(string Line)
        {
            File.AppendAllText(ConfigurationStorage.CONFIGURATION.LogsDirectory+ "logs.txt",
                   DateTime.Now.ToString()+": "+ Line + Environment.NewLine);
        }

    }
}
