using System;
using _01.Point3D;

/*  Write a static class DistanceCalculator with a static method
    to calculate the distance between two points in the 3D space.     
    Search in Internet how to calculate distance in the 3D Euclidian space.
    */

namespace _02.DistanceCalculator
{
    class ProgramStart
    {
        static void Main()
        {
            //Normal implementation
            Console.WriteLine("Enter Point A: ");
            Console.Write("Enter X-Axis: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Y-Axis: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Z-Axis: ");
            double z1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Point B: ");
            Console.Write("Enter X-Axis: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Y-Axis: ");
            double y2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Z-Axis: ");
            double z2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Calculated by method with 2 coords for every point.");
            Console.WriteLine(DistanceCalculator.Calculate3DDistance(x1, y1, z1, x2, y2, z2));

            //Using Class Point3D from previous Problem.
            Console.WriteLine("Using Class Point3D from previous task.");
            var pointA = new Point3D(-7, -4, 3);
            var pointB = new Point3D(17, 6, 2.5);

            Console.WriteLine(DistanceCalculator.Calculate3DDistance(pointA, pointB));

        }
    }
}
