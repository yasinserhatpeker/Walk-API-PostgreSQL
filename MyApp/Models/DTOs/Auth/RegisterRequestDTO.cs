using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.DTOs.Auth;

public class RegisterRequestDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public string[] Roles { get; set; }
}
