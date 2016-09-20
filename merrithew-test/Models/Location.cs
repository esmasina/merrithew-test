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

        public static Location FromCsv(string csvLine)
        {
            string[] values = csvLine.Replace("\"", "").Split(',');
            Location loc = new Location();
            loc.LocationTypeCode = values[0];
            loc.LocationTypeDesc = values[1];
            loc.LocationCode = values[2];
            loc.LocationDesc = values[3];
            loc.LocationName = values[4];
            loc.Address = values[5];
            loc.Phone = values[6];
            loc.Notes = values[7];
            loc.Lat = Convert.ToDecimal(values[8]);
            loc.Long = Convert.ToDecimal(values[9]);
            return loc;
        }
    }
}