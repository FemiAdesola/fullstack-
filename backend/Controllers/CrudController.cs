using Backend.common;
using Backend.DTOs;
using Backend.Exceptions;
using Backend.Models;
using Backend.Services;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public abstract class CrudController<TModel, TDto, TReturn> : BaseApiController
     where TModel : BaseModel, new()
     where TDto : BaseDTO<TModel>
     where TReturn: BaseReturnDTO<TModel>
    {
        private readonly ICrudService<TModel, TDto> _service;

        public CrudController(ICrudService<TModel, TDto> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
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

        [HttpGet]
        public async virtual Task<ActionResult<IReadOnlyList<TReturn>>> GetAll()
        {
            var item = await _service.GetAllAsync();
            return Ok(item);
        }


        [HttpGet("{id}")]
        public async virtual Task<ActionResult<TReturn?>> Get(int id)
        {

            var item = await _service.GetAsync(id);
            if (item is null)
            {
                return NotFound($"Item with ID {id} is not found");
            }
            return Ok((item));
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