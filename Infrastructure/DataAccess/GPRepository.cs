using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class GPRepository : AuditableRepository<GP>, IGPRepository
    {
        public GPRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public IReadOnlyList<GP> GetGPsByPatient(string surname)
        {
            var region = from s in DbContext.Patients where s.Surname == surname select s.Region;
            return (from gp in DbContext.GPs
                   where gp.GpRegions.Any(r => r.Region == region.First())
                   select gp).ToList();
        }


        public IReadOnlyList<GP> GetGpsByRegion(string name)
        {
            return DbContext.GPs.Where(e => e.GpRegions.Single().Region.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
