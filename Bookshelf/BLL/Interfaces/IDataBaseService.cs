using BLL.Interfaces.Localizations.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDataBaseService<TDTO> 
        where TDTO : class
    {
        IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; }
        Task<TDTO> AddAsync(IEntityDTO entity);
        Task<TDTO> UpdateAsync(IEntityDTO entity);
        Task<bool> DeleteAsync(int id);
        Task<TDTO> GetAsync(int id);
        Task<ICollection<TDTO>> GetPageAsync(int startItem, int countItem);
    }
}
