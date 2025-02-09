namespace DevPulse.DTOs;

public class RegisterDto
{

//We can also use DataAnnotation like [Required] [MaxLength(100)]
public required string Username { get; set; }
public required string Firstname {get; set;}
public required string Lastname {get; set;}
public required string Password { get; set; }



}