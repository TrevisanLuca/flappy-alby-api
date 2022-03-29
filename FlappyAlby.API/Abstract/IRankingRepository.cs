namespace FlappyAlby.API.Abstract;

using FlappyAlby.API.DTOs;

public interface IRankingRepository
{
    IEnumerable<PlayerDto> GetRanking();
    void SaveRanking(PlayerDto player);
}