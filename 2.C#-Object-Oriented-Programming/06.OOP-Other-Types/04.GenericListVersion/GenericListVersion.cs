using System;
using _03.GenericList;

namespace _04.GenericListVersion
{

    /*Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to GenericList<T> class and display its version at runtime.*/
    class GenericListVersion
    {
        public static void Main()
        {
            IGenericList<string> list = new GenericList<string>();
            list.Add("Hello");
            
            Console.WriteLine(list.Version());
        }
    }
}
