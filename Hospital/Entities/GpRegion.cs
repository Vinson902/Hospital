using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Entities
{
    public class GpRegion
    {
        public int RegionId { get; set; }
        public List<Region> Regions { get; set; }
        public int  GPId {get;set;}
        public List<GP> GPs { get; set; }

    }
}
