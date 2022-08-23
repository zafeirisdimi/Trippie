using GroupProjectTestbed.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace GroupProjectTestbed.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public string ShortName { get; set; }
        public Location Start { get; set; }
        public Location End { get; set; }

        public DateTime StartDate { get; set; }

        public List<PlaceType> PlacesType { get; set; }
        public List<Place> Places { get; set; } //place of interests

        public List<ApplicationUser> Participants { get; set; }

        public int GeonameId { get; set; }// OpenStreetMap Api id for cities

        // extra
        public TripRoute  Route { get; set; }


    }
}
