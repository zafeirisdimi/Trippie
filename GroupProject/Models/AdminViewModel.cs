﻿using System;
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
        public double AveragePlacesInTrip { get; set; }
        public List<AdminViewModelCity> MostSelectedCitiesOverall { get; set; }
        public List<AdminViewModelCity> MostSelectedCitiesStart { get; set; }
        public List<AdminViewModelCity> MostSelectedCitiesEnd { get; set; }
        public List<AdminViewModelCountry> MostActiveCountries { get; set; }
        public List<AdminViewModelPlaceType> MostSelectedPlaceTypes { get; set; }
    }

    public class AdminViewModelCity
    {
        public City City { get; set; }
        public int Count { get; set; }
    }

    public class AdminViewModelCountry
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class AdminViewModelPlaceType
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}