using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
            //     option.AddSecurityDefinition(
            //     "oauth2",
            //     new OpenApiSecurityScheme
            //     {
            //         Description = "Bearer token authentication",
            //         Name = "Authorization",
            //         In = ParameterLocation.Header,
            //     }
            // );
            //     option.OperationFilter<SecurityRequirementsOperationFilter>();

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorisation",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                option.AddSecurityDefinition("Bearer",securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securitySchema, new[] {"Bearer"}
                    }
                };
                option.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            return app;
        }
    }
}