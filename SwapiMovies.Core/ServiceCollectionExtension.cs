using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SwapiMovies.Core.Interfaces;
using SwapiMovies.Core.Services;

namespace SwapiMovies.Core
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationCore(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); });

            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            
            services.AddScoped<IRatingService, RatingService>();

            
        }
    }
}