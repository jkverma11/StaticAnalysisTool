using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StaticAnalyzerTool
{
    class NDependAnalyzer : IStaticAnalyzer
    {
        readonly string _nDependXml = Directory.GetCurrentDirectory() + @"\..\..\..\..\common.ndproj";

        readonly string _ndependOut = Directory.GetCurrentDirectory() + @"\..\..\..\..\XmlOutputs\NDependOutput";

        readonly string _nDependExe = Program.XmlParse("Tool", "NDepend");

        public void ProcessInput( string projFilePath)
        {
            XmlWriter.EditSolutionName(_nDependXml, projFilePath, "IDEFile", "FilePath");
        }

        public void ProcessOutput()
        {
            string arguments = _nDependXml + @" /LogTrendMetrics /OutDir " + _ndependOut;
            try
            {
                Process proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.FileName = _nDependExe;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string ndependOutputXml = _ndependOut + @"\TrendMetrics\NDependTrendData2019.xml";
            NDependXmlReport.GenerateNDependReport(ndependOutputXml);
        }
    }
}
