using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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

            for (int i = 0; i < errorType.Count; i++)
            {
               Console.WriteLine("Message = {0} || TypeOfError = {1} || CertainityLevel = {2}",errorMessage[i],errorType[i],errorCertainity[i]);
            }
        }

    }
}
