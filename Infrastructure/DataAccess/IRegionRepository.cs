using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public interface IRegionRepository : ICanAddEntity<Region>, ICanUpdateEntity<Region>, ICanGetEntity<Region>
    {
        public Task<Region> GetRegionsByPatientsSurnameAsync(string surname);
        public Task<IReadOnlyList<Region>> GetRegionsByGpSurnameAsync(string surname);
    }
}
