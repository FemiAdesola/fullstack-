namespace Backend.Services.Interface
{
    public interface ICrudService<TModel, TDto>
    {
        Task<TModel?> CreateAsync(TDto request);
        Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options);
        Task<TModel?> GetAsync(int id);
        Task<TModel?> UpdateAsync(int id, TDto request);
        Task<bool> DeleteAsync(int id);
    }

    public class QueryOptions
    {
        public string Sort { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        public SortBy SortBy { get; set; }
        public int Limit { get; set; } = 30;
        public int Skip { get; set; } = 1;
    }

    public enum SortBy
    {
        ASC,
        DESC
    }
}