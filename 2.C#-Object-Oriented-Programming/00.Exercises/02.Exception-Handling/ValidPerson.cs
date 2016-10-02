using System;

    /*Define a simple class Person which has the following fields: first name, last name and age. Validate the data in the properties’ setters, throw appropriate exceptions in case invalid data is entered. */
namespace _01.ValidPerson
{
    class ValidPerson
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 25);
            Console.WriteLine(pesho);
            try
            {
                Person noName = new Person(string.Empty, "Goshov", 12);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            try
            {
                Person noLastName = new Person("Mariq", null, 25);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            try
            {
                Person overAged = new Person("Ivan", "Ivanov", 250);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
