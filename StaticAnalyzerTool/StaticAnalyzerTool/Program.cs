using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace StaticAnalyzerTool
{
    class Program
    {
        static void Main(string[] args)
        {

            string processPath = ConfigurationManager.AppSettings.Get("ProcessPath");
            string solutionPath = ConfigurationManager.AppSettings.Get("SolutionPath");

            IStaticAnalyzer fxcop = new FxCopAnalyzer();
            fxcop.ProcessInput(processPath);
            fxcop.ProcessOutput();

            IStaticAnalyzer nDepend = new NDependAnalyzer();
            nDepend.ProcessInput(solutionPath);
            nDepend.ProcessOutput();
            Process proc = new Process() {EnableRaisingEvents = false};
            proc.StartInfo.FileName = "FinalOutput.txt";
            proc.Start();
            
            

        }
    }
}
