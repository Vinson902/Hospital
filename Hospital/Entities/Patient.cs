using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public class Patient : Inhabitant
    {   public int InsuranceNumber { get; set; }
        public Patient(string Name, string Surname, string Middlename, Region Region) : base(Name,Surname,Middlename, Region) { }
        public Patient(string Name, string Surname, Region Region) : base(Name, Surname, Region) { }
       

    }
}
