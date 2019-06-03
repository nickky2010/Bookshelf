using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class BooksExceptionMessageOnEnglish: IBooksExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Book after add not found!";

        public string NotFound => "Book not found!";

        public string NotFoundById(int id)
        {
            return $"Book with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete book! Perhaps item with entered id { id } does not exist.";
        }

    }
}
