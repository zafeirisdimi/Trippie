using GroupProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace GroupProject.Models
{
    public class Trip
    {
        
        public int Id { get; set; }
        public string ShortName { get; set; }
        public DateTime StartDate { get; set; }
        public virtual City Start { get; set; }
        public virtual City End { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<PlaceType> ChosenPlaceTypes { get; set; }

        public Trip()
        {
            this.Places = new HashSet<Place>();
            this.ChosenPlaceTypes = new HashSet<PlaceType>();
        }
    }
}