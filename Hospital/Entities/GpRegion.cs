using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{
    class GpRegion
    {
        public int RegionId { get; set; }
        [ForeignKey("Region")]
        public ICollection<Region> Regions { get; set; }
        public int  GPId {get;set;}
        [ForeignKey("GP")]
        public ICollection<GP> GPs { get; set; }

    }
}
