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
    public class EFAuthorRepository : IRepository<Author>
    {
        protected DbContext _context;
        private DbSet<Author> _dbSet;

        public EFAuthorRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Author>();
        }
        public void AddAsync(Author entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<Author> books)
        {
            _dbSet.AddRangeAsync(books);
        }

        public void Update(Author entity)
        {
            _context.Update(entity);
        }

        public void Delete(Author entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Author> books)
        {
            _dbSet.RemoveRange(books);
        }

        public void Delete(Expression<Func<Author, bool>> where)
        {
            IEnumerable<Author> objects = _dbSet.Where<Author>(where).AsEnumerable();
            foreach (Author obj in objects)
                _dbSet.Remove(obj);
        }

        public Task<Author> GetAsync(Expression<Func<Author, bool>> where)
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookAuthors)
                .FirstOrDefaultAsync(where);
        }

        public Task<Author> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .LastOrDefaultAsync();
        }
        public async Task<ICollection<Author>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Skip(startItem - 1)
                .Take(countItem)
                .ToListAsync();
        }

        public async Task<ICollection<Author>> GetAllAsync(Expression<Func<Author, bool>> where)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookAuthors)
                .Where(where)
                .ToListAsync();
        }
        public async Task<ICollection<Author>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .ToListAsync();
        }
    }
}
