namespace Ads.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Town
    {
        public Town()
        {
            Ads = new HashSet<Ad>();
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
