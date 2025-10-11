using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.DTOs;

public class AddWalkRequestDTO
{   [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [Required]
    [StringLength(100)]
    public string? Description { get; set; }
    [Required]
    [Range(0,50)]
    public double LengthinKm { get; set; }
    [Required]

    public string? WalkImageUrl { get; set; }
    [Required]

    public Guid DifficultyId { get; set; }
    [Required]

    public Guid RegionId { get; set; }
}
