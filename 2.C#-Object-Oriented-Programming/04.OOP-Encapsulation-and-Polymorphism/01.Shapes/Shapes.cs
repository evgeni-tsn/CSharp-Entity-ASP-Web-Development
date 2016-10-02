using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Shapes
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Circle(20),
                new Rectangle(10,2),
                new Rhombus(2.3,4.2),
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name} -> Perimeter: {shape.CalculatePerimeter():F2}");
                Console.WriteLine($"{shape.GetType().Name} -> Area: {shape.CalculateArea():F2}");
            }
        }
    }
}
