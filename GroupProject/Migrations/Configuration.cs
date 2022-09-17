namespace GroupProject.Migrations
{
    using GroupProject.Models;
    using GroupProject.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GroupProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GroupProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var placeTypes = GetPlaceTypes();

            context.PlaceTypes.AddRange(placeTypes);



        }

        private List<PlaceType> GetPlaceTypes()
        {
            PlaceType natural = new PlaceType(PlaceTypeEnum.Natural, false);
            PlaceType religion = new PlaceType(PlaceTypeEnum.Religion, false);
            PlaceType sport = new PlaceType(PlaceTypeEnum.Sport, false);
            PlaceType amusements = new PlaceType(PlaceTypeEnum.Amusements, false);
            PlaceType historic = new PlaceType(PlaceTypeEnum.Historic, false);
            PlaceType cultural = new PlaceType(PlaceTypeEnum.Cultural, false);

            PlaceType accomondations = new PlaceType(PlaceTypeEnum.Accomondations, true);
            PlaceType adult = new PlaceType(PlaceTypeEnum.Adult, true);
            PlaceType foods = new PlaceType(PlaceTypeEnum.Foods, true);

            return new List<PlaceType>
            {
                natural, 
                religion, 
                sport, 
                amusements, 
                historic, 
                cultural, 
                accomondations, 
                adult,
                foods
            };
        }

    }
}
