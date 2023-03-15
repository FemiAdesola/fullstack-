using System.Linq.Expressions;

namespace Backend.Services.Interface
{
    public interface ISpecificationService<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}