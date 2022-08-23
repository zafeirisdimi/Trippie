using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace GroupProjectTestbed.Models
{
    public class Location
    {
        public int Id { get; set; } //* after mapping from external source
        public string Name { get; set; }
        public string CountryName { get; set; }

        public Coordinates Coordinates { get; set; }
        

        public string TimeZone { get; set; }
    }
}
