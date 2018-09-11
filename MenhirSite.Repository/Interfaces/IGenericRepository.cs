using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MenhirSite.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
        void Reload(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}