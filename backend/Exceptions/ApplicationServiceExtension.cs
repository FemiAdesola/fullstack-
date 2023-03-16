using Backend.DTOs;
using Backend.Errors;
using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exceptions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services
            .AddScoped<ICategoryService, DbCategorySerivce>()
            .AddScoped<IProductService, DbProductSerivce>()
            .AddScoped<ICrudService<Address, AddressDTO>, DbCrudService<Address, AddressDTO>>()
            .AddScoped<IOrderService, DbOrderSerivce>()
            .AddScoped<IOrderItemService, DbOrderItemSerivce>()
            .AddScoped<IReviewService, DbReviewSerivce>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContex =>
                {
                    var errors = actionContex.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .SelectMany(e => e.ErrorMessage).ToString();

                    var errorResponse = new ApiValidationError
                    {
                        // Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}