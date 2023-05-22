namespace Texo.Teste.WebAPI.Domain.Models
{
    public class ImportMovieModel
    {
        public int Year { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Studio { get; set; } = string.Empty;

        public string Producer { get; set; } = string.Empty;

        public bool Winner { get; set; }
    }
}
