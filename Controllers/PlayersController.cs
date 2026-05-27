using Microsoft.AspNetCore.Mvc;
using RealtimePokerBackend.DTOs;
using RealtimePokerBackend.Services;
using Microsoft.AspNetCore.Authorization;

namespace RealtimePokerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
        return Ok(await _playerService.GetPlayers());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request)
    {
        var player = await _playerService.CreatePlayer(request.Username, request.Chips);
        return Ok(player);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(int id, [FromBody] CreatePlayerRequest request)
    {
        var player = await _playerService.UpdatePlayer(id, request.Username, request.Chips);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var deleted = await _playerService.DeletePlayer(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}