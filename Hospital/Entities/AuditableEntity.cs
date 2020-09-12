using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{/// <summary>
/// Basic class, represents two columns. 
/// CreatedAt - when the line was created
/// UpdatedAt - when the line was updated
/// </summary>
    public abstract class AuditableEntity : Entity
    {/// <summary>
    /// DataTime when line was created
    /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// DataTime when the line was updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
