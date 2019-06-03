using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class DbUpdateConcurrencyExceptionMessageOnEnglish : IDbUpdateConcurrencyExceptionMessageLocalization
    {
        public string RecordToEditWasModifiedAnotherUser
        {
            get => "The record you attempted to edit was modified by another user after you got the original value. " +
                "The edit operation was canceled and the current values in the database have been displayed. " +
                "If you still want to edit this record, try begin again.";
        }
    }
}
