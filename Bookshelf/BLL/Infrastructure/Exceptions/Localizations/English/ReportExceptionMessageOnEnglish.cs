using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class ReportExceptionMessageOnEnglish : IReportExceptionMessageLocalization
    {
        public string YearLeastOne => "Year must be at least 1";

        public string StartingYearLessEndingYear => "The starting year must be less than the ending year";

        public string ColumnNameForSortEmpty => "The column name for sort is empty";
    }
}