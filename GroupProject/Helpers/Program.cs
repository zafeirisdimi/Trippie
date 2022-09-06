using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Από τα Nuget πρέπει να γίνει εγκατάσταση το System.Text.Json

            // 1 - Trial data on a two column table named pointListInitial (Longitude(double) & Latitude(double))
            Point p1 = new Point() { Longitude = 12.51092, Latitude = 41.89153 };
            Point p2 = new Point() { Longitude = 12.512630000000001, Latitude = 41.89072 };
            Point p3 = new Point() { Longitude = 12.511790000000001, Latitude = 41.89043 };
            Point p4 = new Point() { Longitude = 12.51256, Latitude = 41.89 };
            Point p5 = new Point() { Longitude = 12.51335, Latitude = 41.88956 };
            Point p6 = new Point() { Longitude = 12.514280000000001, Latitude = 41.88928000000001 };
            Point p7 = new Point() { Longitude = 12.515070000000001, Latitude = 41.89002000000001 };
            Point p8 = new Point() { Longitude = 12.51491, Latitude = 41.890280000000004 };
            Point p9 = new Point() { Longitude = 12.515400000000001, Latitude = 41.891020000000005 };
            Point p10 = new Point() { Longitude = 12.515950000000002, Latitude = 41.89161 };

            List<Point> pointListInitial = new List<Point>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            // 2 - Print the two columns table to console
            // HelperSubroutines.DisplayResults0(pointListInitial);

            // 3 - Create and complete a new 5 columns table named pointList passing data
            // from pointListInitial table and calculate Id(int), DistamceFromStart(double) & DistamceFromPrevious(double)
            List<CoordinateModel> pointList = HelperSubroutines.GetFullListOfPoints(pointListInitial);

            // 4 - Print the 6 columns table to console
            HelperSubroutines.DisplayResults1(pointList);

            // 5 - Create a new list named stopListPoints of point model objects and put in this list Start point, all intermediate points and Endpoint
            var stopListPoints = HelperSubroutines.CalculatePointStopList(pointList, 3);

            // 4 - Write results to console
            HelperSubroutines.DisplayResults1(stopListPoints);
        }
    }
}
