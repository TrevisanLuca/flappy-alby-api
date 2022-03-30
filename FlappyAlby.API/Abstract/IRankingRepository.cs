namespace FlappyAlby.API.Abstract;

using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;

public interface IRankingRepository
{
    Task<IEnumerable<PlayerDto>> GetRanking();
    Task<PlayerDto> GetById(int id);
    Task<int?> CreatePlayer(PlayerDto player);
}