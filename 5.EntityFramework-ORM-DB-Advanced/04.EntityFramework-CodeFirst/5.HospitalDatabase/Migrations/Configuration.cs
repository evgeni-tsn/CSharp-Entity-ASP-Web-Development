namespace _5.HospitalDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_5.HospitalDatabase.HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_5.HospitalDatabase.HospitalContext context)
        {
           
        }
    }
}
