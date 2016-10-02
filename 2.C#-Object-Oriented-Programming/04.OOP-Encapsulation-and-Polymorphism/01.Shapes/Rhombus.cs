namespace _01.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double height) : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return this.Width * 4;
        }
    }
}