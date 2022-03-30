namespace FlappyAlby.API.Repository;

using FlappyAlby.API.Abstract;
using FlappyAlby.API.Data;
using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;
using Microsoft.EntityFrameworkCore;

public class RankingRepository : IRankingRepository
{
    private readonly FlappyDbContext _context;

    public RankingRepository(FlappyDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Player>> GetRanking(int topX)
    {
        var players = await _context.Players.OrderBy(p => p.Total).Take(topX).ToListAsync();
        return players;
    }

    public async Task<Player?> GetById(int id)
    {
        var player = await _context.Players.FindAsync(id);
        return player;
    }
    public async Task<int> AddPlayer(PlayerDto player)
    {
        var newPlayer = new Player(player.Name, player.Total);
        var dbEntry = await _context.AddAsync(newPlayer);
        await _context.SaveChangesAsync();
        return dbEntry.Entity.Id;
    }
}