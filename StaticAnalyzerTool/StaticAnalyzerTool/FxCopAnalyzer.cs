using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace StaticAnalyzerTool
{
    class FxCopAnalyzer : IStaticAnalyzer
    {
        readonly string _fxCopOutput= Directory.GetCurrentDirectory() + @"\..\..\..\..\XmlOutputs\FxCopReport.xml";

        readonly string _fxCopXml = Directory.GetCurrentDirectory() + @"\..\..\..\..\common_fx_cop_file.FxCop";

        readonly string FxCopExe = @"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe";

        public void ProcessInput(string projFilePath)
        {
            XmlWriter.EditSolutionName(_fxCopXml,projFilePath,"Target","Name");
        }

        public void ProcessOutput()
        {
            string arguments = @"/p:" + _fxCopXml + @" /out:" + _fxCopOutput;
            try
            {
                Process proc = new Process();
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.FileName = FxCopExe;
                proc.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(5000);
            FxCopReport.GenerateFxCopReport(_fxCopOutput);
        }
    }
}
