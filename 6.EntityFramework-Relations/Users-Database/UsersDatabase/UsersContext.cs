namespace UsersDatabase
{
    using System;
    using System.Data.Entity;
    using UsersDatabase.Models;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersContext>());
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(configuration =>
                {
                    configuration.MapLeftKey("UserId");
                    configuration.MapRightKey("FriendId");
                    configuration.ToTable("UserFriends");
                    configuration.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}