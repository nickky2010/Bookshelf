using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class LanguagesExceptionMessageOnEnglish : ILanguagesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Language after add not found!";

        public string NotFound => "Language not found!";

        public string NotFoundById(int id)
        {
            return $"Language with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string NotFoundByName(string name)
        {
            return $"Language {name} not found!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete language! Perhaps item with entered id { id } does not exist.";
        }
    }
}
