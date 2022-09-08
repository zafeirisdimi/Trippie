﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace GroupProject.Models
{
    public class Location
    {
        public int Id { get; set; } //* after mapping from external source
        public string ΑsciiName { get; set; }
        public string CountryNameΕΝ { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
