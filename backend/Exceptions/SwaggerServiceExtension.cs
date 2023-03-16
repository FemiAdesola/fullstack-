using Microsoft.OpenApi.Models;

namespace Backend.Exceptions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            // services.AddSwaggerGen(c =>
            // {
            //     var securitySchema = new OpenApiSecurityScheme
            //     {
            //         Description = "JWT Auth Bearer Scheme",
            //         Name = "Authorisation",
            //         In = ParameterLocation.Header,
            //         Type = SecuritySchemeType.Http,
            //         Scheme = "Bearer",
            //         Reference = new OpenApiReference
            //         {
            //             Type = ReferenceType.SecurityScheme,
            //             Id = "Bearer"
            //         }
            //     };

            //     c.AddSecurityDefinition("Bearer", securitySchema);

            //     var securityRequirement = new OpenApiSecurityRequirement
            //     {
            //         {
            //             securitySchema, new[] {"Bearer"}
            //         }
            //     };
            //     c.AddSecurityRequirement(securityRequirement);
            // });
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