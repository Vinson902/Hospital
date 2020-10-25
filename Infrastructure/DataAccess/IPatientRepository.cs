using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public interface IPatientRepository : ICanAddEntity<Patient>, ICanUpdateEntity<Patient>, ICanGetEntity<Patient>
    {
        public Task<IReadOnlyList<Patient>> GetPatientsByGpSurnameAsync(string surname);
        public Task<IReadOnlyList<Patient>> GetPatientsByRegionNameAsync(string name);
    }
}
