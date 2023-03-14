using Backend.common;
using Backend.DTOs;
using Backend.Exceptions;
using Backend.Models;
using Backend.Services;
using Backend.Services.crude;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public abstract class CrudController<TModel, TDto> : BaseApiController
     where TModel : BaseModel, new()
     where TDto : BaseDTO<TModel>
    {
        private readonly ICrudService<TModel, TDto> _service;

        public CrudController(ICrudService<TModel, TDto> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async virtual Task<IActionResult> Create(TDto request)
        {
            try
            {
                var item = await _service.CreateAsync(request);
                if (item is null)
                {
                    return BadRequest("Something is wrong with the payload request");
                }
                return Ok(item);
            }
            catch (HttpException ex) 
            {
                return Ok("Error creating data for the .....");
            }
        }

        [HttpGet]
        public async virtual Task<ActionResult<ICollection<TModel>>> GetAll()
        {
            try
            {
                var categories = await _service.GetAllAsync();
                return Ok(categories);

            }
            catch (HttpException ex) 
            {
                return Ok("Error retrieving data for the .....");
            }
        }


        [HttpGet("{id:int}")]
        public async virtual Task<ActionResult<TModel?>> Get(int id)
        {
            try
            {
                var item = await _service.GetAsync(id);
                if (item is null)
                {
                    return NotFound($"Item with ID {id} is not found");
                }
                return Ok(new Response<TModel>(item));
            }
            catch (HttpException ex) 
            {
                return Ok("Error getting data for the .....");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TModel>> Update(int id, TDto request)
        {
            try
            {
                var item = await _service.UpdateAsync(id, request);
                if (item is null)
                {
                    return NotFound("item is not found");
                }
                return Ok(new Response<TModel>(item));
            }
            catch (HttpException ex)
            {
                return Ok("Error in getting data .....");
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (await _service.DeleteAsync(id))
                {
                    return Ok(new { Message = $"item with Id {id} is deleted " });
                }
                return NotFound($" Item with ID {id} is not found");
            }
            catch (HttpException ex)
            {
                return Ok("Error in getting data .....");
            }
        }
    }
}