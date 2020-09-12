using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{/// <summary>
/// <c>inherits <see cref="Hospital.Entities.Doctor"/></c>
/// represents a table in a "Hospital" database
/// </summary>
    public class GP : Doctor
    {
        /// <summary>
        /// represents a list of cross reference table <see cref="Hospital.Entities.GpRegion"/>
        /// Gp can't be existed without region
        /// implement many to many
        /// </summary>
        public List<GpRegion> GpRegions { get; set; }
        /// <summary>
        /// <c> inherit constuctor</c> <see cref="Hospital.Entities.Person.Person(string, string, string)"/>
        /// <paramref name="work_time"></paramref>
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="surname"></param>
        /// <param name="middlename"></param>
        /// <param name="work_time">an interval of time when gp works</param>
        public GP(string Name, string surname, string middlename, TimeSpan work_time) : base(Name,surname, middlename, work_time) 
        {
            GpRegions = new List<GpRegion>();
        }   
        //public GP(string name, string surname, TimeSpan work_time) : base(name, surname, work_time) 
        //{
        //    GpRegions = new List<GpRegion>();
        //}
    }
}
