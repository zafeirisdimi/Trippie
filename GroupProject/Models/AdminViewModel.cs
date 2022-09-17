using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class AdminViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<City> Cities { get; set; }
        public List<Place> Places { get; set; }
        public List<Trip> Trips { get; set; }
    }
}