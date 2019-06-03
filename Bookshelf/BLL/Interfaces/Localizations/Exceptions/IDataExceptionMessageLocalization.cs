namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IDataExceptionMessageLocalization
    {
        string NoData { get; }
        string DataIsNotValid { get; }
        string ItemIdleastOne { get; }
        string StartItemNotExist(int position);
        string CountItemsLeastOne { get; }
    }
}