

using System.Text.Json.Serialization;
using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.CategoryService;
using Backend.Services.crude;
using Backend.Services.Implementations;
using Backend.Services.OrderItemService;
using Backend.Services.OrderService;
using Backend.Services.ProductService;
using Backend.Services.ReviewService;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>();

        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddCors();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddScoped<ICategoryService, DbCategorySerivce>()
        .AddScoped<IProductService, DbProductSerivce>();


        builder.Services.AddScoped<IOrderService, DbOrderSerivce>();

        builder.Services.AddScoped<ICrudService<Address, AddressDTO>, DbCrudService<Address, AddressDTO>>();

        builder.Services.AddScoped<IOrderItemService, DbOrderItemSerivce>();

        builder.Services.AddScoped<IReviewService, DbReviewSerivce>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                var config = scope.ServiceProvider.GetService<IConfiguration>();
                if (dbContext is not null)
                {
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                }
            }
        }

        app.UseHttpsRedirection();

        app.UseCors();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}