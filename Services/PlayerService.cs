using RealtimePokerBackend.Data;
using RealtimePokerBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace RealtimePokerBackend.Services;

public class PlayerService
{
    private readonly AppDbContext _db;

    public PlayerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Player>> GetPlayers()
    {
        return await _db.Players.ToListAsync();
    }

    public async Task<Player> CreatePlayer(string username, int chips)
    {
        var player = new Player
        {
            Username = username,
            Chips = chips
        };

        _db.Players.Add(player);
        await _db.SaveChangesAsync();

        return player;
    }

    public async Task<Player?> UpdatePlayer(int id, string username, int chips)
    {
        var player = await _db.Players.FindAsync(id);

        if (player == null)
        {
            return null;
        }

        player.Username = username;
        player.Chips = chips;

        await _db.SaveChangesAsync();

        return player;
    }

    public async Task<bool> DeletePlayer(int id)
    {
        var player = await _db.Players.FindAsync(id);

        if (player == null)
        {
            return false;
        }

        _db.Players.Remove(player);
        await _db.SaveChangesAsync();
        
        return true;
    }
}