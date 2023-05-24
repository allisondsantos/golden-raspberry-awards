using Golden.Raspberry.Awards.WebAPI.Domain.Dto;
using Golden.Raspberry.Awards.WebAPI.Infra.Management;
using Microsoft.EntityFrameworkCore;
using Texo.Teste.WebAPI.Domain.Entities;

namespace Golden.Raspberry.Awards.WebAPI.Commands
{
    public class AwardRangeCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public AwardRangeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AwardRangeResponse> HandlerAsync(
            CancellationToken cancellationToken = default)
        {
            var repositorio = _unitOfWork.GetRepository<Movie>();
            var winners = await repositorio.GetAll()
                .Where(m => m.Winner)
                .GroupBy(m => m.Producer)
                .ToListAsync(cancellationToken);
            var producersAwards = GetProducersAwards(winners);

            return new AwardRangeResponse
            {
                Min = producersAwards
                .Where(x => x.Interval == producersAwards.Min(x => x.Interval))
                .OrderBy(x => x.PreviousWin),
                Max = producersAwards
                .Where(x => x.Interval == producersAwards.Max(x => x.Interval))
                .OrderBy(x => x.PreviousWin),
            };
        }

        private List<ProducerAwardDto> GetProducersAwards(List<IGrouping<string, Movie>> winners)
        {
            var list = new List<ProducerAwardDto>();

            foreach (var winner in winners)
            {
                var listWinners = winner.ToList();
                if (listWinners.Count() < 2) continue;

                foreach (var item in listWinners)
                {
                    var next = Next(listWinners, item);
                    if (next is null) continue;

                    var awardInterval = new ProducerAwardDto
                    {
                        Producer = item.Producer,
                        PreviousWin = item.Year,
                        FollowingWin = next.Year,
                    };
                    awardInterval.Interval = awardInterval.FollowingWin - awardInterval.PreviousWin;
                    list.Add(awardInterval);
                }
            }
            list = list.OrderBy(x => x.Interval).ToList();
            return list;
        }

        private T? Next<T>(IList<T> collection, T current)
        {
            var index = collection.IndexOf(current);
            if (index < 0) return default;
            if (index == collection.Count - 1) return default;

            return collection[index + 1];
        }
    }
}
