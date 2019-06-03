using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class SeriesExceptionMessageOnRussian : ISeriesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Серия после добавления не найдена!";

        public string NotFound => "Серия не найдена!";

        public string NotFoundById(int id)
        {
            return $"Серия с id { id } не найдена! Возможно элемент с id {id} не существует!";
        }
        public string NotFoundByName(string name)
        {
            return $"Серия {name} не найдена!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить серию! Возможно элемент с id { id } не существует.";
        }
    }
}
