using Backend.Models;

namespace Backend.DTOs
{
    public abstract class BaseDTO<TModel> where TModel : BaseModel
    {
        public abstract void UpdateModel(TModel model);
    }
}