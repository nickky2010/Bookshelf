using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class LanguagesExceptionMessageOnRussian : ILanguagesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Язык после добавления не найден!";

        public string NotFound => "Язык не найден!";

        public string NotFoundById(int id)
        {
            return $"Язык с id { id } не найден! Возможно элемент с id {id} не существует!";
        }
        public string NotFoundByName(string name)
        {
            return $"Язык {name} не найден!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить язык! Возможно элемент с id { id } не существует.";
        }
    }
}
