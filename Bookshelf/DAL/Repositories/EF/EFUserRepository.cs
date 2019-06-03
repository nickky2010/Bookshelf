using DAL.Interfaces;
using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.EF
{
    public class EFUserRepository : IRepository<User>
    {
        protected DbContext _context;
        private DbSet<User> _dbSet;

        public EFUserRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }
        public void AddAsync(User entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<User> books)
        {
            _dbSet.AddRangeAsync(books);
        }

        public void Update(User entity)
        {
            _context.Update(entity);
        }

        public void Delete(User entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<User> books)
        {
            _dbSet.RemoveRange(books);
        }

        public void Delete(Expression<Func<User, bool>> where)
        {
            IEnumerable<User> objects = _dbSet.Where<User>(where).AsEnumerable();
            foreach (User obj in objects)
                _dbSet.Remove(obj);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> where)
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Role)
                .FirstOrDefaultAsync(where);
        }

        public Task<User> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Role)
                .LastOrDefaultAsync();
        }
        public async Task<ICollection<User>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Role)
                .Skip(startItem - 1)
                .Take(countItem)
                .ToListAsync();
        }

        public async Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> where)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Role)
                .Where(where)
                .ToListAsync();
        }
        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Role)
                .ToListAsync();
        }
    }
}
