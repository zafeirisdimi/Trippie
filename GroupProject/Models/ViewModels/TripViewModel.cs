using GroupProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models.ViewModels
{
    public class TripViewModel
    {
        public bool IsPremiumUser { get; set; }
        public List<PlaceType> PlaceTypes { get; set; }
    }
}