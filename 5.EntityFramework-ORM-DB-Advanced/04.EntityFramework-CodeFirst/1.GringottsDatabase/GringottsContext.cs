using _1.GringottsDatabase.Models;

namespace _1.GringottsDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }
        public virtual DbSet<WizardDeposit> WizardDeposits { get; set; }
    }
}