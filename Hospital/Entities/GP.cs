using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public class GP : Doctor
    {
        public virtual ICollection<Region> Regions { get; set; } //implement many to many
        public GP(string Name, string surname, string middlename, Interval work_time, ICollection<Region> Regions) : base(Name,surname, middlename, work_time) 
        {
            this.Regions = Regions;
        }
        public GP(string name, string surname, Interval work_time, ICollection<Region> Regions) : base(name, surname, work_time) 
        {
            this.Regions = Regions;
        }
    }
}
