using System.ComponentModel.DataAnnotations;

namespace _5.HospitalDatabase.Models
{
    public class Diagnose
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}