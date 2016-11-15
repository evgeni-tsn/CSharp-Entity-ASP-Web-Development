using _2.UsersDatabase.Models;

namespace _2.UsersDatabase
{
    using System.Data.Entity;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersContext>());
        }

         public virtual DbSet<User> Users { get; set; }

         public virtual DbSet<Town> Towns { get; set; }
    }
}