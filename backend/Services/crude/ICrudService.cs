namespace Backend.Services.crude
{
    public interface ICrudService<TModel, TDto>
    {
        Task<TModel?> CreateAsync(TDto request);
        Task<ICollection<TModel>> GetAllAsync();
        Task<TModel?> GetAsync(int id);
        Task<TModel?> UpdateAsync(int id, TDto request);
        Task<bool> DeleteAsync(int id);
    }
}