using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class AuthorsExceptionMessageOnEnglish : IAuthorsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Author after add not found!";

        public string NotFound => "Author not found!";

        public string NotFoundById(int id)
        {
            return $"Author with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete author! Perhaps item with entered id { id } does not exist.";
        }
    }
}
