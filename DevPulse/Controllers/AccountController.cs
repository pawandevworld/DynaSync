using System.Security.Cryptography;
using System.Text;
using DevPulse.Data;
using DevPulse.DTOs;
using DevPulse.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  DevPulse.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseDevPulseController
{
    
    [HttpPost("register")]//  account/register


    // We can pass the user information(username, password) in many ways. HTTPHeader, 
    // Body of HTTP request  or querystring parameters
    // Since AccountController is ceriving from the BaseDevPulseController
    // One of the features of [ApiController] is to autobinding to parameters in
    // our controller (username, password)  in this case
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {

        if (await UserExists(registerDto.Username)) return BadRequest("User Name is taken");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
          UserName = registerDto.Username.ToLower(),
          PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)), //Hash password
          PasswordSalt = hmac.Key, //salt the password
          FirstName = registerDto.Firstname,
          LastName = registerDto.Lastname
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        //get user from database
        var user = await context.Users.FirstOrDefaultAsync(x => 
        x.UserName == loginDto.Username.ToLower());

        if(user==null) return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for(int i =0; i<computeHash.Length; i++)
        {
            if (computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
        }

        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }

}