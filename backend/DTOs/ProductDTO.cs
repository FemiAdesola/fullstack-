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
    public CategoryDTO Category { get; set; } = null!;

    public override void UpdateModel(Product model)
    {
        model.Title = Title;
        model.Price = Price;
        model.Description = Description;
        model.Images = Images;

        var category = new Category();
        Category.UpdateModel(category);
        model.Category = category;
    }
}