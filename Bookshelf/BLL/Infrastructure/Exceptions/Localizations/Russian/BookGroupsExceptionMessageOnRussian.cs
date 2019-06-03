using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class BookGroupsExceptionMessageOnRussian : IBookGroupsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Группа книги после добавления не найдена!";

        public string NotFound => "Группа книги не найдена!";

        public string NotFoundById(int id)
        {
            return $"Группа книги с id { id } не найдена! Возможно элемент с id {id} не существует!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить группу книги! Возможно элемент с id { id } не существует.";
        }
    }
}
