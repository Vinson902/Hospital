using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
