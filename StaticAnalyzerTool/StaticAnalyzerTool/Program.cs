using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StaticAnalyzerTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trigger FxCop Analyzer From Command Line
            string ProcessName;
            string CommandLineArguments;

            ProcessName = @"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe";
            CommandLineArguments = @"/p:C:\FxCop\FxCopProjectFile.FxCop /out:C:\Users\320050491\Downloads\FxCopOutput\FxCopReport.xml";

            TriggerStaticAnalyzer(ProcessName, CommandLineArguments);

            //Trigger NDepend Analyzer From Command Line

            ProcessName = @"C:\Users\320050491\Downloads\NDepend_2019.2.6.9270\NDepend.Console.exe";
            CommandLineArguments = @"C:\sleepThread\sleepThread.ndproj /LogTrendMetrics /OutDir C:\Users\320050491\Downloads\NDependOutput";

            TriggerStaticAnalyzer(ProcessName, CommandLineArguments);
        }

        private static void TriggerStaticAnalyzer(string process_name, string cmd_arguments)
        {
            try
            {
                Process.Start(process_name, cmd_arguments);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
