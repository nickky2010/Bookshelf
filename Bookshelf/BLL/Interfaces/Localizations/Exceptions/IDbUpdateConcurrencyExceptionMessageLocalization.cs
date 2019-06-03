using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IDbUpdateConcurrencyExceptionMessageLocalization
    {
        string RecordToEditWasModifiedAnotherUser { get; }
    }
}
