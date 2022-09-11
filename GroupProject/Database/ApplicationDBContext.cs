using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupProject.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("name=MapDBModels")
        {
        
        }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
    }
}