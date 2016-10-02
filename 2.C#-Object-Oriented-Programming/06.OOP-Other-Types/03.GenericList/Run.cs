using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericList
{
    //Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> ints = new GenericList<int>();
            ints.Add(2);
            ints.Add(5);
            ints.Clear();
            ints.Add(23);
            ints.Add(1);
            ints.Add(42);
            ints.Add(87);
            
            ints.RemoveAt(3);
            ints.AddRange(23, 3, 2, 1);
            Console.WriteLine(string.Join(", ",ints));
            GenericList<string> str = new GenericList<string>();
            str.Add("Test");
            str.Clear();
            str.AddRange("Pesho","Gosho");
            Console.WriteLine(string.Join(", ", str));

        }
    }
}
