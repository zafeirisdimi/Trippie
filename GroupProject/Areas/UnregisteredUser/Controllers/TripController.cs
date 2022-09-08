using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Areas.UnregisteredUser.Controllers
{
    public class TripController : Controller
    {
        // GET: UnregisteredUser/Trip
        public ActionResult Index()
        {
            return View();
        }
    }
}