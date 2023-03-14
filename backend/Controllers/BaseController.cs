using Backend.Respositories.BaseRepo;
using Backend.Services.cs.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class BaseController<TModel, TReadDto, TCreateDto, TUpdateDto> : BaseApiController
    {
        protected readonly IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto> _service;

        public BaseController(IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return Ok(await _service.GetAllAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TReadDto?>> GetById([FromRoute] string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost()]
        public async Task<ActionResult<TReadDto?>> CreateOne(TCreateDto create)
        {
            var result = await _service.CreateOneAsync(create);
            return CreatedAtAction("Created", result);
        }
    }
}