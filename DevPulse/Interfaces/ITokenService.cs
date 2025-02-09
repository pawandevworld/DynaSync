using DevPulse.Entities;

namespace DevPulse;

public interface ITokenService
{
 string CreateToken(AppUser user);
    
}