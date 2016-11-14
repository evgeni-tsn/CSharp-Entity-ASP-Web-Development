using _2.UsersDatabase.Models;

namespace _2.UsersDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersContext>());
        }

         public virtual DbSet<User> Users { get; set; }

//         public virtual DbSet<Town> Towns { get; set; }
    }
}