using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Drawing;
using _2.UsersDatabase.Attributes;

namespace _2.UsersDatabase.Models
{
    public partial class User
    {
        [Key, Column]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, Password(4, 20, ShouldContainLowercase = true, ShouldContainUppercase = true, ShouldContainSpecialSymbol = true, ShouldContainDigit = false)]
        public string Password { get; set; }

        [Required, Email]
        public string Email { get; set; }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 126)]
        public int Age { get; set; }

        public bool isDeleted { get; set; }

        public Town BornTown { get; set; }

        public Town CurrentlyLivingTown { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}