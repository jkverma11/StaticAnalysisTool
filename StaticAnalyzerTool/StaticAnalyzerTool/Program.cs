using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace StaticAnalyzerTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string processPath = XmlParse("Process", "ExePath");
            string solutionPath = XmlParse("Process", "SolutionPath");

            IStaticAnalyzer fxcop = new FxCopAnalyzer();
            fxcop.ProcessInput(processPath);
            fxcop.ProcessOutput();

            IStaticAnalyzer nDepend = new NDependAnalyzer();
            nDepend.ProcessInput(solutionPath);
            nDepend.ProcessOutput();
        }
        public static string XmlParse(string tag, string name)
        {
            string returnString = String.Empty;
            var xmlDoc = XElement.Load(@"..\..\..\..\InputExePaths.xml");
            var paths = from element in xmlDoc.Descendants()
                where element.Name == tag
                select element;

            foreach (var msg in paths)
            {
                if (msg.Attribute("Name").Value == name)
                    returnString = msg.Attribute("Path").Value;
            }


            return returnString;
        }

    }
}
