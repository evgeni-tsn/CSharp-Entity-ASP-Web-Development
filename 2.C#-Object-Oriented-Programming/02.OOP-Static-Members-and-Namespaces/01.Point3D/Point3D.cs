namespace _01.Point3D
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        private static readonly Point3D StartingPointCoords;

        static Point3D()
        {
            StartingPointCoords = new Point3D(0,0,0);
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        private Point3D()
        {
        }

        public static Point3D StartingPoint
        {
            get { return Point3D.StartingPointCoords; }
        }
        public override string ToString()
        {
            return $"Point: {{{this.X}, {this.Y}, {this.Z}}}";
        }
    }
}