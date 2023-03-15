using System.Linq.Expressions;
using Backend.Services.Interface;

namespace Backend.Services.Implementations
{
    public class DbSpecificationService<T> : ISpecificationService<T>
    {
        public DbSpecificationService()
        {
            
        }
        public DbSpecificationService(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

    }
}