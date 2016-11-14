using _2.UsersDatabase.Models;

namespace _2.UsersDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2.UsersDatabase.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_2.UsersDatabase.UsersContext";
        }

        protected override void Seed(_2.UsersDatabase.UsersContext context)
        {
            context.Users.AddOrUpdate(user => user.Username, new User
            {
                Age = 15,
                Email = "daspf@abv.com",
                isDeleted = true,
                LastTimeLoggedIn = new DateTime(1992, 11, 29),
                Password = "hel$A-_99lo",
                //  ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
                Username = "Bai Stenly",
                FirstName = "Stanislav",
                LastName = "Karagiozov",
            },
           new User
           {
               Age = 110,
               Email = "bdas@gam.com",
               isDeleted = true,
               LastTimeLoggedIn = new DateTime(1993, 1, 20),
               Password = "heds-alA2_lo",
                // ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
               FirstName = "Atanas",
               LastName = "Stamatov",
               Username = "Bai Nasko"
           });
            context.SaveChanges();
        }
    }
}
