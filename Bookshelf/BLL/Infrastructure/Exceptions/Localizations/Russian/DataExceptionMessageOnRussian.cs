using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class DataExceptionMessageOnRussian : IDataExceptionMessageLocalization
    {
        public string NoData => "Нет данных для элемента!";

        public string DataIsNotValid => "Данные для элемента не являются валидными!";

        public string ItemIdleastOne => "Id элемента должен быть не менее 1!";

        public string CountItemsLeastOne => "Количество элементов должно быть не менее 1";

        public string StartItemNotExist(int position)
        {
            return $"Стартовая позиция с номером { position } не существует";
        }
    }
}
