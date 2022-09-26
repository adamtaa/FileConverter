using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FC.Data;
using FC.Data.Entities;

namespace FC.Business
{
    public static class Converter
    {
        public static XElement Convert(IEnumerable<Dictionary<string,string>> constituents, XElement mappings)
        {
            var result = new XElement("constituents");
            var links = from mapping in mappings.Descendants("mapping").Descendants("map") select mapping;
                
            foreach(var c in constituents)
            {
                var next = new XElement("constituent");
                foreach(var map in links)
                {
                    var source = map.Attribute("source")?.Value;
                    if (!String.IsNullOrWhiteSpace(source))
                    {
                        next.Add(new XElement(source,new XAttribute("value",c[source])));
                    }
                    
                }

                result.Add(next);
            }

            return result;

        }
    }
}
