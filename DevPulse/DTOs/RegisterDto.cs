using System.ComponentModel.DataAnnotations;

namespace DevPulse.DTOs;

public class RegisterDto
{

//We can also use DataAnnotation like [Required] [MaxLength(100)]
[Required]
public string Username { get; set; } = string.Empty;

[Required]
public string Firstname {get; set;} = string.Empty;

[Required]
public string Lastname {get; set;} = string.Empty;

[Required]
[StringLength(8, MinimumLength = 4)]
public string Password { get; set; } = string.Empty;



}