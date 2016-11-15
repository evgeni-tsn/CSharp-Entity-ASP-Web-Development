using System.ComponentModel.DataAnnotations;

namespace _5.HospitalDatabase.Models
{
    public class Medicament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public Patient Patient { get; set; }
    }
}