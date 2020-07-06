using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{
    public abstract class Inhabitant : AuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Middlename { get; set; }
        


        public Inhabitant(string Name, string Surname, string Middlename) {
            this.Name = Name;
            this.Surname = Surname;
            this.Middlename = Middlename;
           
        }
        public Inhabitant(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
           
        }

    }
}
