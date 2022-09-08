using GroupProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class SearchAlongPathDto
    {
        public List<Coordinates> PathOverview { get; set; }
        public PlaceType[] PlaceTypes { get; set; }
    }
}