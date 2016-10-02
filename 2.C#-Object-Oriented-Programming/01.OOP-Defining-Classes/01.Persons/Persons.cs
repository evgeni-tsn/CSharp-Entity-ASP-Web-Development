using System;

/*
    Define a class Person that has name, age and email. 
    The name and age are mandatory. The email is optional. 
    Define properties that accept non-empty name and age in the range [1 ... 100]. 
    In case of invalid arguments, throw an exception. 
    Define a property for the email that accepts either null or non-empty string containing '@'. Define two constructors. 
    The first constructor should take name, age and email. 
    The second constructor should take name and age only and call the first constructor. 
    Implement the ToString() method to enable printing persons at the console.
    */

namespace _01.Persons
{
    class Persons
    {
        static void Main()
        {
            Person pesho = new Person("pesho", 20);
            //Throw Exception for mail

            //Person gosho = new Person("gosho", 200,"mail.bg");

            //Throw Exception for age
            //Person mariika = new Person("mariika", 150,"test@mail.bg");

            Person ivan = new Person("Ivan", 28,"ivan@mail.bg");

            Console.WriteLine(pesho);
            //Console.WriteLine(gosho);
            //Console.WriteLine(mariika);
            Console.WriteLine(ivan);
        }
    }
}
