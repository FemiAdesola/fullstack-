using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;

namespace Backend.Services.Implementations
{
    public class DbReviewSerivce : DbCrudService<Review, ReviewDTO>, IReviewService
    {
        public DbReviewSerivce(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}