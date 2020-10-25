using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
   
    public class Repository<TEntity>  where TEntity : AuditableEntity
    {
        
        internal readonly AppDbContext DbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        public async virtual Task<TEntity> GetAsync(TEntity entity)
        {
            return await dbSet.FindAsync(entity);
        }
        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async virtual Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public virtual void AddList(List<TEntity> entitiesList)
        {
            dbSet.AddRange(entitiesList);
        }
        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
        params object[] parameters)
        {
            if (query.ToLower().StartsWith("select"))
            {
                var set =  dbSet.FromSqlRaw(query, parameters);

                return set;
            }
            throw new ArgumentException("Select only");
        }
        public virtual void Remove(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }

        public virtual void RemoveById(object id)
        {
            dbSet.Remove(dbSet.Find(id));

        }
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
        }
        public virtual void SaveChanges()
        {
           DbContext.SaveChanges();
        }
    }
}
