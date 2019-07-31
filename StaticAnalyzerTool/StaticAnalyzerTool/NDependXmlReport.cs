using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace StaticAnalyzerTool
{
    public static class NDependXmlReport
    {
        public static void GenerateNDependReport(string NDependXmlOutputPath)
        {
           
            XmlTextReader reader = new XmlTextReader(NDependXmlOutputPath);
            List<string> AttributeName = new List<string>();
            string[] AttribueValue = null;
            
            int flag = 0;

            while (reader.Read() && flag == 0)
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if(reader.Name == "Metric")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Name")
                                {
                                    AttributeName.Add(reader.Value);
                                }
                            }
                            
                        }
                        if (reader.Name == "R" && flag == 0)
                        {
                            int i = 0;
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                            {
                                if (i == 2 && reader.Name == "V")
                                {
                                    
                                    string answere = reader.Value;
                                    AttribueValue = answere.Split('|');
                                }
                                i++;
                            }
                            flag = 1;
                        }
                        break;

                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }

            for (int k = 0; k <AttributeName.Count-3; k++)
            {
                Console.WriteLine("Error Message Parameter = {0} || Error Counts = {1}",AttributeName[k+3],AttribueValue[k].ToString());
            }

            
        }

    }
}
