using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class GenresExceptionMessageOnEnglish : IGenresExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Genre after add not found!";

        public string NotFound => "Genre not found!";

        public string NotFoundById(int id)
        {
            return $"Genre with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete genre! Perhaps item with entered id { id } does not exist.";
        }
    }
}
