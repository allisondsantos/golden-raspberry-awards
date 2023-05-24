using CsvHelper.Configuration.Attributes;

namespace Golden.Raspberry.Awards.WebAPI.Infra.Seeding
{
    public class MovieFile
    {
        [Name("year")]
        public int Year { get; set; }

        [Name("title")]
        public string Title { get; set; } = string.Empty;

        [Name("studios")]
        public string Studio { get; set; } = string.Empty;

        [Name("producers")]
        public string Producer { get; set; } = string.Empty;

        [Name("winner")]
        [BooleanTrueValues("yes")]
        [BooleanFalseValues("no")]
        public bool Winner { get; set; }
    }
}
