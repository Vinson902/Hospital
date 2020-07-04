using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
       public virtual ICollection<Patient> Patients { get; set; }//implement many to many
        public virtual ICollection<GP> GPs { get; set; } //implement many to many

    }
}
