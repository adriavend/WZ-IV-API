using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WlZ.Products.Api.Data.Repositories.Interfaces;

namespace WlZ.Products.Api.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        internal DbSet<TEntity> DbSet;
        internal DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var types = entity.GetType();
            //types.GetProperty("CreationDate")?.SetValue(entity, DateTime.Now);
            //types.GetProperty("Id")?.SetValue(entity, 0);
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entityList)
        {
            DbSet.AddRange(entityList);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null
            , Func<IQueryable<TEntity>
            , IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> queryable = DbSet;

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            var properties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var prop in properties)
            {
                queryable = queryable.Include(prop);
            }

            if (orderBy != null)
            {
                return await orderBy(queryable).ToListAsync();
            }

            return await queryable.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void Remove(int id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
                
        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
