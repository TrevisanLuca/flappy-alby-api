namespace FlappyAlby.API.Abstract;

using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;

public interface IRankingRepository
{
    Task<IEnumerable<RankingDto>> GetRanking(int topX);
    Task<int> Create(RankingDto player);
}