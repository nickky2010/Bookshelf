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
    public class EFBookRepository : IRepository<Book>
    {
        protected DbContext _context;
        private DbSet<Book> _dbSet;

        public EFBookRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Book>();
        }
        public void AddAsync(Book entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRangeAsync(ICollection<Book> books)
        {
            _dbSet.AddRangeAsync(books);
        }

        public void Update(Book entity)
        {
            _context.Update(entity);
        }

        public void Delete(Book entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Book> books)
        {
            _dbSet.RemoveRange(books);
        }

        public void Delete(Expression<Func<Book, bool>> where)
        {
            IEnumerable<Book> objects = _dbSet.Where<Book>(where).AsEnumerable();
            foreach (Book obj in objects)
                _dbSet.Remove(obj);
        }

        public Task<Book> GetAsync(Expression<Func<Book, bool>> where)
        {
            return _dbSet.AsNoTracking().AsQueryable()
                .Include(b => b.Language)
                .Include(b => b.BookInformation)
                .Include(b => b.PublishingHouse)
                .Include(b => b.Series)
                .Include(b => b.BookGroup)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(b => b.BookGenres).ThenInclude(g => g.Genre)
                .Include(b => b.BookTags).ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync(where);
        }

        public Task<Book> GetLastItemAsync()
        {
            return _dbSet.AsNoTracking().AsQueryable()
                .Include(b => b.Language)
                .Include(b => b.BookInformation)
                .Include(b => b.PublishingHouse)
                .Include(b => b.Series)
                .Include(b => b.BookGroup)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(b => b.BookGenres).ThenInclude(g => g.Genre)
                .Include(b => b.BookTags).ThenInclude(t => t.Tag)
                .LastOrDefaultAsync();
        }
        public async Task<ICollection<Book>> GetPageAsync(int startItem, int countItem)
        {
            return await _dbSet.AsNoTracking().AsQueryable().Skip(startItem - 1).Take(countItem)
                .Include(b => b.Language)
                .Include(b => b.BookInformation)
                .Include(b => b.PublishingHouse)
                .Include(b => b.Series)
                .Include(b => b.BookGroup)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(b => b.BookGenres).ThenInclude(g=>g.Genre)
                .Include(b => b.BookTags).ThenInclude(t => t.Tag)
                .ToListAsync();
        }

        public async Task<ICollection<Book>> GetAllAsync(Expression<Func<Book, bool>> where)
        {
            return await _dbSet.AsNoTracking().AsQueryable().Where(where)
                .Include(b => b.Language)
                .Include(b => b.BookInformation)
                .Include(b => b.PublishingHouse)
                .Include(b => b.Series)
                .Include(b => b.BookGroup)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(b => b.BookGenres).ThenInclude(g => g.Genre)
                .Include(b => b.BookTags).ThenInclude(t => t.Tag)
                .ToListAsync();
        }
        public async Task<ICollection<Book>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().AsQueryable()
                .Include(b => b.Language)
                .Include(b => b.BookInformation)
                .Include(b => b.PublishingHouse)
                .Include(b => b.Series)
                .Include(b => b.BookGroup)
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(b => b.BookGenres).ThenInclude(g => g.Genre)
                .Include(b => b.BookTags).ThenInclude(t => t.Tag)
                .ToListAsync();
        }
    }
}
