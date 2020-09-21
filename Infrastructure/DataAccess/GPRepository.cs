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
            var region = (from s in DbContext.Patients where s.Surname == surname select s.Region).FirstOrDefault();
            if (region == null)
                throw new Exception("region is null");
            var gps = DbContext.GPs.Where(e => e.GpRegions.Single().Region.Equals(region)).ToList();
            if (gps == null)
                throw new Exception("gps is null");

            return gps;
        }


        public IReadOnlyList<GP> GetGpsByRegion(string name)
        {
            throw new NotImplementedException();
        }
    }
}
