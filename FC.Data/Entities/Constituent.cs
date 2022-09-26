using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Data.Entities
{
    public class Constituent
    {
        

        public int Id{get; set;}
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public string SubIndustry { get; set; }
        public double Price { get; set; }
    }
}
