using Optimalization.Configuration;
using Optimalization.FileUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization
{
    class AbaqusProgramRunner
    {
        public static void RunAbaqus(string inpFileName,string jobName)
        {

            Logger.Logger.logLine("Starting Abaqus with inp file:" + inpFileName+" and jobName: "+jobName, true);

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = ConfigurationStorage.CONFIGURATION.AbaqusDirectory;
            process.StartInfo.Arguments = "/C abaqus job="+jobName+" inp="+inpFileName+" interactive";
            process.Start();

            process.WaitForExit();

            Logger.Logger.logLine("Starting Abaqus with inp file:" + inpFileName + " and jobName: " + jobName + " DONE", true);

        }
    }
}
