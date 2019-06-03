using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class BookGroupsExceptionMessageOnEnglish : IBookGroupsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Book group after add not found!";

        public string NotFound => "Book group not found!";

        public string NotFoundById(int id)
        {
            return $"Book group with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete book group! Perhaps item with entered id { id } does not exist.";
        }
    }
}
