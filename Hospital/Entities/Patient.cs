using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{/// 
 ///<summary>
    /// represents a patient table in a database "Hospital"
    /// <c> inherit class</c> <see cref="Hospital.Entities.Person"/>
    /// </summary>
    public class Patient : Person
    {
        [NotMapped]
        private string _InsuranceNumber;
        /// <summary>
        /// represents a unique 10-digit insurance number
        /// </summary>
        
        public string InsuranceNumber { 
            get { return _InsuranceNumber; } 
            set {
                
                if (value.Length == 10)
                   _InsuranceNumber = value;
                else
                    throw new ArgumentException("Insurance number should be a ten-digit number");
            }
        }
        /// <summary>
        /// A reference key to<see cref="Hospital.Entities.Region"/>
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// implements one-to-many with <see cref="Hospital.Entities.Region"/>
        /// </summary>
        public Region Region { get; set; }
        /// <summary>
        /// <c> inherit constuctor</c> <see cref="Hospital.Entities.Person.Person(string, string, string)"/>
        /// <paramref name="Middlename"/>may be null
        /// <paramref name="insuranceNumber"/> should be a 10-digit number
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Middlename"></param>
        /// <param name="insuranceNumber"></param>
        
        public Patient(string Name, string Surname, string Middlename, string insuranceNumber) : base(Name,Surname,Middlename) {
            InsuranceNumber = insuranceNumber;
        }
        //public Patient(string Name, string Surname, int insuranceNumber) : base(Name, Surname) {
        //    InsuranceNumber = insuranceNumber;
        //}
        public Patient() { }
    }
}
