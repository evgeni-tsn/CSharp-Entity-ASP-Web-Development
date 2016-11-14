using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4.SalesDatabase.Models
{
    public class StoreLocation
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string LocationName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}