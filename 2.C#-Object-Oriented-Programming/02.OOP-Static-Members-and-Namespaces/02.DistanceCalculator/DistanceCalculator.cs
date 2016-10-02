using System;
using _01.Point3D;
namespace _02.DistanceCalculator
{
    public static class DistanceCalculator
    {
        public static double Calculate3DDistance(double x1, double y1, double z1,double x2, double y2, double z2)
        {
            //d = sqrt((x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2)
            double result = 
                Math.Sqrt(
                    Math.Pow(x2 - x1, 2) + 
                    Math.Pow(y2 - y1, 2) + 
                    Math.Pow(z2 - z1, 2));
            return result;
        }
        public static double Calculate3DDistance(Point3D pointA, Point3D pointB)
        {
            //d = sqrt((x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2)
            double result =
                Math.Sqrt(
                    Math.Pow(pointB.X - pointA.X, 2) +
                    Math.Pow(pointB.Y - pointA.Y, 2) +
                    Math.Pow(pointB.Z - pointA.Z, 2));
            return result;
        }
    }
}