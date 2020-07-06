using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{
    public class Patient : Inhabitant
    {
        public int InsuranceNumber { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public Patient(string Name, string Surname, string Middlename, int insuranceNumber) : base(Name,Surname,Middlename) {
            InsuranceNumber = insuranceNumber;
        }
        public Patient(string Name, string Surname, int insuranceNumber) : base(Name, Surname) {
            InsuranceNumber = insuranceNumber;
        }
    }
}
