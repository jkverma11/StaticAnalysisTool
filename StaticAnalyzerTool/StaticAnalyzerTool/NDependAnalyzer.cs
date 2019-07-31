using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalyzerTool
{
    class NDependAnalyzer : IStaticAnalyzer
    {
        readonly string _nDependXml = Directory.GetCurrentDirectory() + @"\..\..\..\..\common.ndproj";

        readonly string _ndependOut = Directory.GetCurrentDirectory() + @"\..\..\..\..\XmlOutputs\NDependOutput";

        readonly string NDependExe = @"..\..\..\..\NDepend_2019.2.6.9270\NDepend.Console.exe";

        public void ProcessInput( string projFilePath)
        {
            XmlWriter.EditSolutionName(_nDependXml, projFilePath, "IDEFile", "FilePath");
        }

        public void ProcessOutput()
        {
            string arguments = _nDependXml + @" /LogTrendMetrics /OutDir " + _ndependOut;
            try
            {
                Process.Start(NDependExe, arguments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
