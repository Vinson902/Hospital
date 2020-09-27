using Hospital.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess
{
    public class RegionRepository : AuditableRepository<Region>, IRegionRepository
    {


        public RegionRepository(AppDbContext appContext) : base(appContext)
        {

        }




        public Region GetRegionsByPatientsSurname(string surname)
        {
            var patient = DbContext.Patients.Where(x => x.Surname == surname).Single().Id;
            return DbContext.Regions.Where(x => x.Patients.Any(x => x.Id == patient)).SingleOrDefault();
        }


        public IReadOnlyList<Region> GetRegionsByGpSurnane(string surname)
        {
            var region = from s in DbContext.Patients where s.Surname == surname select s.Region;

            var gp = from s in DbContext.GPs where s.Surname.ToLower().Contains(surname.ToLower()) select s;
            return (from rg in DbContext.Regions
                   where rg.GPRegions.Any(g => g.GP.Equals(gp.SingleOrDefault()))select rg).ToList();
        }
    }
}
