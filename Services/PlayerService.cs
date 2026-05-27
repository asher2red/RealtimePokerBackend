using RealtimePokerBackend.Data;
using RealtimePokerBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace RealtimePokerBackend.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    private readonly IDistributedCache _cache;

    public PlayerService(AppDbContext db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<List<Player>> GetPlayers()
    {
        const string cacheKey = "players";

        var cachedPlayers = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedPlayers))
        {
            Console.WriteLine("CACHE HIT");

            return JsonSerializer.Deserialize<List<Player>>(cachedPlayers)!;
        }

        Console.WriteLine("CACHE MISS");

        var players = await _db.Players.ToListAsync();

        var serializedPlayers = JsonSerializer.Serialize(players);

        await _cache.SetStringAsync(
            cacheKey, 
            JsonSerializer.Serialize(players), 
            new DistributedCacheEntryOptions{
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            }   
        );

        return players;
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

        await _cache.RemoveAsync("players");
        Console.WriteLine("Player cache invalidated");
        
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

        await _cache.RemoveAsync("players");
        Console.WriteLine("Player cache invalidated");

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

        await _cache.RemoveAsync("players");
        Console.WriteLine("Player cache invalidated");
        
        return true;
    }
}