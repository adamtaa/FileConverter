using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;
using FC.Data.Entities;
using System.Linq;

namespace FC.Data
{
    public static class DataObjectFactory
    {
        /// <summary>
        /// Loads the provided path as an xml file
        /// </summary>
        /// <param name="filePath">xml file location</param>
        /// <returns>XML object or null</returns>
        public static XElement LoadXmlMappingFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return XElement.Load(filePath);
            }

            return null;
        }

        /// <summary>
        /// Loads the CSV file into an array of string arrays
        /// </summary>
        /// <param name="filePath">Csv file location</param>
        /// <returns>Array of string arrays</returns>
        public static Dictionary<string, string>[] LoadCsvData(string filePath)
        {
            if (File.Exists(filePath))
            {
                var cList = new List<Dictionary<string,string>>();
                using (var sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    

                    if(!String.IsNullOrEmpty(line))
                    {
                        string[] data;
                        string[] columns = line.Split(",");

                        while((line = sr.ReadLine()) != null)
                        {
                            if (!String.IsNullOrEmpty(line))
                            {
                                data = line.Split(",");
                                cList.Add(new Dictionary<string, string>());

                                for (var i = 0; i < 5; i++)
                                {
                                    cList.Last().Add(columns[i], data[i]);
                                }
                            }
                        }
                    }
                    

                }

                return cList.ToArray();    
            }

            return new Dictionary<string, string>[] { };
        } 
    }
}
