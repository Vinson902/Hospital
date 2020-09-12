using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Entities
{/// <summary>
/// Basic class, has primary key for each table
/// </summary>
    public abstract class Entity
    {/// <summary>
    /// primary key
    /// </summary>
    
        public int Id {get; set;}
    }
}
