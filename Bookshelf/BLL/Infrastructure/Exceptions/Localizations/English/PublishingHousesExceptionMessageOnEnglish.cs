using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class PublishingHousesExceptionMessageOnEnglish : IPublishingHousesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Publishing house after add not found!";

        public string NotFound => "Publishing house not found!";

        public string NotFoundById(int id)
        {
            return $"Publishing house with id { id } not found! Perhaps item with entered id does not exist!";
        }
        public string NotFoundByName(string name)
        {
            return $"Publishing house {name} not found!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete publishing house! Perhaps item with entered id { id } does not exist.";
        }
    }
}
