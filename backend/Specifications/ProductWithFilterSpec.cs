using Backend.Models;

namespace Backend.Specifications
{
    public class ProductWithFilterSpec : DbSpecificationService<Product>
    {
        public ProductWithFilterSpec(SpecificationParams productParams) : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Title.ToLower().Contains(productParams.Search)) &&
            (!productParams.CategoryId.HasValue || x.CategoryId == productParams.CategoryId))
        {

        }
    }
}