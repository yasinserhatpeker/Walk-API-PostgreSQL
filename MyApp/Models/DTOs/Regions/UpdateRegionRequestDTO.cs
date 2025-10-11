using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.DTOs;

public class UpdateRegionRequestDTO
{
   [Required]
   [MinLength(3, ErrorMessage = "Name must have minimum 3 characters")]
  public string? Name { get; set; } 
}
