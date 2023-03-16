using System.Linq.Expressions;
using Backend.Models;

namespace Backend.Specifications
{
    public class DbCrudWithSPecService : DbSpecificationService<Product> 
    {
        public DbCrudWithSPecService(SpecificationParams productParams)
        : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Title.ToLower().Contains(productParams.Search)) &&
            // (!productParams.CategoryId.HasValue || x.Title.ToLower().Contains(productParams.Search)) &&
            (!productParams.CategoryId.HasValue || x.CategoryId == productParams.CategoryId) 
            )
        {
            AddInclude(x => x.Category);
            AddOrderBy(x => x.Title);
            ApplyPaging(productParams.PageSize * (
                productParams.PageIndex - 1), 
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Title);
                        break;
                }
            }
        }

        public DbCrudWithSPecService(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}