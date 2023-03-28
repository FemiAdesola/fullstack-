using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Extensions;
using Backend.Middleware;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;

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

        builder.Services
            .AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddSwaggerDocumentation();
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        var app = builder.Build();
        
        app.UseMiddleware<ErrorHandlerMiddleware>();
        // app.UseMiddleware<LoggerMiddleware>();
         app.UseSwaggerDocumentation();
        app.UseHttpsRedirection();
        // app.UseStatusCodePagesWithRedirects("/errors/{0}");
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}