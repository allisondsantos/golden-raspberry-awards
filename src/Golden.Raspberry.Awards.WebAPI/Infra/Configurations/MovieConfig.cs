using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Texo.Teste.WebAPI.Domain.Entities;

namespace Golden.Raspberry.Awards.WebAPI.Infra.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).HasColumnName(nameof(Movie.Id).ToLower());
            builder.Property(m => m.Year).HasColumnName(nameof(Movie.Year).ToLower());
            builder.Property(m => m.Title).HasColumnName(nameof(Movie.Title).ToLower());
            builder.Property(m => m.Studio).HasColumnName(nameof(Movie.Studio).ToLower());
            builder.Property(m => m.Producer).HasColumnName(nameof(Movie.Producer).ToLower());
            builder.Property(m => m.Winner).HasColumnName(nameof(Movie.Winner).ToLower());


        }
    }
}
