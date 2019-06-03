namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IReportExceptionMessageLocalization
    {
        string YearLeastOne { get; }
        string StartingYearLessEndingYear { get; }
        string ColumnNameForSortEmpty { get; }
    }
}