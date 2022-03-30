namespace FlappyAlby.API.Abstract;

using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;

public interface IRankingRepository
{
    Task<IEnumerable<Player>> GetRanking(int topX);
    Task<int> AddPlayer(PlayerDto player);
}