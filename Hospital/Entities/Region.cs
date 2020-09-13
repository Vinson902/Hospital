using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{
    /// <summary>
    ///represents a table in a database "Region"
    ///<c>inherits basic class <see cref="Hospital.Entities.AuditableEntity"/></c>
    /// </summary>
    public class Region : AuditableEntity
    {/// <summary>
     /// the name of a region
     /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// a list patients who live in this region
        /// implement one to many relationship
        /// a region can be existed without patients
        /// </summary>
        public virtual List<Patient> Patients { get; set; }
        /// <summary>
        /// a list doctors (general practise) who heal patients in this region
        ///implement many any to many relationship
        ///a region can be existed without GP
        /// </summary>
        public virtual List<GpRegion> GPRegions { get; set; } //implement many to many and aggregation

    }
}
