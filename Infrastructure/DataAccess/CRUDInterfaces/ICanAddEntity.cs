using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Entities;

namespace Infrastructure.CRUDInterfaces
{
    interface ICanAddEntity<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
    }
}
