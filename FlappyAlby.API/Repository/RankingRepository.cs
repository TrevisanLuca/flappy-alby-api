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
    public async Task<IEnumerable<RankingDto>> GetRanking(int topX)
    {
        var rankings = await _context.Rankings
            .Include(r => r.Player)
            .OrderBy(r => r.Total).Take(topX).ToListAsync();
        return rankings.Select(r => new RankingDto(r.Player.Name, r.Total));
    }

    public async Task<RankingDto?> GetById(int id)
    {
        var ranking = await _context.Rankings.FindAsync(id);
        return ranking is null ? null : new RankingDto(ranking.Player!.Name, ranking.Total);
    }
    public async Task<int> Create(RankingDto ranking)
    {
        var player = await _context.Players.SingleOrDefaultAsync(p => p.Name == ranking.PlayerName);

        if (player is null)
        {
            var added = await _context.AddAsync(new Player(ranking.PlayerName));
            player = added.Entity;
            await _context.SaveChangesAsync();
        }

        var newRanking = new Ranking((int)player.Id!, ranking.Total);
        var dbEntry = await _context.AddAsync(newRanking);
        await _context.SaveChangesAsync();
        return (int)player.Id!;
    }
}