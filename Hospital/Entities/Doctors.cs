using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public class Doctor : Inhabitant
    {
        public Interval Work_time { get; set; }

        public Doctor(string Name, string Surname, string Middlename, Interval Work_time ) : base(Name,Surname,Middlename)
        {
            this.Work_time = Work_time;
        }
        public Doctor(string Name, string Surname, Interval Work_time) : base(Name, Surname)
        {
            this.Work_time = Work_time;
        }
    }
}
