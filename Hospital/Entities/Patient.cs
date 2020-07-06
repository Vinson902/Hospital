using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{
    public class Patient : Inhabitant
    {
        [Required]
        public int InsuranceNumber { get; set; }
        [ForeignKey("Region")]
        public virtual Region Region { get; set; }
        public Patient(string Name, string Surname, string Middlename, Region Region) : base(Name,Surname,Middlename) {
            this.Region = Region;
        }
        public Patient(string Name, string Surname, Region Region) : base(Name, Surname) {
            this.Region = Region;
        }
       

    }
}
