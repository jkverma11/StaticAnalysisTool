using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticAnalyzerTool
{
    public static class XmlWriter
    {
     public static void EditSolutionName(string XmlPath, string SolutionPath, string ElementName,string AttributeName )
        {
            var xmlDoc = XElement.Load(XmlPath);

            var staticTools = (from element in xmlDoc.DescendantsAndSelf()
                where element.Name == ElementName
                select element).FirstOrDefault();
            staticTools.Attribute(AttributeName).SetValue(SolutionPath);
            xmlDoc.Save(XmlPath);
        }
    }
}
