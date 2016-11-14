using System;
using System.Data.Entity.Validation;
using _1.GringottsDatabase.Models;

namespace _1.GringottsDatabase
{
    class Startup
    {
        static void Main()
        {
            var context = new GringottsContext();
            
            try
            {
                WizardDeposit deposit = new WizardDeposit
                {
                    Wizard = new Wizard
                    {
                        FirstName = "Albus",
                        LastName = "Dumbledore",
                        Age = 150
                    },
                    Deposit = new Deposit
                    {
                        Amount = 20000.24m,
                        Charge = 0.2m,
                        ExpirationDate = new DateTime(2020, 10, 20),
                        Interest = 34.3m,
                        StartDate = new DateTime(2016, 10, 20),
                        Group = "Slyderin",
                        IsDepositExpired = false
                    },
                    MagicWand = new MagicWand
                    {
                        Creator = "Antioch Peverell",
                        Size = 15,
                    }
                };


                context.WizardDeposits.Add(deposit);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}