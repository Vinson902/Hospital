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
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        /// <summary>
        /// an list of Regions to implement many to many relationship
        /// </summary>
        public Region Region { get; set; }
        /// <summary>
        /// Reference key(GP.Id)
        /// </summary>
        [ForeignKey("GP")]
        public int  GPId {get;set;}
        /// <summary>
        /// an list of GPs to implement many to many relationship
        /// </summary>
        public GP GP { get; set; }

    }
}
