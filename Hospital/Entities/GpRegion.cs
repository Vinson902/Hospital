using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{/// <summary>
/// represents a cross reference table
/// </summary>
    public class GpRegion
    {/// <summary>
    /// Reference key(Region.Id)
    /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// an list of Regions to implement many to many relationship
        /// </summary>
        public List<Region> Regions { get; set; }
        /// <summary>
        /// Reference key(GP.Id)
        /// </summary>
        public int  GPId {get;set;}
        /// <summary>
        /// an list of GPs to implement many to many relationship
        /// </summary>
        public List<GP> GPs { get; set; }

    }
}
