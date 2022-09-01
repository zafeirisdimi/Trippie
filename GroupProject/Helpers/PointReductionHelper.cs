using GroupProject.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupProject.Helpers
{
    public static class PointReductionHelper
    {
        public static Coordinates[] ReducePoints(List<Coordinates> points)
        {
            if (points == null)
                return Enumerable.Empty<Coordinates>().ToArray();

            ConcurrentBag<Coordinates> finalPoints = new ConcurrentBag<Coordinates>();

            Parallel.For(0, points.Count, i =>
            {
                bool flagForRemove = false;

                for (int j = 0; j < points.Count; j++)
                {
                    if (i == j)
                        continue;

                    double distance = CalculateDistance(points[i], points[j]);

                    if (distance < 50)
                    {
                        flagForRemove = true;
                        break;
                    }
                }

                if (!flagForRemove)
                    finalPoints.Add(points[i]);

            });

            return finalPoints.ToArray();
        }

        public static double CalculateDistance(Coordinates co1, Coordinates co2)
        {
            double radius = 6371; // Earth's radius in km

            return 2 * radius * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((co2.Latitude - co1.Latitude) / 2), 2) + Math.Cos(co1.Latitude) * Math.Cos(co2.Latitude) * Math.Pow(Math.Sin((co2.Longitude - co1.Longitude) / 2), 2)));
        }
    }
}