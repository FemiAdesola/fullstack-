namespace Backend.DTOs;

using Backend.Models;
using System.ComponentModel.DataAnnotations;

public class ProductDTO : BaseDTO<Product>
{
    [MinLength(3, ErrorMessage = "Name is too short, min : 3 characters")]
    public string Title { get; set; } = null!;
    public float Price { get; set; }
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