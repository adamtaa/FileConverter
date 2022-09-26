using FC.Data;
using FC.Business;
using System;

namespace FC.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //load the constituents into a variable
            var constituents = DataObjectFactory.LoadCsvData(@".\Resources\constituents.csv");

            //load the mapping file
            var fileMappings = DataObjectFactory.LoadXmlMappingFile(@".\Resources\mapping1.xml");

            var results = FC.Business.Converter.Convert(constituents, fileMappings);

            results.Save(@".\Resources\constituents.xml");
        }
    }
}
