using System;

namespace MyApp.Models.DTOs;

public class WalkDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double LengthinKm { get; set; }

    public string? WalkImageUrl { get; set; }

    public Guid DifficultyId { get; set; }

    public Guid RegionId { get; set; }

    
}
