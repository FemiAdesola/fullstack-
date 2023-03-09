using System.Security.AccessControl;
using Backend.Services;
using System.Text.Json.Serialization;
using Backend.Models;
using Backend.DTOs;
using Microsoft.Extensions.Configuration.Json;
//using Backend.Db;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // for igonore cycles // Fix the JSON cycle issue
    }
    )
;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddScoped<ICrudService<Category, CategoryDTO>, DbCrudService<Category, CategoryDTO>>();
builder.Services.AddScoped<ICategoryService, DbCategorySerivce>();
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
