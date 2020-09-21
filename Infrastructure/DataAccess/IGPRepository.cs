using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    interface IGPRepository : ICanGetEntity<GP>,ICanUpdateEntity<GP>,ICanAddEntity<GP>
    {
        public IReadOnlyList<GP> GetGpsByRegion(string name);
        public IReadOnlyList<GP> GetGPsByPatient(string name);

    }
}
