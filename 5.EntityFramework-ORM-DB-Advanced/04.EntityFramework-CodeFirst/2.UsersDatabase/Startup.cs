using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using _2.UsersDatabase.Models;

namespace _2.UsersDatabase
{
    class Startup
    {
        static void Main()
        {
           
            UsersContext context = new UsersContext();
            
            context.Database.Initialize(true);
            try
            {
                var user = new User()
                {
                    Username = "gesha",
                    Age = 121,
                    Email = "gosho@mail.bg",
                    FirstName = "Gosho",
                    LastName = "Goshov",
                    isDeleted = false,
                    Password = "s!kreTPass",
                    RegisteredOn = new DateTime(1999, 1, 2),
                    LastTimeLoggedIn = new DateTime(2016, 2, 1)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
