using GroupProject.Database;
using GroupProject.Models;
using GroupProject.Models.Dtos;
using GroupProject.Models.Entities;
using GroupProject.Models.ViewModels;
using GroupProject.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GroupProject.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;

        private TripRepositοry tripRepo;
        private UserRepository userRepo;

        public TripController()
        {
            _context = new ApplicationDbContext();

            tripRepo = new TripRepositοry(_context);
            userRepo = new UserRepository(_context);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // GET: Trip
        public ActionResult CreateTrip()
        {
            var user = userRepo.GetCurrentUser(User);

            var placeTypes = tripRepo.GetPlaceTypes();

            TripViewModel tripViewModel = new TripViewModel
            {
                IsPremiumUser = user.IsPremiumUser,
                PlaceTypes = placeTypes
            };

            return View(tripViewModel);
        }


        [HttpPost]
        public ActionResult CreateTrip(TripDto dto)
        {
            Trip trip = new Trip(dto);

            var user = userRepo.GetCurrentUser(User);

            // Add null checks for the unregistered user
            // if user ==  null do something else

            trip.ApplicationUser = user;

            tripRepo.CreateTrip(trip);

            tripRepo.AddPlaceTypesToTrip(trip, dto.ChosenPlaceTypes);


            return Json(new { redirectToUrl = Url.Action("CreateTrip", "Trip") });
        }


        [Authorize]
        [HttpDelete]
        public ActionResult DeleteTrip(int tripId)
        {
            var tripInDB = tripRepo.GetTripById(tripId);

            if (tripInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            tripRepo.DeleteTrip(tripInDB);

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
    }
}