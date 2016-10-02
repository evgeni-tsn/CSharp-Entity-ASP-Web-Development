using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.StudentClass
{
    class ProgramMain
    {
        static void Main(string[] args)
        {
            Student student = new Student("Ekaterina", 22);

            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine(
                    "Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName,
                    eventArgs.OldValue,
                    eventArgs.NewValue);
            };

            student.Name = "Katya";
            student.Age = 52;
        }
    }
}
