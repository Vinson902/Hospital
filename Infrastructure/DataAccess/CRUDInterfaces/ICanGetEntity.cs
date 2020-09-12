using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    interface ICanGetEntity<TEntity> where TEntity : Entity
    {
        void Get(TEntity entity);
    }
}
