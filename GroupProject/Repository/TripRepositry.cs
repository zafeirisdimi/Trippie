using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Repository
{
    public class TripRepositry
    {
        ApplicationDbContext db;
        public TripRepositry(ApplicationDbContext _context)
        {
            db = _context;
        }

        public List<Trip> GetAll()
        {
            return db.Trips.ToList();
        }
    }
}