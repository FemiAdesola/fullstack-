using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class ProductDTO : BaseDTO<Product>
    {
        [MinLength(3, ErrorMessage = "Name is too short, min : 3 characters")]
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Images { get; set; } = null!;
        public int CategoryId { get; set; }

        public override void UpdateModel(Product model)
        {
            model.Title = Title;
            model.Price = Price;
            model.Description = Description;
            model.Images = Images;
            model.CategoryId = CategoryId;
        }
    }

    public class ProductToReturnDTO : BaseReturnDTO<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Images { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public ICollection<ReviewProduct> Reviews{ get; set; } = null!;

        public override void BaseToRetunModel(Product returnBase)
        {
            returnBase.Id = Id;
            returnBase.Title = Title;
            returnBase.Description = Description;
            returnBase.Price = Price;
            returnBase.Images = Images;
            returnBase.Category = Category;

        }
    }
}