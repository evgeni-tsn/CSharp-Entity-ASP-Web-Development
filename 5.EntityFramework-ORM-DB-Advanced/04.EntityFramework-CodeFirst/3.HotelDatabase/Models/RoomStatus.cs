using System.ComponentModel.DataAnnotations;

namespace _3.HotelDatabase.Models
{
    public enum RoomStatuses
    {
        Occupied, Free, BeingCleaned
    }

    public class RoomStatus
    {
        [Key]
        public RoomStatuses Status { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}