using GroupProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class TripController : Controller
    {
        ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;

        public TripController()
        {
            _context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(_context);
            _userManager = new UserManager<ApplicationUser>(userStore);
        }


        // GET: Trip
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateTrip()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateTrip(TripDto dto)
        {
            Trip trip = new Trip(dto);

            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);

            // Add null checks for the unregistered user
            // if user ==  null do something else

            trip.ApplicationUser = user;

            _context.Trips.Add(trip);

            _context.SaveChanges();

            List<PlaceType> placeTypes = new List<PlaceType>();

            PlaceType placeType;

            foreach (var value in dto.ChosenPlaceTypes)
            {
                placeType = _context.PlaceTypes.Find(value);

                placeTypes.Add(placeType);
            }

            trip.ChosenPlaceTypes = placeTypes;

            _context.SaveChanges();

            return Json(new { redirectToUrl = Url.Action("CreateTrip", "Trip") });
        }
    }
}