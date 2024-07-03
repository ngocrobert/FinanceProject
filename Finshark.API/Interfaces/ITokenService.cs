using Finshark.API.Models;

namespace Finshark.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
