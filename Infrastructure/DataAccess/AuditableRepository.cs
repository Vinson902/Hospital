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

        public override void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            base.Add(entity);
             SaveChanges();
        }
        public override void Update(TEntity entityToUpdate)
        {
            entityToUpdate.UpdatedAt = DateTime.Now;    
            base.Update(entityToUpdate);
            SaveChanges();
        }
        public override void AddList(List<TEntity> entitiesList)
        {
            entitiesList.ForEach(e => e.CreatedAt = DateTime.Now);
            base.AddList(entitiesList);
            SaveChanges();
        }


    }
}
