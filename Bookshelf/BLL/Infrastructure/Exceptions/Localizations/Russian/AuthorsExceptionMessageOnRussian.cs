using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class AuthorsExceptionMessageOnRussian : IAuthorsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Автор после добавления не найден!";

        public string NotFound => "Автор не найден!";

        public string NotFoundById(int id)
        {
            return $"Автор с id { id } не найден! Возможно элемент с id {id} не существует!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить автора! Возможно элемент с id { id } не существует.";
        }
    }
}
