using System.Diagnostics.CodeAnalysis;

namespace DevPulse.DTOs;

public class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }

}