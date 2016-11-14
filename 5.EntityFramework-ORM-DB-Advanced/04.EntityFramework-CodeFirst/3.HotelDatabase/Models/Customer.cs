using System.ComponentModel.DataAnnotations;

namespace _3.HotelDatabase.Models
{
    public class Customer
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required, MinLength(8), MaxLength(12)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string EmergencyName { get; set; }

        [MaxLength(12)]
        public string EmergencyNumber { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}