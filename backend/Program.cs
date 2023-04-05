using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Extensions;
using Backend.Middleware;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;

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
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddSwaggerDocumentation();
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins()
                    .WithHeaders(HeaderNames.ContentType, HeaderNames.Accept)
                    // .WithMethods("GET, POST, PUT, DELETE, OPTIONS, PATCH")
                ;
            });
        });

// 
      
// 

        var app = builder.Build();

        app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, PATCH");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

                await next();
            });

        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseMiddleware<LoggerMiddleware>();
        app.UseSwaggerDocumentation();
        app.UseHttpsRedirection();
        app.UseCors("CorsPolicy");
        app.UseStatusCodePagesWithRedirects("/errors/{0}");
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}