using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class RegionRepository : AuditableRepository<Region>, IRegionRepository
    {


        public RegionRepository(AppDbContext appContext) : base(appContext)
        {

        }
       

      

        public Region GetRegionsByPatientsSurname(string surname)
        {
            var gp = DbContext.GPs.Where(x => x.Surname == surname).Single().Id;
            return DbContext.Regions.Where(x => x.GPRegions.Any(y => y.GPId == gp)).Single();
            
        }
    }
}
