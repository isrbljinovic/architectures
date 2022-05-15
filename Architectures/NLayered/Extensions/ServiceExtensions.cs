using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayered.BusinessLayer.Services;
using NLayered.Contracts.Repository;
using NLayered.Contracts.Services;
using NLayered.DataLayer.DbContexts;
using NLayered.DataLayer.Repositories;

namespace NLayered.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FirmaContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("dbConnectionString")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDokumentiService, DokumentiService>();
            services.AddScoped<IStavkeService, StavkeService>();
        }
    }
}
