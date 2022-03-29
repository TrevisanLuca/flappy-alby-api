using System.ComponentModel.DataAnnotations;

namespace FlappyAlby.API.DTOs;

public record PlayerDto (
    [Required]
    string Name,
    [Required]
    TimeSpan Total,
    [Required][Range(1,int.MaxValue)]
    int? Id = default
    );