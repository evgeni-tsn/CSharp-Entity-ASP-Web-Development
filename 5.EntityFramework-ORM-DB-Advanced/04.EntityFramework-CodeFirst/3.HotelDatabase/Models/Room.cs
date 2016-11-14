using System.ComponentModel.DataAnnotations;

namespace _3.HotelDatabase.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public BedType BedType { get; set; }

        public int Rate { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}