using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PetMedicine.RescueQuery.API.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddMultiversionSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationOptions>();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerOperationFilter>();
            });
            return services;
        }

        public static IApplicationBuilder UseMultiversionSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var apiVersionDescription in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{apiVersionDescription.GroupName}/swagger.json", 
                        $"WisdomPetMedicine.RescueQuery.Api {apiVersionDescription.GroupName}");
                }
            });
            return app;
        }
    }
}