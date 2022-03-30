namespace FlappyAlby.API.Repository;

using FlappyAlby.API.Abstract;
using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;

public class RankingRepository : IRankingRepository
{        
    public async Task<IEnumerable<Player>> GetRanking(int topX)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreatePlayer(PlayerDto player)
    {
        throw new NotImplementedException();
    }
}