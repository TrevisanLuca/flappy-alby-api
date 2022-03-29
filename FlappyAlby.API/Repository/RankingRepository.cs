using Bogus;
using FlappyAlby.API.Abstract;
using FlappyAlby.API.DTOs;
using System.Collections.Generic;

namespace FlappyAlby.API.Repository
{
    public class RankingRepository : IRankingRepository
    {
        private IEnumerable<PlayerDto> _ranking;

        public RankingRepository()
        {
            _ranking = Initialize();
        }

        private IEnumerable<PlayerDto> Initialize()
        {
            var faker = new Faker();
            return Enumerable.Range(1, 10)
                .Select((index, index1) => new PlayerDto(faker.Name.FirstName(), faker.Date.Timespan(TimeSpan.FromMinutes(5)), index + index1))
                .OrderBy(player => player.Total).ToList();
        }

        public IEnumerable<PlayerDto> GetRanking()
        {
            return _ranking;
        }

        public void SaveRanking(PlayerDto player)
        {
            var temp = _ranking.ToList();
            temp.Add(player);
            _ranking = temp.OrderBy(player => player.Total).Take(10);         
        }
    }
}
