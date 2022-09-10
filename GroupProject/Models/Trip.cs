using GroupProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace GroupProject.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public virtual Location Start { get; set; }
        public virtual Location End { get; set; }
        public DateTime StartDate { get; set; }
        public List<PlaceType> PlacesType { get; set; } //Enum??
        public Trip()
        {
            this.Place = new HashSet<Place>();
            //this.PlacesType = new HashSet<PlaceType>(); //Enum??
        }
        public virtual ICollection<Place> Place { get; set; }
        public virtual ICollection<PlaceType> PlaceTypes { get; set; }  //Enum??

        public List<ApplicationUser> Participants { get; set; }

        public int GeonameId { get; set; }  // OpenStreetMap Api id for cities
    }
}