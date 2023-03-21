using AutoMapper;
using Backend.common;
using Backend.DTOs;
using Backend.Errors;
using Backend.Helper;
using Backend.Models;
using Backend.Services;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Authorize(Roles = "Admin")]
    public abstract class CrudController<TModel, TDto, TReturn> : BaseApiController
     where TModel : BaseModel, new()
     where TDto : BaseDTO<TModel>
     where TReturn: BaseReturnDTO<TModel>
    {
        private readonly ICrudService<TModel, TDto> _service;
        private readonly IMapper _mapper;
        
        public CrudController(ICrudService<TModel, TDto> service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper;
        }

        [HttpPost]
        public async virtual Task<IActionResult> Create(TDto request)
        {
            var item = await _service.CreateAsync(request);
            if (item is null)
            {
                return BadRequest("Something is wrong with the payload request");
            }
            return Ok(item);
        }

        [AllowAnonymous]
        [HttpGet]
        public async virtual Task<ActionResult<ICollection<TReturn>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(_mapper.Map<ICollection<TModel>, ICollection<TReturn>>(items));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseError), StatusCodes.Status404NotFound)]
        public async virtual Task<ActionResult<TReturn?>> Get(int id)
        {
            var item = await _service.GetAsync(id);
            if (item is null)
            {
                return NotFound(new ApiResponseError(404));
            }

            return _mapper.Map<TModel, TReturn>(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TModel>> Update(int id, TDto request)
        {
            var item = await _service.UpdateAsync(id, request);
            if (item is null)
            {
                return NotFound("item is not found");
            }
            
            return Ok(new Response<TModel>(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
            {
                return Ok(new { Message = $"item with Id {id} is deleted " });
            }
            return NotFound($" Item with ID {id} is not found");
        }
    }
}