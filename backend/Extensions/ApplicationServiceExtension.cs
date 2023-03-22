using System.Text;
using Backend.Authorization;
using Backend.DTOs;
using Backend.Errors;
using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interface;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Extensions
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
                .AddScoped<IReviewService, DbReviewSerivce>()

                .AddScoped<IUserService, UserService>()
                .AddScoped<IUserTokenService, UserTokenService>()
                .AddTransient<IAuthorizationHandler, UpdateUserPermission>();

            services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState
                            .Where(e => e.Value!.Errors.Count > 0)
                            .SelectMany(x => x.Value!.Errors)
                            .Select(x => x.ErrorMessage).ToArray();

                        var errorResponse = new ApiValidationError
                        {
                            Errors = errors
                        };

                        return new BadRequestObjectResult(errorResponse);
                    };
                });
            return services;
        }
    }
}