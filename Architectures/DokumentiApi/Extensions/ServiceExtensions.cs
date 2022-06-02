using DokumentiApi.Contracts;
using DokumentiApi.Contracts.Repository;
using DokumentiApi.Models;
using DokumentiApi.Services;
using DokumentiApi.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DokumentiApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DokumentiContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("dbConnectionString")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDokumentiService, DokumentiService>();
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient("ArtikliApi", httpClient =>
            {
                httpClient.BaseAddress = new System.Uri("http://localhost:80/artikli/");
            });

            services.AddHttpClient("PartneriApi", httpClient =>
            {
                httpClient.BaseAddress = new System.Uri("http://localhost:82/partneri/");
            });

            services.AddTransient<INaziviService, NaziviService>();
        }
    }
}
