namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(Utils.GetFileExtension("example"));
            Console.WriteLine(Utils.GetFileExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Utils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Utils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Utils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", Utils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXyz());
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXy());
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXz());
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYz());
        }
    }
}
