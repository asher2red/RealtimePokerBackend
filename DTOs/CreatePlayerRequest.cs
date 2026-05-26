using System.ComponentModel.DataAnnotations;

namespace RealtimePokerBackend.DTOs;

public class CreatePlayerRequest
{
    [Required]
    [StringLength(20)]
    public string Username { get; set; } = string.Empty;

    [Range(0, 1000000)]
    public int Chips { get; set; }
}