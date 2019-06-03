using BLL.Interfaces;
using DAL.EF.Contexts;
using DAL.Interfaces;
using DAL.Repositories.EF;

namespace BLL.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public string ConnectionString { get; private set; }
        public UnitOfWorkService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IUnitOfWork<BookshelfContext> GetIUnitOfWorkBookshelfContext()
        {
            EFUnitOfWork<BookshelfContext> efUnitOfWork = new EFUnitOfWork<BookshelfContext>(new BookshelfContext(ConnectionString));
            return efUnitOfWork;
        }
    }
}
