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
            var dataBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GoldenRaspberryAwards.db");
            var connectionString = $"Data Source={dataBasePath}";

            services.AddDbContext<SqliteContext>(options =>
                options.UseSqlite(connectionString)
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
            if (unitOfWork is null)
            {
                throw new Exception($"Service {nameof(unitOfWork)} is unavaliable");
            }

            var bancoSeed = new MovieSeed(unitOfWork);
            await bancoSeed.SeedDataAsync();
        }
    }
}
