using Texo.Teste.WebAPI.Domain.Models;

namespace Texo.Teste.WebAPI.Domain.Entities
{
    public class Movie
    {

        public Movie(ImportMovieModel model)
        {
            Year = model.Year;
            Title = model.Title;
            Studio = model.Studio;
            Producer = model.Producer;
            Winner = model.Winner;
        }

        protected Movie()
        {

        }

        public long Id { get; set; }
        
        public int Year { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Studio { get; private set; } = string.Empty;

        public string Producer { get; private set; } = string.Empty;

        public bool Winner { get; private set; }
    }
}
