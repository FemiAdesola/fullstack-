using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Exceptions;
using Backend.Middleware;


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

        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddSwaggerDocumentation();

        var app = builder.Build();

        app.UseMiddleware<ErrorHandlerMiddleware>();
    
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
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

        app.UseStatusCodePagesWithRedirects("/errors/{0}");
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseSwaggerDocumentation();
        app.UseCors();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}