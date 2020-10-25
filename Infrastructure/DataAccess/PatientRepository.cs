using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class PatientRepository : AuditableRepository<Patient>, IPatientRepository 
    {
        public PatientRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Patient>> GetPatientsByGpSurnameAsync(string surname)
        {
            var gp = DbContext.GPs.Where(g => g.Surname.ToLower().Contains(surname.ToLower())).FirstOrDefault();
            var patients = 
                from r in DbContext.Regions
                from pa in dbSet
                     where r.GPRegions.Any(g => g.GP.Equals(gp))
                     where pa.Region.Equals(r)
                        select pa;
            return await patients.ToListAsync();
        }

        public async Task<IReadOnlyList<Patient>> GetPatientsByRegionNameAsync(string name)
        {
            return await DbContext.Patients.Where(e => e.Region.Name.ToLower().Contains(name.ToLower())).Include(e =>e.Region.Name).ToListAsync();
        }

    }   
}
