using RealtimePokerBackend.Models;

public class PlayerService
{
    private readonly List<Player> _players = new List<Player>
    {
        new() { Id = 1, Username = "PokerKing", Chips = 2500 },
        new() { Id = 2, Username = "RoyalFlush", Chips = 3000 }
    };

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public Player CreatePlayer(string username, int chips)
    {
        var newPlayer = new Player
        {
            Id = _players.Count + 1,
            Username = username,
            Chips = chips
        };

        _players.Add(newPlayer);

        return newPlayer;
    }

    public Player? UpdatePlayer(int id, string username, int chips)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);

        if (player == null)
        {
            return null;
        }

        player.Username = username;
        player.Chips = chips;

        return player;
    }

    public bool DeletePlayer(int id)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);

        if (player == null)
        {
            return false;
        }

        _players.Remove(player);
        return true;
    }
}