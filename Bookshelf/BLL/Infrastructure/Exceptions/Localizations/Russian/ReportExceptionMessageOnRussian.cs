using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class ReportExceptionMessageOnRussian : IReportExceptionMessageLocalization
    {
        public string YearLeastOne => "Год должен быть не менее 1";

        public string StartingYearLessEndingYear => "Начальный год должен быть меньше конечного года";

        public string ColumnNameForSortEmpty => "Имя столбца для сортировки не задано";
    }
}