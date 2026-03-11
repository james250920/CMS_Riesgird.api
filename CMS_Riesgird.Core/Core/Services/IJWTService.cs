using CMS_Riesgird.Core.Core.Settings;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Users user);
    }
}