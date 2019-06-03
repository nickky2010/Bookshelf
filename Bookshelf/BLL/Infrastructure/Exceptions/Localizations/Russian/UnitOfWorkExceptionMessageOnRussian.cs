using BLL.Interfaces.Localizations.Exceptions;
using System;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class UnitOfWorkExceptionMessageOnRussian : IUnitOfWorkExceptionMessageLocalization
    {
        private Lazy<IAuthorsExceptionMessageLocalization> _authorsException;
        private Lazy<IBooksExceptionMessageLocalization> _booksException;
        private Lazy<IGenresExceptionMessageLocalization> _genresException;
        private Lazy<IBookGroupsExceptionMessageLocalization> _bookGroupsException;
        private Lazy<ILanguagesExceptionMessageLocalization> _languagesException;
        private Lazy<IPublishingHousesExceptionMessageLocalization> _publishingHousesException;
        private Lazy<ISeriesExceptionMessageLocalization> _seriesException;
        private Lazy<ITagsExceptionMessageLocalization> _tagsException;
        private Lazy<IUsersExceptionMessageLocalization> _usersException;
        private Lazy<IRolesExceptionMessageLocalization> _rolesException;
        private Lazy<IDataExceptionMessageLocalization> _dataException;
        private Lazy<IReportExceptionMessageLocalization> _reportException;
        private Lazy<IDbUpdateConcurrencyExceptionMessageLocalization> _dbUpdateConcurrencyException;

        public IAuthorsExceptionMessageLocalization AuthorsException
        {
            get
            {
                if (_authorsException == null)
                {
                    _authorsException = new Lazy<IAuthorsExceptionMessageLocalization>(new AuthorsExceptionMessageOnRussian());
                }
                return _authorsException.Value;
            }
        }

        public IBooksExceptionMessageLocalization BooksException
        {
            get
            {
                if (_booksException == null)
                {
                    _booksException = new Lazy<IBooksExceptionMessageLocalization>(new BooksExceptionMessageOnRussian());
                }
                return _booksException.Value;
            }
        }

        public IGenresExceptionMessageLocalization GenresException
        {
            get
            {
                if (_genresException == null)
                {
                    _genresException = new Lazy<IGenresExceptionMessageLocalization>(new GenresExceptionMessageOnRussian());
                }
                return _genresException.Value;
            }
        }
        
        public ITagsExceptionMessageLocalization TagsException
        {
            get
            {
                if (_tagsException == null)
                {
                    _tagsException = new Lazy<ITagsExceptionMessageLocalization>(new TagsExceptionMessageOnRussian());
                }
                return _tagsException.Value;
            }
        }
        
        public IUsersExceptionMessageLocalization UsersException
        {
            get
            {
                if (_usersException == null)
                {
                    _usersException = new Lazy<IUsersExceptionMessageLocalization>(new UsersExceptionMessageOnRussian());
                }
                return _usersException.Value;
            }
        }

        public IRolesExceptionMessageLocalization RolesException
        {
            get
            {
                if (_rolesException == null)
                {
                    _rolesException = new Lazy<IRolesExceptionMessageLocalization>(new RolesExceptionMessageOnRussian());
                }
                return _rolesException.Value;
            }
        }
        public IBookGroupsExceptionMessageLocalization BookGroupsException
        {
            get
            {
                if (_bookGroupsException == null)
                {
                    _bookGroupsException = new Lazy<IBookGroupsExceptionMessageLocalization>(new BookGroupsExceptionMessageOnRussian());
                }
                return _bookGroupsException.Value;
            }
        }

        public ILanguagesExceptionMessageLocalization LanguagesException
        {
            get
            {
                if (_languagesException == null)
                {
                    _languagesException = new Lazy<ILanguagesExceptionMessageLocalization>(new LanguagesExceptionMessageOnRussian());
                }
                return _languagesException.Value;
            }
        }

        public IPublishingHousesExceptionMessageLocalization PublishingHousesException
        {
            get
            {
                if (_publishingHousesException == null)
                {
                    _publishingHousesException = new Lazy<IPublishingHousesExceptionMessageLocalization>(new PublishingHousesExceptionMessageOnRussian());
                }
                return _publishingHousesException.Value;
            }
        }

        public ISeriesExceptionMessageLocalization SeriesException
        {
            get
            {
                if (_seriesException == null)
                {
                    _seriesException = new Lazy<ISeriesExceptionMessageLocalization>(new SeriesExceptionMessageOnRussian());
                }
                return _seriesException.Value;
            }
        }
        public IDataExceptionMessageLocalization DataException
        {
            get
            {
                if (_dataException == null)
                {
                    _dataException = new Lazy<IDataExceptionMessageLocalization>(new DataExceptionMessageOnRussian());
                }
                return _dataException.Value;
            }
        }

        public IReportExceptionMessageLocalization ReportException
        {
            get
            {
                if (_reportException == null)
                {
                    _reportException = new Lazy<IReportExceptionMessageLocalization>(new ReportExceptionMessageOnRussian());
                }
                return _reportException.Value;
            }
        }
        public IDbUpdateConcurrencyExceptionMessageLocalization DbUpdateConcurrencyException
        {
            get
            {
                if (_dbUpdateConcurrencyException == null)
                {
                    _dbUpdateConcurrencyException = new Lazy<IDbUpdateConcurrencyExceptionMessageLocalization>(new DbUpdateConcurrencyExceptionMessageOnRussian());
                }
                return _dbUpdateConcurrencyException.Value;
            }
        }
    }
}
