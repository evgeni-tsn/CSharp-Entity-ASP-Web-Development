using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.GringottsDatabase.Models
{
    [Table("WizzardDeposits")]
    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        public Wizard Wizard { get; set; }

        public MagicWand MagicWand { get; set; }

        public Deposit Deposit { get; set; }

//        [MaxLength(50)]
//        public string FirstName { get; set; }
//
//        [MaxLength(60)]
//        [Required]
//        public string LastName { get; set; }
//
//        [MaxLength(1000)]
//        public string Notes { get; set; }
//
//        [Required]
//        public uint Age { get; set; }

//        [MaxLength(100)]
//        public string MagicWandCreator { get; set; }
//
//        public int MagicWandSize { get; set; }

//        [MaxLength(20)]
//        public string DepositGroup { get; set; }
//
//        public DateTime DepositStartDate { get; set; }
//
//        public decimal DepositAmount { get; set; }
//
//        public double DepositInterest { get; set; }
//
//        public double DepositCharge { get; set; }
//
//        public DateTime DepositExpirationDate { get; set; }
//
//        public bool IsDepositExpired { get; set; }
    }
}