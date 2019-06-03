namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface ILanguagesExceptionMessageLocalization : IBaseExceptionMessageLocalization
    {
        string NotFoundByName(string name);
    }
}
