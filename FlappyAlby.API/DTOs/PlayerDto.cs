namespace FlappyAlby.API.DTOs;

using System.ComponentModel.DataAnnotations;

public record PlayerDto (
    [Required]
    string Name
    );