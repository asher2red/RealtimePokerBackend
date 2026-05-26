using System.Data.Common;
using System.Net.Security;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using RealtimePokerBackend.Models;
using RealtimePokerBackend.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public IActionResult GetPlayers()
    {
        return Ok(_playerService.GetPlayers());
    }

    [HttpPost]
    public IActionResult CreatePlayer([FromBody] CreatePlayerRequest request)
    {
        var player = _playerService.CreatePlayer(request.Username, request.Chips);
        return Ok(player);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePlayer(int id, [FromBody] CreatePlayerRequest request)
    {
        var player = _playerService.UpdatePlayer(id, request.Username, request.Chips);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePlayer(int id)
    {
        var deleted = _playerService.DeletePlayer(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}