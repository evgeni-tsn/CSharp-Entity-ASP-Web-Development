using System;
using System.Linq;
using _02.Animals.Animals;

namespace _02.Animals
{
    class Run
    {
        static void Main()
        {
            Animal[] animals =
            {
                new Dog("Pesho", 12, Gender.Male),
                new Frog("Frogger", 4, Gender.Female),
                new Kitten("Pussy", 5),
                new Kitten("Pisi", 10),
                new Tomcat("Gosho", 5),
                new Tomcat("Ivan", 2),
                new Frog("Jumper", 2, Gender.Female),
                new Dog("Dragan", 10, Gender.Male),
            };

            var frogsAverageAge = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("The average age of all frogs is: {0}", frogsAverageAge);

            var dogsAverageAge = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("The average age of all dogs is: {0}", dogsAverageAge);

            var kittensAverageAge = animals.Where(x => x is Kitten).Average(x => x.Age);
            Console.WriteLine("The average age of all kittens is: {0}", kittensAverageAge);

            var tomcatsAverageAge = animals.Where(x => x is Tomcat).Average(x => x.Age);
            Console.WriteLine("The average age of all tomcats is: {0}", tomcatsAverageAge);
        }
    }
}
