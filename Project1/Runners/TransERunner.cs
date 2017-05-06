using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.Runners
{
    class TransERunner
    {
       public static void Run(string transEFilePath)
        {
            Logger.Logger.logLine("Starting TRANS_E", true);
            Process firstProc = new Process();
            firstProc.StartInfo.FileName = transEFilePath+"trans_e.exe";
            firstProc.StartInfo.WorkingDirectory = transEFilePath;

            firstProc.Start();

            firstProc.WaitForExit();
            Logger.Logger.logLine("TRANS_E Exited", true);
        }
    }
}
