using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace StaticAnalyzerTool
{
    class NDependXmlReport
    {
        public static void Main(string[] args)
        {
            string NDependXmloutput = "C:\\Users\\320050491\\Downloads\\NDependOutput\\TrendMetrics\\NDependTrendData2019.xml";
            XmlTextReader reader = new XmlTextReader(NDependXmloutput);
            Dictionary<string, string > NDependMetrics = new Dictionary<string, string>();
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
                                    
                                    string ans = reader.Value;
                                    AttribueValue = ans.Split('|');
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

            for (int k = 0; k <AttributeName.Count; k++)
            {
                NDependMetrics.Add(AttributeName[k], AttribueValue[k]);
            }

            foreach (var item in NDependMetrics)
            {
                Console.WriteLine(item);
            }
        }

    }
}
