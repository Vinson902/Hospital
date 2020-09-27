using Hospital.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess
{
    public class PatientRepository : AuditableRepository<Patient>, IPatientRepository 
    {
        public PatientRepository(AppDbContext dbContext) : base(dbContext) { }

        public IReadOnlyList<Patient> GetPatientsByGpSurname(string surname)
        {
            var gp = DbContext.GPs.Where(g => g.Surname.ToLower().Contains(surname.ToLower())).FirstOrDefault();
            var patients = 
                from r in DbContext.Regions
                from pa in dbSet
                     where r.GPRegions.Any(g => g.GP.Equals(gp))
                     where pa.Region.Equals(r)
                        select pa;
            return patients.ToList();
        }

        public IReadOnlyList<Patient> GetPatientsByRegionName(string name)
        {

            return DbContext.Patients.Where(e => e.Region.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        
    }
}
