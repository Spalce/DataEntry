using DataEntry.Infrastructure.Models;
using DataEntry.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataEntryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleItemsController : ControllerBase
    {
        private readonly ISaleItemRepository repository;

        public SaleItemsController(ISaleItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<SaleItem>>> Get()
        {
            try
            {
                var response = await repository.GetAllAsync().ConfigureAwait(false);
                if (response == null)
                {
                    return NoContent();
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<SaleItem>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await repository.GetByIdAsync(id).ConfigureAwait(false);

            return response != null ? Ok(response) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Post([FromBody] List<SaleItem> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await repository.CreateAsync(model).ConfigureAwait(false);

            return Ok();
        }
    }
}
