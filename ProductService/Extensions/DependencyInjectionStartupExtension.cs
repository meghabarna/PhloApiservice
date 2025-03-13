using System.Reflection;
using ProductService.DataLayer.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using ProductService.Services;


namespace ProductService.Extensions
{
    public static class DependencyInjectionStartupExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataLayerInjection(configuration);
            services.ConfigureServiceLogicLayer();
            services.AddFluentValidationConfiguration();
        }
        private static void ConfigureDataLayerInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void ConfigureServiceLogicLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductInfoService, ProductInfoService>();
        }

        private static void AddFluentValidationConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddFluentValidationAutoValidation();
            serviceCollection.AddFluentValidationClientsideAdapters();
            serviceCollection.AddValidatorsFromAssemblyContaining<Program>();
        }
    }
}
