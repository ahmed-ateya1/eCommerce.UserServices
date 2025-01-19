using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension Method to Add Infrastructure services to DI container 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TO DO: add service to ioc container here
            //infrastructure services often include data access , caching, logging, and other low-level services

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
