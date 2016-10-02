namespace Methods
{
    using System;

    public class ExtensionMethods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if ((a <= 0) || (b <= 0) || (c <= 0))
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    {
                        return "zero";
                    }

                case 1:
                    {
                        return "one";
                    }

                case 2:
                    {
                        return "two";
                    }

                case 3:
                    {
                        return "three";
                    }

                case 4:
                    {
                        return "four";
                    }

                case 5:
                    {
                        return "five";
                    }

                case 6:
                    {
                        return "six";
                    }

                case 7:
                    {
                        return "seven";
                    }

                case 8:
                    {
                        return "eight";
                    }

                case 9:
                    {
                        return "nine";
                    }

                default:
                    {
                        return "Invalid number!";
                    }
            }
        }

        public static int FindMax(params int[] elements)
        {
            if ((elements == null) || (elements.Length == 0))
            {
                throw new ArgumentOutOfRangeException(nameof(elements), "Elements cannot be null or empty");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        public static double CalcDistance(
            double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            double tolerance = 0.00000001;
            isHorizontal = Math.Abs(y1 - y2) < tolerance;
            isVertical = Math.Abs(x1 - x2) < tolerance;

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
    }
}
