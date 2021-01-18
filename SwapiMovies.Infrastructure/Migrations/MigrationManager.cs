using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using SwapiMovies.Infrastructure.Data;

namespace SwapiMovies.Infrastructure.Migrations
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabases(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>() )
                {
                    Migrate(appContext);
                }
               
            }
 
            return host;
        }

        private static void Migrate(DbContext appContext)
        {
            if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                appContext.Database.Migrate();
            }
        }
    }
}