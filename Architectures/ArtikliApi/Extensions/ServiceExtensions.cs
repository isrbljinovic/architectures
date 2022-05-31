using ArtikliApi.Contracts;
using ArtikliApi.Contracts.Repository;
using ArtikliApi.Models;
using ArtikliApi.Services;
using ArtikliApi.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtikliApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ArtikliContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("dbConnectionString")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IArtikliService, ArtikliService>();
        }
    }
}
