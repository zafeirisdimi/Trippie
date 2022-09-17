using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();


        // GET: Admin
        public ActionResult Index()
        {
            var users = GetUsers().ToList();
            var trips = GetTrips().ToList();
            var places = GetPlaces().ToList();
            var cities = GetCities().ToList();

            var averagePlacesInTrip = GetAveragePlacesInTrip();
            var mostSelectedCitiesOverall = GetMostSelectedCitiesOverall(5).ToList();
            var mostSelectedCitiesStart = GetMostSelectedCitiesStart(5).ToList();
            var mostSelectedCitiesEnd = GetMostSelectedCitiesEnd(5).ToList();
            var mostActiveCountries = GetMostActiveCountries(5).ToList();
            var mostSelectedPlaceTypes = GetMostSelectedPlaceTypes().ToList();



            var viewModel = new AdminViewModel
            {
                Users = users,
                Trips = trips,
                Places = places,
                Cities = cities,
                AveragePlacesInTrip = averagePlacesInTrip,
                MostSelectedCitiesOverall = mostSelectedCitiesOverall,
                MostSelectedCitiesStart = mostSelectedCitiesStart,
                MostSelectedCitiesEnd = mostSelectedCitiesEnd,
                MostActiveCountries = mostActiveCountries,
                MostSelectedPlaceTypes = mostSelectedPlaceTypes
            };


            return View(viewModel);
        }


        [NonAction]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users;
        }

        [NonAction]
        public IEnumerable<Trip> GetTrips()
        {
            return _context.Trips;
        }

        [NonAction]
        public IEnumerable<Place> GetPlaces()
        {
            return _context.Places;
        }

        [NonAction]
        public IEnumerable<City> GetCities()
        {
            return _context.Cities;
        }

        [NonAction]
        public IEnumerable<AdminViewModelPlaceType> GetMostSelectedPlaceTypes()
        {
            return _context.PlaceTypes.Select(t => new AdminViewModelPlaceType { Name = t.Name, Count = t.Trips.Count })
                                      .OrderByDescending(g => g.Count);
        }

        [NonAction]
        public double GetAveragePlacesInTrip()
        {
            return _context.Trips.Average(t => t.Places.Count);
        }

        [NonAction]
        public IEnumerable<AdminViewModelCity> GetMostSelectedCitiesOverall(int number)
        {
            var startCities = _context.Trips.Select(t => t.Start);
            var endCities = _context.Trips.Select(t => t.End);

            return startCities.Union(endCities)
                              .GroupBy(c => c.GeonameID, (id, cities) => new AdminViewModelCity { City = cities.FirstOrDefault(), Count = cities.Count() })
                              .OrderByDescending(g => g.Count)
                              .ThenBy(g => g.City.Name)
                              .Take(number);
        }


        [NonAction]
        public IEnumerable<AdminViewModelCity> GetMostSelectedCitiesStart(int number)
        {

            return _context.Trips.Select(t => t.Start)
                                 .GroupBy(c => c.GeonameID, (id, cities) => new AdminViewModelCity { City = cities.FirstOrDefault(), Count = cities.Count() })
                                 .OrderByDescending(g => g.Count)
                                 .ThenBy(g => g.City.Name)
                                 .Take(number);
        }

        [NonAction]
        public IEnumerable<AdminViewModelCity> GetMostSelectedCitiesEnd(int number)
        {
            return _context.Trips.Select(t => t.End)
                                 .GroupBy(c => c.GeonameID, (id, cities) => new AdminViewModelCity { City = cities.FirstOrDefault(), Count = cities.Count() })
                                 .OrderByDescending(g => g.Count)
                                 .ThenBy(g => g.City.Name)
                                 .Take(number);
        }

        [NonAction]
        public IEnumerable<AdminViewModelCountry> GetMostActiveCountries(int number)
        {
            return _context.Cities.GroupBy(c => c.Country, (country, cities) => new AdminViewModelCountry { Name = country, Count = cities.Count() })
                                  .OrderBy(g => g.Count)
                                  .OrderByDescending(g => g.Count)
                                  .Take(number);
        }

    }
}