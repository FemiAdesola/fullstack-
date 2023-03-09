namespace Backend.Services;

using System.Collections.Generic;
using Backend.DTOs;
using Backend.Models;
using System.Threading.Tasks;
//using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

public class DbCrudService<TModel, TDto> : ICrudService<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    protected ConcurrentDictionary<int, TModel> _items = new();
    private int _itemId;

    public async Task<TModel?> CreateAsync(TDto request)
    {
        // await Task.Delay(1);
        // var item = new TModel
        // {
        //     Id = Interlocked.Increment(ref _itemId), // Atomic operation
        // };
        // _items[item.Id] = item;
        // request.UpdateModel(item); // DTO request for each class or model
        // return item;

        return await Task.Run(() =>
        {
            var item = new TModel
            {
                Id = Interlocked.Increment(ref _itemId), // Atomic operation
            };
            _items[item.Id] = item;
            request.UpdateModel(item); // DTO request for each class or model
            return item;
        });

    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TModel?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TModel?> UpdateAsync(int id, TDto request)
    {
        throw new NotImplementedException();
    }
}