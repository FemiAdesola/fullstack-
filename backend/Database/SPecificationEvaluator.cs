using Backend.Models;
using Backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class SPecificationEvaluator<TModel> where TModel : BaseModel
    {
        public static IQueryable<TModel> GetQuery(IQueryable<TModel> inputQuery,
           ISpecificationService<TModel> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            // if (spec.OrderBy != null)
            // {
            //     query = query.OrderBy(spec.OrderBy);
            // }

            // if (spec.OrderByDescending != null)
            // {
            //     query = query.OrderByDescending(spec.OrderByDescending);
            // }

            // if (spec.IsPagingEnabled)
            // {
            //     query = query.Skip(spec.Skip).Take(spec.Take);
            // }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}