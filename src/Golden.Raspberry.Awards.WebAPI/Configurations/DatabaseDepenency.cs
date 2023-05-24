using Golden.Raspberry.Awards.WebAPI.Infra.Context;
using Golden.Raspberry.Awards.WebAPI.Infra.Management;
using Golden.Raspberry.Awards.WebAPI.Infra.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Golden.Raspberry.Awards.WebAPI.Configurations
{
    public static class DatabaseDepenency
    {
        public static IServiceCollection ConfigureDatabaseDepenency(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionString:Sqlite");

            if (connection is null)
            {
                throw new Exception("The database connection has not been set up.");
            }

            services.AddDbContext<SqliteContext>(options =>
                options.UseSqlite(connection.Value)
            );

            services.AddScoped<IDbContext, SqliteContext>();
            return services;
        }

        public static IHost ApplyMigrations(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SqliteContext>();
                if (context is null)
                {
                    throw new Exception("Invalid context.");
                }

                context.Database.Migrate();
            }

            return host;
        }

        public static async Task SeedDataAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var unitOfWork = services.GetService<IUnitOfWork>();

            var bancoSeed = new MovieSeed(unitOfWork);
            await bancoSeed.SeedDataAsync();
        }
    }

}
