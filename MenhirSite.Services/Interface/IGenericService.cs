using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MenhirSite.Model;

namespace MenhirSite.Services.Interface
{
    public interface IGenericService<T> : IService where T : DeletableBaseModel
    {
        int Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        int Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}