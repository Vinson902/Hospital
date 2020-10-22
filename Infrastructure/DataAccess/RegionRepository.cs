using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class RegionRepository : AuditableRepository<Region>, IRegionRepository
    {


        public RegionRepository(AppDbContext appContext) : base(appContext)
        {

        }




        public async Task<Region> GetRegionsByPatientsSurnameAsync(string surname)
        {
            var patient = DbContext.Patients.Where(x => x.Surname == surname).Single().Id;
            return await DbContext.Regions.Where(x => x.Patients.Any(x => x.Id == patient)).FirstOrDefaultAsync();
        }


        public async Task<IReadOnlyList<Region>> GetRegionsByGpSurnaneAsync(string surname)
        {
            var region = from s in DbContext.Patients where s.Surname == surname select s.Region;

            var gp = from s in DbContext.GPs where s.Surname.ToLower().Contains(surname.ToLower()) select s;
            return await (from rg in DbContext.Regions
                   where rg.GPRegions.Any(g => g.GP.Equals(gp.SingleOrDefault()))select rg).ToListAsync();
        }
    }
}
