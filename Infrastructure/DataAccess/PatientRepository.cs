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
            var rg = from r in DbContext.Regions
                      where r.GPRegions.Any(g => g.GP.Equals(gp))
                      select r;
            return DbContext.Patients.Where(p => p.Equals(rg)).ToList();
        }

        public IReadOnlyList<Patient> GetPatientsByRegionName(string name)
        {

            return DbContext.Patients.Where(e => e.Region.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        
    }
}
