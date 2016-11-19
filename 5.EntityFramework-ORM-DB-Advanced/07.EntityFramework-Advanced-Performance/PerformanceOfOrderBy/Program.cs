namespace PerformanceOfOrderBy
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Ads.Data;
    using Softuni.Data;
    using Softuni.Models;

    class Program
    {
        static void Main()
        {
            SoftuniContext context = new SoftuniContext();
            // Task[] tasks = new Task[900];
            // for (int i = 0; i < 900; i++)
            // {
            //     tasks[i] = Task.Run(() => Insert());
            // }
            //        //
            // Task.WaitAll(tasks);
            Console.WriteLine(context.Employees.Count());

            //OrderBeforeToList(context);
            //OrderAfterToList(context);

            //Order before to list - 293 entries:  00:00:00.0329984
            //Order before to list - 1000 entries: 00:00:00.0608150
            //Order before to list - 10 000 entries: 00:00:00.2946331
            //Order before to list - 100 000 entries: 00:00:04.1109568
            //Order before to list - 1 000 000 entries: 00:00:45.6620870

            //Order after to list - 293 entries:  00:00:00.0372287
            //Order after to list - 1000 entries: 00:00:00.0545328
            //Order after to list - 10 000 entries: 00:00:00.3236547
            //Order after to list - 100 000 entries: 00:00:04.4210877
            //Order after to list - 1 000 000 entries: 00:00:51.7048844
        }

        private static void Insert()
        {
            SoftuniContext context = new SoftuniContext();
            Random rnd = new Random();
            var employees = context.Employees.Take(1000).ToList();
            for (int i = 0; i < 1000; i++)
            {
                context.Employees.Add(new Employee()
                {
                    JobTitle = employees[rnd.Next(1, employees.Count)].JobTitle,
                    Department = employees[rnd.Next(1, employees.Count)].Department,
                    FirstName = employees[rnd.Next(1, employees.Count)].FirstName,
                    LastName = employees[rnd.Next(1, employees.Count)].LastName,
                    HireDate = employees[rnd.Next(1, employees.Count)].HireDate,
                    Salary = employees[rnd.Next(1, employees.Count)].Salary
                });
            }
            context.SaveChanges();
            Console.WriteLine("Inserted");
        }

        private static void OrderBeforeToList(SoftuniContext context)
        {
            Stopwatch beforeWatch = new Stopwatch();
            beforeWatch.Start();
            var employees =
                context.Employees.OrderBy(employee => employee.JobTitle)
                    .ThenByDescending(employee => employee.DepartmentID).ToList();

            beforeWatch.Stop();
            Console.WriteLine($"Order before ToList: {beforeWatch.Elapsed}");
        }

        private static void OrderAfterToList(SoftuniContext context)
        {
            Stopwatch afterWatch = new Stopwatch();
            afterWatch.Start();
            var employees =
                context.Employees.ToList().OrderBy(employee => employee.JobTitle)
                    .ThenByDescending(employee => employee.DepartmentID).ToList();

            afterWatch.Stop();
            Console.WriteLine($"Order after ToList: {afterWatch.Elapsed}");
        }
    }
}
