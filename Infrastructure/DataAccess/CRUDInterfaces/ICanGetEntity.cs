using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanGetEntity<TEntity> where TEntity : Entity
    {
        TEntity Get(TEntity entity);
    }
}
