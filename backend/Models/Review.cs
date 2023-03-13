namespace Backend.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Review : BaseModel
{
    public int Rating { get; set; }
    public string? Comment { get; set; } 
    public int ProductId { get; set; }
}