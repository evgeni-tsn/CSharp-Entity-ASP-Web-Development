namespace MassDefect.Data
{
    using System.Data.Entity;
    using Models;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

         public virtual DbSet<Star> Stars { get; set; }

         public virtual DbSet<SolarSystem> SolarSystems { get; set; }

         public virtual DbSet<Planet> Planets { get; set; }

         public virtual DbSet<Person> Persons { get; set; }

         public virtual DbSet<Anomaly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
            .HasMany(p => p.Anomalies)
            .WithMany(r => r.Persons)
            .Map(mc =>
            {
                mc.MapLeftKey("PersonId");
                mc.MapRightKey("AnomalyId");
                mc.ToTable("AnomalyVictims");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}