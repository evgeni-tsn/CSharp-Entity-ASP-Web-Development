using System;
namespace _02.LaptopShop
{
    /* Problem 2. Laptop Shop
    Define a class Laptop that holds the following information about a laptop device: model, manufacturer, processor, 
        * RAM, graphics card, HDD, screen, battery, battery life in hours and price.
            •	The model and price are mandatory. All other values are optional.
            •	Define two separate classes: a class Laptop holding an instance of class Battery.
            •	Define several constructors that take different sets of arguments 
                (full laptop + battery information or only part of it). 
                * Use proper variable types.
            •	Add a method in the Laptop class that displays information about the given instance
        o	Tip: override the ToString() method
            •	Put validation in all property setters and constructors. 
            String values cannot be empty, and numeric data cannot be negative. 
        * Throw exceptions when improper data is entered. */
    class LaptopShop
    {
        static void Main()
        {
            Laptop laptop = new Laptop(
               "Acer Aspire V3-571G",
               "Acer",
               "Intel Core i5-4210U",
               "8 GB",
               "nVidia GeForce 810m",
               "SAMSUNG EVO 120GB SSD",
               "15.6\" – 1366 x 733 )",
               new Battery(4, 2550, BatteryType.LiIon),
               4.5,
               2259M);

            Laptop laptop2 = new Laptop("Acer Aspire V5", 1699M);

            Console.WriteLine(laptop);
            Console.WriteLine(laptop2);
        }
    }
}
