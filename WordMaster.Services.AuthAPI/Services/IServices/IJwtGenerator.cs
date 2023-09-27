using WordMaster.Services.AuthAPI.Models;

namespace WordMaster.Services.AuthAPI.Services.IServices
{
    public interface IJwtGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
