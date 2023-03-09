namespace Backend.Controllers;

using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Exceptions;
using Microsoft.EntityFrameworkCore;

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
                return BadRequest("Something is wrong with the payload");
            }
            return Ok(item);
       }
        catch (HttpException ex) when (ex.StatusCode == 500)
        {
            return Ok("Error creating data for the .....");
        }
        catch (HttpException ex) when (ex.StatusCode == 400)
        {
            return Ok("payload is not valid .....");
        }
        finally
        {
            // DbContext?.Dispose();
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
        catch (HttpException ex) when (ex.StatusCode == 500)
        {
            return Ok("Error retrieving data for the .....");
        }
        catch (HttpException ex) when (ex.StatusCode == 400)
        {
            return Ok("payload is not valid .....");
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
                return NotFound($" {id} is not found");
            }
            return item;
        }
        catch (HttpException ex) when (ex.StatusCode == 500)
        {
            return Ok("Error getting data for the .....");
        }
        catch (HttpException ex) when (ex.StatusCode == 400)
        {
            return Ok("payload is not valid .....");
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
            return Ok(item);
        }
        catch (HttpException ex) when (ex.StatusCode == 500)
        {
            return Ok("Error in getting data .....");
        }
        catch (NotFoundException ex) when (ex.StatusCode == 404)
        {
            return Ok("payload is not found .....");
        }
       
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try 
        {
            if (await _service.DeleteAsync(id))
            {
                return Ok(new { Message = $"Crud {id} is deleted " });
            }
            return NotFound($" {id} is not found");
        }
        catch (HttpException ex) when (ex.StatusCode == 500)
        {
            return Ok("Error in getting data .....");
        }
        catch (NotFoundException ex) when (ex.StatusCode == 404)
        {
            return Ok("payload is not found .....");
        }
    }
}
