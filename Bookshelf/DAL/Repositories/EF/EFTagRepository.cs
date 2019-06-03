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
    public class EFTagRepository : IRepository<Tag>
    {
        protected DbContext _context;
        private DbSet<Tag> _dbSet;

        public EFTagRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Tag>();
        }
        public void AddAsync(Tag entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<Tag> books)
        {
            _dbSet.AddRangeAsync(books);
        }

        public void Update(Tag entity)
        {
            _context.Update(entity);
        }

        public void Delete(Tag entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Tag> books)
        {
            _dbSet.RemoveRange(books);
        }

        public void Delete(Expression<Func<Tag, bool>> where)
        {
            IEnumerable<Tag> objects = _dbSet.Where<Tag>(where).AsEnumerable();
            foreach (Tag obj in objects)
                _dbSet.Remove(obj);
        }

        public Task<Tag> GetAsync(Expression<Func<Tag, bool>> where)
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookTags)
                .FirstOrDefaultAsync(where);
        }

        public Task<Tag> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookTags)
                .LastOrDefaultAsync();
        }
        public async Task<ICollection<Tag>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookTags)
                .Skip(startItem - 1)
                .Take(countItem)
                .ToListAsync();
        }

        public async Task<ICollection<Tag>> GetAllAsync(Expression<Func<Tag, bool>> where)
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookTags)
                .Where(where)
                .ToListAsync();
        }
        public async Task<ICollection<Tag>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.BookTags)
                .ToListAsync();
        }
    }
}
