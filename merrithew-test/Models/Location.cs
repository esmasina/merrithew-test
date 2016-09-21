using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace merrithew_test.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string LocationTypeCode { get; set; }
        public string LocationTypeDesc { get; set; }
        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }

    }
}