using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Respositories.BaseRepo
{
    public interface IBaseRepo<TModel>
    {
        Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options);
        Task<TModel?> GetByIdAsync(string id);
        Task<TModel> UpdateOneAsync(string id, TModel update);
        Task<bool> DeleteOneAsync(string id);
        Task<TModel?> CreateOneAsync(TModel create);
    }

    public class QueryOptions
    {
        public string Sort { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        public SortBy SortBy { get; set; }
        public int Limit { get; set; } = 30;
        public int Skip { get; set; } = 0;
    }

    public enum SortBy
    {
        ASC,
        DESC
    }
}