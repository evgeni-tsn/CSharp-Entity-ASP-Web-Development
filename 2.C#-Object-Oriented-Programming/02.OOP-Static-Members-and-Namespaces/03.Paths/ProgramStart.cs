using System;
using _01.Point3D;

/*  Create a class Path3D to hold a sequence of points in 3D space. 
    Create a static class Storage with static methods to save and load paths from a text file. 
    Use a file format of your choice. 
    Ensure you close correctly all files with the "using" statement.
    */

namespace _03.Paths
{
    class ProgramStart
    {
        private const string File = @"../../path.xml";

        static void Main()
        { 
          var path = new Path3D(
              new Point3D(3,4,2),
              new Point3D(5.2,6,7),
              new Point3D(1,2,3),
              new Point3D(10,11,9.4)); 

            Storage.SavePath(File, path);

            Path3D path2 = Storage.LoadPath(File);

            Console.WriteLine(string.Join(Environment.NewLine, path2.Path));
        }
    }
}
