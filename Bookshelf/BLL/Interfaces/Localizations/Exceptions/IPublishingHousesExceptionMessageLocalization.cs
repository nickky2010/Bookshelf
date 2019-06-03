namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IPublishingHousesExceptionMessageLocalization : IBaseExceptionMessageLocalization
    {
        string NotFoundByName(string name);
    }
}
