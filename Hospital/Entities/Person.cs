using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{/// <summary>
/// abstact class represents a person
/// </summary>
    public abstract class Person : AuditableEntity
    {/// <summary>
    /// Name
    /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Surname
        /// </summary>
        [Required]
        public string Surname { get; set; }
        /// <summary>
        /// Middlename is virtual because some people may don't have a middlename
        /// </summary>
        public virtual string Middlename { get; set; }
        /// <summary>
        /// initializes name, surname and middlename
        /// middlename can be null
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Middlename"></param>
        public Person(string Name, string Surname, string Middlename){
            this.Name = Name;
            this.Surname = Surname;
            if (!string.IsNullOrEmpty(Middlename))
            this.Middlename = Middlename;
        }
        public Person() { }

    }
}
