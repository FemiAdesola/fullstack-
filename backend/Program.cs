using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Extensions;
using Backend.Middleware;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

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
            // .AddIdentity<User,IdentityRole<int>>() // with strong identity 
            .AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }) // with less strong password requirements
            .AddEntityFrameworkStores<AppDbContext>();
            
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddSwaggerDocumentation();
        builder.Services.AddIdentityServices(builder.Configuration);

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
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwaggerDocumentation();
        app.MapControllers();
        app.Run();
    }
}