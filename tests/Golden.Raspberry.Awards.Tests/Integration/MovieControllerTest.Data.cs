using Golden.Raspberry.Awards.WebAPI.Commands;
using Golden.Raspberry.Awards.WebAPI.Domain.Dto;
using Xunit;

namespace Golden.Raspberry.Awards.Tests.Integration
{
    public partial class MovieControllerTest
    {
        public static TheoryData<AwardRangeResponse> TheoryGetAwardRangeShouldBeReturnCorrectContent
            => new()
            {
                {
                    new AwardRangeResponse()
                    {
                        Min = GetMinProducerAward(), 
                        Max = GetMaxProducerAward(), 
                    }
                }
            };

        private static IEnumerable<ProducerAwardDto> GetMinProducerAward()
        {
            return new List<ProducerAwardDto>()
            {
                {
                    new ProducerAwardDto()
                    {
                        Producer = "Yoram Globus and Menahem Golan",
                        Interval = 1,
                        PreviousWin =  1986,
                        FollowingWin = 1987,
                    }
                },
                {
                    new ProducerAwardDto()
                    {
                        Producer = "Wyck Godfrey, Stephenie Meyer and Karen Rosenfelt",
                        Interval = 1,
                        PreviousWin = 2011,
                        FollowingWin = 2012,
                    }
                },
            }.AsEnumerable();
        }

        private static IEnumerable<ProducerAwardDto> GetMaxProducerAward()
        {
            return new List<ProducerAwardDto>()
            {
                {
                    new ProducerAwardDto()
                    {
                        Producer = "Jerry Weintraub",
                        Interval = 9,
                        PreviousWin = 1980,
                        FollowingWin = 1989,
                    }
                },
            }.AsEnumerable();
        }

        private void RemoveDatabase()
        {
            var dataBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GoldenRaspberryAwards.db");
            if (File.Exists(dataBasePath))
            {
                File.Delete(dataBasePath);
            }
        }
    }
}
