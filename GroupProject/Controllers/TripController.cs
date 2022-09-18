using GroupProject.Models;
using GroupProject.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class TripController : Controller
    {
        ApplicationDbContext _context=new ApplicationDbContext();   //Leon modified
        private TripRepositry tripRepo;                             //Leon new

        UserManager<ApplicationUser> _userManager;

        public TripController()
        {
            _context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(_context);
            _userManager = new UserManager<ApplicationUser>(userStore);

            tripRepo = new TripRepositry(_context);                 //Leon new
        }

        // GET: Trip
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);

            var placeTypes = _context.PlaceTypes.ToList();

            TripViewModel tripViewModel = new TripViewModel
            {
                IsPremiumUser = user.IsPremiumUser,
                PlaceTypes = placeTypes
            };

            return View(tripViewModel);
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

        // // Leonidas start

        // 1. Get All Trips
        [Authorize]
        [HttpGet]
        public ActionResult GetAllTrips()
        {
            var allTripsInDB = _context.Trips.ToList();

            return View(allTripsInDB);
        }

        // 2. Get trip by Id
        [Authorize]
        [HttpGet]
        public ActionResult GetTripById(int tripId)
        {
            var tripById = _context.Trips.Where(x => x.Id == tripId).FirstOrDefault();

            return View(tripById);
        }

        // 3. Delete a trip
        [Authorize]
        [HttpDelete]
        public ActionResult DeleteTrip(int TripId)
        {
            var tripInDB = _context.Trips.SingleOrDefault(c => c.Id == TripId);

            if (tripInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            _context.Trips.Remove(tripInDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
        // //Leonidas End
    }
}