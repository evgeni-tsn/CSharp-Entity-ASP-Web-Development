using System;
using System.ComponentModel.DataAnnotations;

namespace _5.HospitalDatabase.Models
{
    public class Visitation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}