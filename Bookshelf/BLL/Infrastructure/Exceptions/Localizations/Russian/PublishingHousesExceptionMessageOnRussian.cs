using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class PublishingHousesExceptionMessageOnRussian : IPublishingHousesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Издательский дом после добавления не найден!";

        public string NotFound => "Издательский дом не найден!";

        public string NotFoundById(int id)
        {
            return $"Издательский дом с id { id } не найден! Возможно элемент с id {id} не существует!";
        }
        public string NotFoundByName(string name)
        {
            return $"Издательский дом {name} не найден!";
        }

        public string UnableToDelete(int id)
        {
            return $"Невозможно удалить издательский дом! Возможно элемент с id { id } не существует.";
        }
    }
}
