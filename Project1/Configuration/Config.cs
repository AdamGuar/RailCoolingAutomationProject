using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.Configuration
{
    class Config
    {

        private string transEDirectory;
        private string abaqusDirectory;
        private string logsDirectory;
    

        public string TransEDirectory
        {
            get {return transEDirectory; }
            set {transEDirectory = value; }
        }


        public string AbaqusDirectory
        {
            get { return abaqusDirectory; }
            set { abaqusDirectory = value; }
        }

        public string LogsDirectory
        {
            get { return logsDirectory; }
            set { logsDirectory = value; }
        }


        public Config(string AbaqusDirectory, string TransEDirectory, string LogsDirectory)
        {
            logsDirectory = LogsDirectory;
            abaqusDirectory = AbaqusDirectory;
            transEDirectory = TransEDirectory;
        }

    }
}
