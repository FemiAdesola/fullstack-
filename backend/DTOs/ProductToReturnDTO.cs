using Backend.Models;

namespace Backend.DTOs
{
    public class ProductToReturnDTO : BaseReturnDTO<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public ICollection<string> Images { get; set; } = null!;
        public string Category { get; set; } = null!;

        public override void BaseToRetunModel(Product returnBase)
        {
            returnBase.Id = Id;
            returnBase.Title = Title;
            returnBase.Description = Description;
            returnBase.Price= Price;
            returnBase.Images = Images;
            returnBase.Category.Name= Category;

        }
    }
}