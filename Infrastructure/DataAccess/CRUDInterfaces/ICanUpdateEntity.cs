using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    interface ICanUpdateEntity<TEntity> where TEntity : Entity
    {
        void Update(TEntity entity);
    }
}
