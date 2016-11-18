namespace Ads.Data
{
    using System.Data.Entity;
    using Ads.Models;

    public partial class AdsContext : DbContext
    {
        public AdsContext()
            : base("name=AdsContext")
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<AdStatus> AdStatuses { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdStatus>()
                .HasMany(e => e.Ads)
                .WithRequired(e => e.AdStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Ads)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.OwnerId);
        }
    }
}
