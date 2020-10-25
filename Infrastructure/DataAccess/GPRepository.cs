using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class GPRepository : AuditableRepository<GP>, IGPRepository
    {
        public GPRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IReadOnlyList<GP>> GetGPsByPatientSurnameAsync(string surname)
        {
            var region = from s in DbContext.Patients where s.Surname == surname select s.Region;
            return await(from gp in DbContext.GPs
                   where gp.GpRegions.Any(r => r.Region == region.First())
                   select gp).ToListAsync();
        }
        public async Task<IReadOnlyList<GP>> GetGpsByRegionAsync(string name)
        {
            return await DbContext.GPs.Where(e => e.GpRegions.Single().Region.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}
