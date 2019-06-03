using System.Threading.Tasks;
using BLL.DTO;
using BLL.DTO.ViewModel;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // GET: api/Book
        IDataBaseService<BookDTO> _dataBaseService;
        public BooksController(IDataBaseService<BookDTO> dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        // GET: api/<controller>?startItem=1&countItem=1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int startItem, [FromQuery]int countItem)
        {
            if (startItem < 1)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.StartItemNotExist(startItem));
            if (countItem < 1)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.CountItemsLeastOne);
            return Ok(await _dataBaseService.GetPageAsync(startItem, countItem));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _dataBaseService.GetAsync(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookViewModel value)
        {
            if (value == null)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.NoData);
            if (!ModelState.IsValid)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.DataIsNotValid);
            return Ok(await _dataBaseService.AddAsync(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]BookViewModel value)
        {
            if (value == null)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.NoData);
            if (id<1)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.ItemIdleastOne);
            if (!ModelState.IsValid)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.DataIsNotValid);
            value.Id = id;
            return Ok(await _dataBaseService.UpdateAsync(value));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                throw new BadRequestException(_dataBaseService.UnitOfWorkExceptionMessage.DataException.ItemIdleastOne);
            return Ok(await _dataBaseService.DeleteAsync(id));
        }
    }
}