using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ReportController : Controller
    {
        IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        [Route("GetBooksByPublicationDate")]
        public async Task<IActionResult> GetBooksByPublicationDate([FromQuery]int startYear, [FromQuery]int endYear, [FromQuery]string columnNameForSort)
        {
            if (startYear < 1 || endYear < 1)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.YearLeastOne);
            if (startYear > endYear)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.StartingYearLessEndingYear);
            if (columnNameForSort==null)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.ColumnNameForSortEmpty);
            return Ok(await _reportService.GetBooksByPublicationDateAsync(startYear, endYear, columnNameForSort));
        }
        [HttpGet]
        [Route("AuthorsWithOneOrWithoutPublishedBooks")]
        public async Task<IActionResult> AuthorsWithOneOrWithoutPublishedBooks([FromQuery]string columnNameForSort)
        {
            if (columnNameForSort == null)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.ColumnNameForSortEmpty);
            return Ok(await _reportService.AuthorsWithOneOrWithoutPublishedBooksAsync(columnNameForSort));
        }
        [HttpGet]
        [Route("GetAuthorsByPopularity")]
        public async Task<IActionResult> GetAuthorsByPopularity([FromQuery]string columnNameForSort)
        {
            if (columnNameForSort == null)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.ColumnNameForSortEmpty);
            return Ok(await _reportService.GetAuthorsByPopularityAsync(columnNameForSort));
        }
        [HttpGet]
        [Route("GetPublishingHousesWhereAuthorNotPublished")]
        public async Task<IActionResult> GetPublishingHousesWhereAuthorNotPublished([FromQuery]string authorLastname, [FromQuery]string columnNameForSort)
        {
            if (columnNameForSort == null)
                throw new BadRequestException(_reportService.UnitOfWorkExceptionMessage.ReportException.ColumnNameForSortEmpty);
            return Ok(await _reportService.GetPublishingHousesWhereAuthorNotPublishedAsync(authorLastname, columnNameForSort));
        }
    }
}