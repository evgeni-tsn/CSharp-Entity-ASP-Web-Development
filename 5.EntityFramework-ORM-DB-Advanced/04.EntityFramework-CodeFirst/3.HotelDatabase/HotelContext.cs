using _3.HotelDatabase.Models;

namespace _3.HotelDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=HotelContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomStatus> RoomStatuses { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<BedType> BedTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Occupancies> Occupancieses { get; set; }
    }
}