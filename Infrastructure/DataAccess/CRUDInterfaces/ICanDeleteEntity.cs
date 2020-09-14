using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    interface ICanDeleteEntity<TEntity> where TEntity : Entity
    {
        void Remove(TEntity entity);
    }
}
