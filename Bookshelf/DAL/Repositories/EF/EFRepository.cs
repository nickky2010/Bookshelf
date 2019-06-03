using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.EF
{
    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        protected DbContext _context;
        private DbSet<T> _dbSet;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<T> entities)
        {
            _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }
        public Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return _dbSet.AsNoTracking().AsQueryable().FirstOrDefaultAsync(where);
        }
        public Task<T> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking().AsQueryable().LastOrDefaultAsync();
        }
        public async Task<ICollection<T>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking().AsQueryable().Skip(startItem - 1).Take(countItem).ToListAsync();
        }
        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AsNoTracking().AsQueryable().Where(where).ToListAsync();
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().AsQueryable().ToListAsync();
        }
    }
}
