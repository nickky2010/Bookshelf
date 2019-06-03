using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class BooksExceptionMessageOnRussian: IBooksExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Книга после добавления не найдена!";

        public string NotFound => "Книга не найдена!";

        public string NotFoundById(int id)
        {
            return $"Книга с id { id } не найдена! Возможно элемент с id {id} не существует!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить книгу! Возможно элемент с id { id } не существует.";
        }
    }
}
