using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Web;

namespace GroupProject.Models
{
    public class City
    {
        [ForeignKey("Coordinates")]
        public int Id { get; set; } //* after mapping from external source
        public string ΑsciiName { get; set; }
        public string CountryNameΕΝ { get; set; }

        //public int CoordinatesId { get; set; }
        public virtual Coordinates Coordinates { get; set; }

        public City()
        {
        }
    }
}
