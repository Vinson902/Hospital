using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public interface IPatientRepository : ICanAddEntity<Patient>, ICanUpdateEntity<Patient>, ICanGetEntity<Patient>
    {
        public IReadOnlyList<Patient> GetPatientsByGpSurname(string surname);
        public IReadOnlyList<Patient> GetPatientsByRegionName(string name);
    }
}
