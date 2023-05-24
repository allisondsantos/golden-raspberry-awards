using CsvHelper;
using CsvHelper.Configuration;
using Golden.Raspberry.Awards.WebAPI.Infra.Management;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Texo.Teste.WebAPI.Domain.Entities;
using Texo.Teste.WebAPI.Domain.Models;

namespace Golden.Raspberry.Awards.WebAPI.Infra.Seeding
{
    public class MovieSeed : ISeedDatabase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieSeed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedDataAsync()
        {
            var movieRepository = _unitOfWork.GetRepository<Movie>();
            var existAnyMovie = await movieRepository.GetAll().AnyAsync();

            if (existAnyMovie)
                return;

            var files = Directory.GetFiles(".\\AppData\\", "*.*", SearchOption.AllDirectories)
                                .Where(f => Path.GetExtension(f) == ".csv").ToArray();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                DetectDelimiter = true,
            };
            foreach (var file in files)
            {
                using (var streamReader = new StreamReader(file))
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Read();
                    csvReader.ReadHeader();
                    while (csvReader.Read())
                    {
                        var record = new ImportMovieModel
                        {
                            Year = csvReader.GetField<int>("year"),
                            Title = csvReader.GetField("title") ?? string.Empty,
                            Producer = csvReader.GetField("producers") ?? string.Empty,
                            Studio = csvReader.GetField("studios") ?? string.Empty,
                            Winner = (csvReader.GetField("winner") ?? string.Empty)
                                .Equals("yes", StringComparison.InvariantCultureIgnoreCase),
                        };
                      movieRepository.Add(new Movie(record));
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
