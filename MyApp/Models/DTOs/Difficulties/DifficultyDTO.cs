using System;

namespace MyApp.Models.DTOs;

public class DifficultyDTO
{
   public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }    
    
    public string? RegionImageUrl { get; set; }
}
