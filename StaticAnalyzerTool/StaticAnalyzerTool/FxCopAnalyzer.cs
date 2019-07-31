using System;
using System.Diagnostics;
using System.IO;


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
                Process.Start(FxCopExe, arguments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
