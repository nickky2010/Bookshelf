using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        void AddAsync(T entity);
        void AddRangeAsync(ICollection<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(ICollection<T> entities);
        void Delete(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetLastItemAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> where);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetPageAsync(int startItem, int countItem);
    }
}
