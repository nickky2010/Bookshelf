using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class GenresExceptionMessageOnRussian : IGenresExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Жанр после добавления не найден!";

        public string NotFound => "Жанр не найден!";

        public string NotFoundById(int id)
        {
            return $"Жанр с id { id } не найден! Возможно элемент с id {id} не существует!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить жанр! Возможно элемент с id { id } не существует.";
        }
    }
}
