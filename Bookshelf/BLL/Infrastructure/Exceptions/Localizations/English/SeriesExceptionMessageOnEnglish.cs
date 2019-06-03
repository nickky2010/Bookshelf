using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class SeriesExceptionMessageOnEnglish : ISeriesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Series after add not found!";

        public string NotFound => "Series not found!";

        public string NotFoundById(int id)
        {
            return $"Series with id { id } not found! Perhaps item with entered id does not exist!";
        }
        public string NotFoundByName(string name)
        {
            return $"Series {name} not found!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete series! Perhaps item with entered id { id } does not exist.";
        }
    }
}
