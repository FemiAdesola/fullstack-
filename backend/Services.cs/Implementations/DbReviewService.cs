namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

public class DbReviewSerivce : DbCrudService<Review, ReviewDTO>, IReviewService
{
    public DbReviewSerivce(AppDbContext dbContext) : base(dbContext)
    {

    }
}