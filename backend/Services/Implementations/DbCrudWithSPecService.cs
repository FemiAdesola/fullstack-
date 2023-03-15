using System.Linq.Expressions;
using Backend.Models;

namespace Backend.Services.Implementations
{
    public class DbCrudWithSPecService : DbSpecificationService<Product> 
    {
        public DbCrudWithSPecService()
        {
            AddInclude(x => x.Category);
        }

        public DbCrudWithSPecService(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}