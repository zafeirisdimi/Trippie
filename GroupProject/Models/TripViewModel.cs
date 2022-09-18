using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class TripViewModel
    {
        public bool IsPremiumUser { get; set; }
        public List<PlaceType> PlaceTypes { get; set; }
    }
}