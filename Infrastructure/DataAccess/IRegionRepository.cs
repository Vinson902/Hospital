using Hospital.Entities;
using Infrastructure.CRUDInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public interface IRegionRepository : ICanAddEntity<Region>, ICanUpdateEntity<Region>, ICanGetEntity<Region>
    {
        public Region GetRegionsByPatientsSurname(string surname);
    }
}
