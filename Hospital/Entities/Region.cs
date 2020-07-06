using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{

    /*TODO
     to Add:
    number of inhabitants
    collection of inhabitants
     */
    public class Region : AuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [ForeignKey("Patient")]
        public virtual ICollection<Patient> Patients { get; set; }//implement many to many
        [ForeignKey("GP")]
        public virtual ICollection<GP> GPs { get; set; } //implement many to many

    }
}
