namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface ISeriesExceptionMessageLocalization : IBaseExceptionMessageLocalization
    {
        string NotFoundByName(string name);
    }
}
