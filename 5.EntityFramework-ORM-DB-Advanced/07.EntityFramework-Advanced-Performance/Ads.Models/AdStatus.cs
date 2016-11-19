namespace Ads.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdStatuses")]
    public partial class AdStatus
    {
        public AdStatus()
        {
            Ads = new HashSet<Ad>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
