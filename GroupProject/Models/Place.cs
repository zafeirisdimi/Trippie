using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace GroupProjectTestbed.Models
{
    public class Place
    {
        public int Id { get; set; }
       
        public Coordinates Coordinates { get; set; }

        public string Name { get; set; }

        public string InfoUrl { get; set; }

        public string ImageUrl { get; set; }

        public int OsmId { get; set; }//*** OpenStreetMap Api id for places

        public string Rate { get; set; }
    }
}
