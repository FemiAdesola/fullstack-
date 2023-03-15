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
        public ICollection<string> Images { get; set; } = null!;
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
}