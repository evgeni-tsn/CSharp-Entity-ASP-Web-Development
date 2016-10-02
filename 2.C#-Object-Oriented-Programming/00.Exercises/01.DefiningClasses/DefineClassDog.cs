using System;
namespace _01.DefineClassDog
{
    /* Your task is to define a simple class Dog. It should have properties name and breed (both optional). The class should allow you to view and modify the name and breed at any time. Finally, the dog should be able to Bark(). */
    class DefineClassDog
    {
        static void Main()
        {
            Dog unnamed = new Dog();
            Dog sharo = new Dog("Sharo", "Melez");

            unnamed.Breed = "German Shepherd";
            unnamed.Bark();
            sharo.Bark();
        }
    }
}
