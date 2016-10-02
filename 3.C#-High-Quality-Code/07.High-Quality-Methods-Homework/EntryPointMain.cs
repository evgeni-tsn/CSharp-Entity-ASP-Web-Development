namespace Methods
{
    using System;

    public class EntryPointMain
    {
        public static void Main()
        {
            Console.WriteLine(ExtensionMethods.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ExtensionMethods.NumberToDigit(5));

            Console.WriteLine(ExtensionMethods.FindMax(5, -1, 3, 2, 14, 2, 3));

            ExtensionMethods.PrintAsNumber(1.3, "f");
            ExtensionMethods.PrintAsNumber(0.75, "%");
            ExtensionMethods.PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(
                ExtensionMethods.CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                OtherInfo = "From Sofia, born at 17.03.1992"
            };

            Student stella = new Student
            {
                FirstName = "Stella",
                LastName = "Markova",
                OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993"
            };

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}