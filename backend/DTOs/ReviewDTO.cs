using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class ReviewDTO : BaseDTO<Review>
    {
        [Range(1, 5, ErrorMessage = "Raing must be between 1 and 5")]
        public int Rating { get; set; }

        [MaxLength(400)]
        public string? Comment { get; set; }

        public int ProductId { get; set; }

        public override void UpdateModel(Review model)
        {
            model.Rating = Rating;
            model.Comment = Comment;
            model.ProductId = ProductId;
        }
    }
}