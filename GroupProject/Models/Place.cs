using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Xid { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Info { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
