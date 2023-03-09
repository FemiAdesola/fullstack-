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
        finally
        {
            // dbConn?.Dispose();
        }
    }

}
