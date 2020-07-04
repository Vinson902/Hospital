using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public abstract class Inhabitant : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }

         //implement many to one
        


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
