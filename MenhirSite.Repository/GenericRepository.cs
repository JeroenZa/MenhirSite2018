using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : DeletableBaseModel
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly IDbSet<TEntity> DbSet;

        protected GenericRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable().ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = DbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return DbSet.Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            DbContext.SaveChanges();
        }

        public virtual void Reload(TEntity entity)
        {
            DbContext.Entry(entity).Reload();
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }
    }
}