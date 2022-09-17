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

            var viewModel = new AdminViewModel
            {
                Users = users,
                Trips = trips,
                Places = places,
                Cities = cities
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



    }
}