namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Anomaly
    {
        public Anomaly()
        {
            this.Persons = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }
        
        public virtual Planet OriginPlanet { get; set; }
        
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}