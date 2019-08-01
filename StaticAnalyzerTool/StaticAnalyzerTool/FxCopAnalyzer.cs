using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace StaticAnalyzerTool
{
    class FxCopAnalyzer : IStaticAnalyzer
    {
        readonly string _fxCopOutput= Directory.GetCurrentDirectory() + @"\..\..\..\..\XmlOutputs\FxCopReport.xml";

        readonly string _fxCopXml = Directory.GetCurrentDirectory() + @"\..\..\..\..\common_fx_cop_file.FxCop";

        readonly string _fxCopExe = Program.XmlParse("Tool", "FxCop");

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
                
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.FileName = _fxCopExe;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            FxCopReport.GenerateFxCopReport(_fxCopOutput);
        }
    }
}
