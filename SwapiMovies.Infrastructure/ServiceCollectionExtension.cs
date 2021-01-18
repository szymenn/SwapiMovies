using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SwapiMovies.Infrastructure.Data;
using SwapiMovies.Core.Interfaces;
using SwapiMovies.Infrastructure.Repositories;
using SwapiMovies.Infrastructure.Services;

namespace SwapiMovies.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            services.AddHttpClient<ISwapiClientService, SwapiClientService>();
            services.AddScoped<IRatingRepository, RatingRepository>();
        }
    }
}