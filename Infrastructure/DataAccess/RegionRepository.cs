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


        public IReadOnlyList<Region> GetRegionsByGpSurnane(string surname)
        {
            var region = from s in DbContext.Patients where s.Surname == surname select s.Region;
            /*(from gp in DbContext.GPs
                    where gp.GpRegions.Any(r => r.Region == region.First())
                    select gp).ToList();*/
            var gp = from s in DbContext.GPs where s.Surname.ToLower().Contains(surname.ToLower()) select s;
            return (from rg in DbContext.Regions
                   where rg.GPRegions.Any(g => g.GP.Equals(gp.SingleOrDefault()))select rg).ToList();
        }
    }
}
