using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.EF
{
    public class EFUnitOfWork<C> : IUnitOfWork<C> 
        where C : DbContext 
    {
        private readonly C _context;
        private Lazy<IRepository<Author>> _authorRepository;
        private Lazy<IRepository<Book>> _bookRepository;
        private Lazy<IRepository<Genre>> _genreRepository;
        private Lazy<IRepository<BookInformation>> _bookInformationRepository;
        private Lazy<IRepository<Language>> _languageRepository;
        private Lazy<IRepository<PublishingHouse>> _publishingHouseRepository;
        private Lazy<IRepository<Series>> _seriesRepository;
        private Lazy<IRepository<Tag>> _tagRepository;
        private Lazy<IRepository<BookAuthor>> _bookAuthorRepository;
        private Lazy<IRepository<BookGenre>> _bookGenreRepository;
        private Lazy<IRepository<BookGroup>> _bookGroupRepository;
        private Lazy<IRepository<BookTag>> _bookTagRepository;
        private Lazy<IRepository<User>> _userRepository;
        private Lazy<IRepository<Role>> _roleRepository;
        private bool disposed = false;

        public EFUnitOfWork(C context)
        {
            _context = context;
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new Lazy<IRepository<Author>>(new EFAuthorRepository(_context));
                }
                return _authorRepository.Value;
            }
        }
        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new Lazy<IRepository<Book>>(new EFBookRepository(_context));
                }
                return _bookRepository.Value;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new Lazy<IRepository<Genre>>(new EFGenreRepository(_context));
                }
                return _genreRepository.Value;
            }
        }
        public IRepository<BookInformation> BookInformation
        {
            get
            {
                if (_bookInformationRepository == null)
                {
                    _bookInformationRepository = new Lazy<IRepository<BookInformation>>(new EFRepository<BookInformation>(_context));
                }
                return _bookInformationRepository.Value;
            }
        }
        public IRepository<Language> Languages
        {
            get
            {
                if (_languageRepository == null)
                {
                    _languageRepository = new Lazy<IRepository<Language>>(new EFRepository<Language>(_context));
                }
                return _languageRepository.Value;
            }
        }
        public IRepository<PublishingHouse> PublishingHouses
        {
            get
            {
                if (_publishingHouseRepository == null)
                {
                    _publishingHouseRepository = new Lazy<IRepository<PublishingHouse>>(new EFRepository<PublishingHouse>(_context));
                }
                return _publishingHouseRepository.Value;
            }
        }
        public IRepository<Series> Series
        {
            get
            {
                if (_seriesRepository == null)
                {
                    _seriesRepository = new Lazy<IRepository<Series>>(new EFRepository<Series>(_context));
                }
                return _seriesRepository.Value;
            }
        }
        public IRepository<Tag> Tags
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new Lazy<IRepository<Tag>>(new EFTagRepository(_context));
                }
                return _tagRepository.Value;
            }
        }
        public IRepository<BookAuthor> BookAuthors
        {
            get
            {
                if (_bookAuthorRepository == null)
                {
                    _bookAuthorRepository = new Lazy<IRepository<BookAuthor>>(new EFRepository<BookAuthor>(_context));
                }
                return _bookAuthorRepository.Value;
            }
        }
        public IRepository<BookGenre> BookGenres
        {
            get
            {
                if (_bookGenreRepository == null)
                {
                    _bookGenreRepository = new Lazy<IRepository<BookGenre>>(new EFRepository<BookGenre>(_context));
                }
                return _bookGenreRepository.Value;
            }
        }
        public IRepository<BookGroup> BookGroups
        {
            get
            {
                if (_bookGroupRepository == null)
                {
                    _bookGroupRepository = new Lazy<IRepository<BookGroup>>(new EFRepository<BookGroup>(_context));
                }
                return _bookGroupRepository.Value;
            }
        }
        public IRepository<BookTag> BookTags
        {
            get
            {
                if (_bookTagRepository == null)
                {
                    _bookTagRepository = new Lazy<IRepository<BookTag>>(new EFRepository<BookTag>(_context));
                }
                return _bookTagRepository.Value;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Lazy<IRepository<User>>(new EFUserRepository(_context)); 
                }
                return _userRepository.Value;
            }
        }
        public IRepository<Role> Roles
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new Lazy<IRepository<Role>>(new EFRepository<Role>(_context));
                }
                return _roleRepository.Value;
            }
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
