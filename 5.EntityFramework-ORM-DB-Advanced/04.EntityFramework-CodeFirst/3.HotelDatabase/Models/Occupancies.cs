using System;
using System.ComponentModel.DataAnnotations;

namespace _3.HotelDatabase.Models
{
    public class Occupancies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOccupied { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public int AccountNumber { get; set; }

        [Range(typeof(decimal), "0", "1000")]
        public int RoomNumber { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public int RateApplied { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal PhoneCharge { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}