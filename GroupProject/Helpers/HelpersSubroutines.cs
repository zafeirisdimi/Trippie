using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Test1;

namespace Helper
{
    internal class HelperSubroutines
    {
        internal static List<CoordinateModel> GetFullListOfPoints(List<Point> pointListInitial)
        {
            List<CoordinateModel> pointList = new List<CoordinateModel>() { new CoordinateModel { Id = 1, Longitude = pointListInitial[0].Longitude, Latitude = pointListInitial[0].Latitude } };


            for (int i = 1; i < pointListInitial.Count; i++)
            {
                int Id = i + 1;
                double Longitude = pointListInitial[i].Longitude;
                double Latitude = pointListInitial[i].Latitude;
                double DistanceFromPrevious = HelperSubroutines.Distance(
                                                            Longitude,
                                                            pointList[i - 1].Longitude,
                                                            Latitude,
                                                            pointList[i - 1].Latitude
                                                            );
                double DistanceFromStart = pointList[i - 1].DistanceFromStart + DistanceFromPrevious;
                pointList.Add( new CoordinateModel {Id= Id , Longitude = Longitude, Latitude=Latitude,DistanceFromPrevious= DistanceFromPrevious,DistanceFromStart=DistanceFromStart } );

            }
            return pointList;
        }

        public static double Distance(double lon1, double lon2, double lat1, double lat2)
        {

            // The math module contains
            // a function named toRadians
            // which converts from degrees
            // to radians.
            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = (Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2));

            double c = (2 * Math.Asin(Math.Sqrt(a)));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }

        private static double ToRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th
            // of a degree
            return (angleIn10thofaDegree * Math.PI) / 180;
        }

        internal static void DisplayResults0(List<Point> pointList)
        {
            Console.WriteLine($"{"Longitute",-15}{"Latitude",-15}");
            foreach (var point in pointList)
            {
                Console.WriteLine($"" +
                    $"{Math.Round(point.Longitude, 5),-15}" +
                    $"{Math.Round(point.Latitude, 5),-15}");
            }
        }
        internal static void DisplayResults1(List<CoordinateModel> pointList)
        {
            Console.WriteLine($"{"Id",-5}{"Longitute",-15}{"Latitude",-15}{"Distance from previous",-25}{"Distance from start",-25}");
            foreach (var point in pointList)
            {
                Console.WriteLine($"" +
                    $"{point.Id,-5}" +
                    $"{Math.Round(point.Longitude, 5),-15}" +
                    $"{Math.Round(point.Latitude, 5),-15}" +
                    $"{Math.Round(point.DistanceFromPrevious, 3),-25}" +
                    $"{Math.Round(point.DistanceFromStart, 3),-25}");
            }
        }

        internal static List<CoordinateModel> CalculatePointStopList(List<CoordinateModel> pointList, int noStations)
        {
            List<CoordinateModel> stopListPoints = new List<CoordinateModel>();
            var spacing = pointList[pointList.Count - 1].DistanceFromStart / (noStations + 1);
            stopListPoints.Add(pointList[0]);


            var i1 = 1;
            for (var j = 1; j <= noStations; j++)
            {
                for (var i = i1; i <= pointList.Count; i++)
                {
                    double interPoint = spacing * j;
                    if (pointList[i].DistanceFromStart < interPoint && pointList[i + 1].DistanceFromStart > interPoint)
                    {
                        CoordinateModel interPointActual = InterPoint(pointList[i], interPoint, pointList[i + 1]);
                        stopListPoints.Add(interPointActual);
                        i1 = i + 1;
                        break;
                    }
                }
            }
            stopListPoints.Add(pointList[pointList.Count - 1]);
            return stopListPoints;
        }

        internal static CoordinateModel InterPoint(CoordinateModel p1, double interPoint, CoordinateModel p3)
        {
            var diff1 = interPoint - p1.DistanceFromStart;
            var diff2 = p3.DistanceFromStart - interPoint;
            var intPoint = diff1 <= diff2 ? p1 : p3;
            return intPoint;
        }
    }
}
