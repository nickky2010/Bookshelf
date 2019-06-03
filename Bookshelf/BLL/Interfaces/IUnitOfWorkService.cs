using DAL.EF.Contexts;
using DAL.Interfaces;

namespace BLL.Interfaces
{
    public interface IUnitOfWorkService
    {
        IUnitOfWork<BookshelfContext> GetIUnitOfWorkBookshelfContext();
    }
}
