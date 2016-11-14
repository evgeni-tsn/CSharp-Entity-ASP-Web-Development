using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.GringottsDatabase.Models
{
    [ComplexType]
    public class MagicWand
    {
        [MaxLength(100)]
        public string Creator { get; set; }

        [Range(0, short.MaxValue)]
        public int Size { get; set; }
    }
}