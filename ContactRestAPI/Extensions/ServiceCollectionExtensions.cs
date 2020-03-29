using Microsoft.Extensions.DependencyInjection;
namespace ContactRestAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {       

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {

                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Contact", Description = "Contact details", Version = "v1" });
                   
                });
        }
    }
}
