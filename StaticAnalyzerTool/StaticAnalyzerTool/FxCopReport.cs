using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StaticAnalyzerTool
{
    class FxCopReport
    {
        public static void Main(string[] args)
        {
            string Fxcop_xml_out = "C:\\Users\\320050491\\Downloads\\FxCopOutput\\FxCopReport.xml";

            var xmlDoc = XElement.Load(Fxcop_xml_out);

            var slnPath = (from element in xmlDoc.DescendantsAndSelf()
                where element.Name == "Target"
                select element).FirstOrDefault();

            Console.WriteLine("the solution path is: " + slnPath.Attribute("Name").Value);
        }
    }
}
