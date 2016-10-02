using System;

/*  Create a class Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
    Create appropriate constructors. Override ToString() to enable printing a 3D point.

    Add a private static read-only field in the Point3D class to hold the start of the coordinate system – 
    the point StartingPoint {0, 0, 0}. 
    Add a static property to return the starting point.
    */

namespace _01.Point3D
{
    class ProgramStart
    {
        static void Main()
        {
            var p = new Point3D(10.2,5.6,14.8);
            Console.WriteLine(p);

            Console.WriteLine("Starting " + Point3D.StartingPoint);
        }
    }
}
