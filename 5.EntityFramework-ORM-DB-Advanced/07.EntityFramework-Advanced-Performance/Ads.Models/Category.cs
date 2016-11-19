namespace Ads.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Category
    {
        public Category()
        {
            Ads = new HashSet<Ad>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
