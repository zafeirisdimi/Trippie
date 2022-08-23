using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GroupProject.Helpers
{
    public class PointReductionHelper
    {
        public void ReducePoints(List<object> points)
        {
            ConcurrentBag<(double, double)> finalPointsParallel = new ConcurrentBag<(double, double)>();

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
                    finalPointsParallel.Add(points[i]);
            });

            Console.WriteLine(finalPointsParallel.Count);
        }

        public double CalculateDistance((double lng, double lat) co1, (double lng, double lat) co2)
        {
            double radius = 6371;

            return 2 * radius * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((co2.lat - co1.lat) / 2), 2) + Math.Cos(co1.lat) * Math.Cos(co2.lat) * Math.Pow(Math.Sin((co2.lng - co1.lng) / 2), 2)));
        }
    }
}