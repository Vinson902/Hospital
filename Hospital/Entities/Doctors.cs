using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{
    public class Doctor : Inhabitant
    {
        [Required]
        public TimeSpan Work_time { get; set; }

        public Doctor(string Name, string Surname, string Middlename, TimeSpan Work_time ) : base(Name,Surname,Middlename)
        {
            this.Work_time = Work_time;
        }
        public Doctor(string Name, string Surname, TimeSpan Work_time) : base(Name, Surname)
        {
            this.Work_time = Work_time;
        }
    }
}
