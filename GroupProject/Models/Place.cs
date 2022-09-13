using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class Place
    {
        [ForeignKey("Coordinates")]
        public int Id { get; set; }
        public string Xid { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string ImageUrl { get; set; }

        public string Info { get; set; }
        public virtual Coordinates Coordinates { get; set; }

        public Place()
        {
            this.Trip = new HashSet<Trip>();
        }
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
