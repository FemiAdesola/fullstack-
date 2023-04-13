using Backend.Models;

namespace Backend.DTOs
{
    public abstract class BaseReturnDTO<TModel> where TModel : BaseModel
    {
        public abstract void BaseToRetunModel(TModel returnBase);
    }
}