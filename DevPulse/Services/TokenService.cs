using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevPulse.Entities;
using Microsoft.IdentityModel.Tokens;

namespace DevPulse;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenkey = config["TokenKey"] ?? throw new Exception("Cannot access tokenkey from appsetting");
        if (tokenkey.Length < 64) throw new Exception("Your tokenkey need to be long");
        //Same key is used for dycripting and encrypting
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey));

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserName)
        };
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}