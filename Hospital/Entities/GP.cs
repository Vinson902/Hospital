using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public class GP : Doctor
    {
        public List<GpRegion> GpRegions { get; set; } //implement many to many
        public GP(string Name, string surname, string middlename, TimeSpan work_time) : base(Name,surname, middlename, work_time) 
        {
            GpRegions = new List<GpRegion>();
        }   
        public GP(string name, string surname, TimeSpan work_time) : base(name, surname, work_time) 
        {
            GpRegions = new List<GpRegion>();
        }
    }
}
