using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5.HospitalDatabase.Models;

namespace _5.HospitalDatabase
{
    class Startup
    {
        static void Main()
        {
            HospitalContext context = new HospitalContext();

            context.Medicaments.Add(new Medicament {Name = "Paracetamol"});

            try
            {
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
