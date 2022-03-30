using FlappyAlby.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlappyAlby.API.Data
{
    public class FlappyDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
    }
}
