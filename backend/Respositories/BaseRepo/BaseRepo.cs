using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Respositories.BaseRepo
{
    public class BaseRepo<TModel> : IBaseRepo<TModel>
        where TModel : BaseModel
    {
        protected readonly AppDbContext _context;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TModel?> CreateOneAsync(TModel create)
        {
            await _context.Set<TModel>().AddAsync(create);
            return create;
        }

        public async Task<bool> DeleteOneAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
            {
                return false;
            }
            else
            {
                _context.Set<TModel>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options)
        {
            var query = _context.Set<TModel>().AsNoTracking();
            if (options.Sort.Trim().Length > 0)
            {
                if (query.GetType().GetProperty(options.Sort) != null) 
                {
                    query.OrderBy(e => e.GetType().GetProperty(options.Sort));
                }
                query.Take(options.Limit).Skip(options.Skip);
            }
            return await query.ToArrayAsync();
        }

        public async Task<TModel?> GetByIdAsync(string id)
        {
            return await _context.Set<TModel>().FindAsync(id);
        }

        public async Task<TModel> UpdateOneAsync(string id, TModel update)
        {
            var entity = update;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
