using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace StaticAnalyzerTool
{
    public static class FxCopReport
    {
        public static void GenerateFxCopReport(string fxCopXmlOutputPath)
        {
            var xmlDoc = XElement.Load(fxCopXmlOutputPath);
            List<string> errorType = new List<string>();
            List<string> errorMessage = new List<string>();
            List<string> errorCertainity = new List<string>();
            var messages = from element in xmlDoc.Descendants()
                where element.Name == "Issue"
                select element;

            foreach (var msg in messages)
            {
                errorMessage.Add(msg.Value);
                errorType.Add(msg.Attribute("Level").Value);
                errorCertainity.Add(msg.Attribute("Certainty").Value);
            }

            StringBuilder strbuild = new StringBuilder();
            string text = "FxCop_Report";
            strbuild.AppendLine(text);
            for (int i = 0; i < errorType.Count; i++)
            {
                text =string.Format("Error_Message = {0} Error_Type = {1} Certainity_Level = {2}", errorMessage[i],
                    errorType[i], errorCertainity[i]);
                strbuild.AppendLine(text); 
            }

            try
            {
                System.IO.File.WriteAllText(@"..\..\..\..\FinalOutput.txt", strbuild.ToString());
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
