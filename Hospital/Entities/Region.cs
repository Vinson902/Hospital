using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{

  
    public class Region : AuditableEntity
    {
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }//implement one any to many
        public List<GP> GPs { get; set; } //implement many to many

    }
}
