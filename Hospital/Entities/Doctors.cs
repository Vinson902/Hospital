using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{
    /// <summary>
    /// represents a table in a "Hospital" database which stores doctors' full names and their working time 
    /// <c>Inherit class<see cref="Hospital.Entities.Person"/></c>
    /// </summary>
    public class Doctor : Person
    { /// <summary>
    /// It is an interval of time when a doctor works
    /// </summary>
        public TimeSpan Work_time { get; set; }
        /// <summary>
        /// <c> inherit constuctor</c> <see cref="Hospital.Entities.Person.Person(string, string, string)"/>
        /// <paramref name="Work_time"/>an interval of time when Doctor works
        /// <paramref name="Middlename"/>may be null
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Middlename"></param>
        /// <param name="Work_time"></param>
        public Doctor(string Name, string Surname, string Middlename, TimeSpan Work_time ) : base(Name,Surname,Middlename)
        {
            this.Work_time = Work_time;
        }
        //public Doctor(string Name, string Surname, TimeSpan Work_time) : base(Name, Surname)
        //{
        //    this.Work_time = Work_time;
        //}
    }
}
