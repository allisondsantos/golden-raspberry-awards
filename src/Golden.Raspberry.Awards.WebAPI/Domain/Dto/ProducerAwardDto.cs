namespace Golden.Raspberry.Awards.WebAPI.Domain.Dto
{
    public class ProducerAwardDto
    {
        public string? Producer { get; set; }

        public int Interval { get; set; }

        public int PreviousWin { get; set; }

        public int FollowingWin { get; set; }
    }
}
