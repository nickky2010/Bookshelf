using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class DbUpdateConcurrencyExceptionMessageOnRussian : IDbUpdateConcurrencyExceptionMessageLocalization
    {
        public string RecordToEditWasModifiedAnotherUser
        {
            get => "Запись, которую вы пытались редактировать, была изменена другим пользователем после того, " +
                "как вы получили исходное значение. Операция редактирования была отменена, и были показаны текущие " +
                "значения в базе данных. Если вы все еще хотите редактировать эту запись, попробуйте начать заново.";
        }
    }
}
