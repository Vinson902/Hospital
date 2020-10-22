using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public interface IGPRepository : ICanGetEntity<GP>,ICanUpdateEntity<GP>,ICanAddEntity<GP>
    {
        public Task<IReadOnlyList<GP>> GetGpsByRegionAsync(string name);
        public Task<IReadOnlyList<GP>> GetGPsByPatientSurnameAsync(string surname);
        public Task<IReadOnlyList<GP>> GetAllAsync();

    }
}
