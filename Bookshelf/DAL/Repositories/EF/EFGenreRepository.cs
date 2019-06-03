using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.EF
{
    public class EFGenreRepository : IRepository<Genre>
    {
        protected DbContext _context;
        private DbSet<Genre> _dbSet;

        public EFGenreRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Genre>();
        }
        public void AddAsync(Genre entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<Genre> books)
        {
            _dbSet.AddRangeAsync(books);
        }

        public void Update(Genre entity)
        {
            _context.Update(entity);
        }

        public void Delete(Genre entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Genre> books)
        {
            _dbSet.RemoveRange(books);
        }

        public void Delete(Expression<Func<Genre, bool>> where)
        {
            IEnumerable<Genre> objects = _dbSet.Where<Genre>(where).AsEnumerable();
            foreach (Genre obj in objects)
                _dbSet.Remove(obj);
        }

        public Task<Genre> GetAsync(Expression<Func<Genre, bool>> where)
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookGenres)
                .FirstOrDefaultAsync(where);
        }

        public Task<Genre> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookGenres)
                .LastOrDefaultAsync();
        }
        public async Task<ICollection<Genre>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookGenres)
                .Skip(startItem - 1)
                .Take(countItem)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllAsync(Expression<Func<Genre, bool>> where)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookGenres)
                .Where(where)
                .ToListAsync();
        }
        public async Task<ICollection<Genre>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookGenres)
                .ToListAsync();
        }
    }
}
