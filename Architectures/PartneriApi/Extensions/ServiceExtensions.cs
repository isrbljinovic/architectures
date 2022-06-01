using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartneriApi.Contracts;
using PartneriApi.Contracts.Repository;
using PartneriApi.Models;
using PartneriApi.Services;
using PartneriApi.Services.Repository;

namespace PartneriApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PartneriContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("dbConnectionString")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IPartneriService, PartneriService>();
        }
    }
}
