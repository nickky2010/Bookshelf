using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class TagsExceptionMessageOnRussian: ITagsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Тег после добавления не найден!";

        public string NotFound => "Тег не найден!";

        public string NotFoundById(int id)
        {
            return $"Тег с id { id } не найден! Возможно элемент с id {id} не существуе!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить тег! Возможно элемент с id { id } не существует.";
        }
    }
}
