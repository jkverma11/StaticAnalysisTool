using System;
using System.Configuration;
using System.Collections.Specialized;

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

            IStaticAnalyzer nDepend =new NDependAnalyzer();
            nDepend.ProcessInput(solutionPath);
            nDepend.ProcessOutput();

        }
    }
}
