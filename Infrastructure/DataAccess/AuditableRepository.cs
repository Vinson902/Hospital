using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public abstract class AuditableRepository<TEntity> : Repository<TEntity>
         where TEntity : Hospital.Entities.AuditableEntity
    {
        public AuditableRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async override void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            base.Add(entity);
            await SaveChangesAsync();
        }
        public async override void Update(TEntity entityToUpdate)
        {
            entityToUpdate.UpdatedAt = DateTime.Now;
            base.Update(entityToUpdate);
            await SaveChangesAsync();
        }
        public async override void AddList(List<TEntity> entitiesList)
        {
            entitiesList.ForEach(e => e.CreatedAt = DateTime.Now);
            base.AddList(entitiesList);
            await SaveChangesAsync();
        }


    }
}
