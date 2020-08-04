using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entityList);

        void Remove(T entity);

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetById(int id);

        void Update(T entity);

        Task<int> SaveChangesAsync();
    }
}
