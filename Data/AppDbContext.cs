using Microsoft.EntityFrameworkCore;
using RealtimePokerBackend.Models;

namespace RealtimePokerBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Player> Players => Set<Player>();
}