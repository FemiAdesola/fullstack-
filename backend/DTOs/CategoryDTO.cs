namespace Backend.DTOs;

using System.ComponentModel.DataAnnotations;
using Backend.Models;

public class CategoryDTO : BaseDTO<Category>
{
    [Required]
    public string Name { get; set; }= null!;
    public string Image { get; set; }= null!;

    public override void UpdateModel(Category model)
    {
        model.Name = Name;
        model.Image = Image;
    }
}