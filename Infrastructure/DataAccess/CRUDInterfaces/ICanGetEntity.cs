using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CRUDInterfaces
{
    public interface ICanGetEntity<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();

    }
}
