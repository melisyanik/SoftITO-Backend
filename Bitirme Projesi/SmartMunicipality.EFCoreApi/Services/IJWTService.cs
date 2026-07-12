using global::SmartMunicipality.MODEL;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user, IList<string> roles);
    }
}