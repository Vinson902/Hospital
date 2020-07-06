using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id {get; set;}
    }
}
