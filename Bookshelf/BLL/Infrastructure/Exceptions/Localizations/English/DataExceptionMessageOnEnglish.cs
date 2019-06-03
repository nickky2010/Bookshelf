using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class DataExceptionMessageOnEnglish : IDataExceptionMessageLocalization
    {
        public string NoData => "No data for item!";

        public string DataIsNotValid => "Data for item is not valid!";

        public string ItemIdleastOne => "Item Id must be at least 1!";

        public string CountItemsLeastOne => "Count items must be at least 1!";

        public string StartItemNotExist(int position)
        {
            return $"Start item with number { position } does not exist";
        }
    }
}
