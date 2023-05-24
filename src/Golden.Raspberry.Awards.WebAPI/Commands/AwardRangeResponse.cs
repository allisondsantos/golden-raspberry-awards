using Golden.Raspberry.Awards.WebAPI.Domain.Dto;

namespace Golden.Raspberry.Awards.WebAPI.Commands
{
    public class AwardRangeResponse
    {
        public IEnumerable<ProducerAwardDto>? Min { get; set; }

        public IEnumerable<ProducerAwardDto>? Max { get; set; }
    }
}
