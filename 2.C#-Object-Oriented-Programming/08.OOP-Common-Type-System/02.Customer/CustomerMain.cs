using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Customer
{
    class CustomerMain
    {
        static void Main()
        {
            Customer one = new Customer("Pesho","Goshov","Petrov","1212","Mladost","089322","mail");
            Customer two = new Customer("Pesho","Goshov","Petrov","1212","Mladost","089322","mail");
            var three = two.Clone() as Customer;

            Console.WriteLine(one==two);
            Console.WriteLine(one.GetHashCode());
            Console.WriteLine(two.GetHashCode());
            Console.WriteLine(one);
            Console.WriteLine(one.CompareTo(two));
        }
    }
}
