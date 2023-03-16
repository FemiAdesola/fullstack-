using System.Text.Json.Serialization;
using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interface;

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

        builder.Services
            .AddScoped<ICategoryService, DbCategorySerivce>()
            .AddScoped<IProductService, DbProductSerivce>()
            .AddScoped<ICrudService<Address, AddressDTO>, DbCrudService<Address, AddressDTO>>()
            .AddScoped<IOrderService, DbOrderSerivce>()
            .AddScoped<IOrderItemService, DbOrderItemSerivce>()
            .AddScoped<IReviewService, DbReviewSerivce>();

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
        app.UseRouting();
        app.UseStaticFiles();

        app.UseCors();
        app.UseAuthorization();

        app.MapControllers();


        // using var scope = app.Services.CreateScope();
        // var services = scope.ServiceProvider;
        // var context = services.GetRequiredService<AppDbContext>();
        // var logger = services.GetRequiredService<ILogger<Program>>();
        // try
        // {

        //     await DataStore.DataAsync(context);

        // }
        // catch (Exception ex)
        // {
        //     logger.LogError(ex, "An error occured during migration");
        // }



        app.Run();

        
    }
}