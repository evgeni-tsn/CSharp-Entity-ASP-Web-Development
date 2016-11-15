using System.Collections.Generic;

namespace _5.HospitalDatabase.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }
        public ICollection<Visitation> Visitations { get; set; }
    }
}