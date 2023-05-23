using Golden.Raspberry.Awards.WebAPI.Infra.Configurations;
using Golden.Raspberry.Awards.WebAPI.Infra.Management;
using Microsoft.EntityFrameworkCore;
using Texo.Teste.WebAPI.Domain.Entities;

namespace Golden.Raspberry.Awards.WebAPI.Infra.Context
{
    public class SqliteContext : DbContext, IDbContext
    {
        public SqliteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(new MovieConfig().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
