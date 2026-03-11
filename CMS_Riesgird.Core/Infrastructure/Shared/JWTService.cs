using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CMS_Riesgird.Core.Core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Core.Core.Services;


namespace CMS_Riesgird.Core.Infrastructure.Shared
{
    public class JWTService : IJWTService
    {
        public JWTSettings _settings { get; }
        public JWTService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWToken(Users user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var roleName = user.Role?.Name ?? "User";
            var roleId = user.RoleId.ToString();
            var roleLevel = user.Role?.Level.ToString() ?? "0";

            var claims = new[] {
              new Claim(ClaimTypes.Name, user.FullName),
              new Claim(ClaimTypes.Email, user.Email),
              new Claim(ClaimTypes.Locality, user.Position ?? string.Empty),
              new Claim(ClaimTypes.Role, roleName),
              new Claim("UserId",user.Id.ToString()),
              new Claim("roleId", roleId),
              new Claim("level", roleLevel)
          };

            var payload = new JwtPayload(
                            _settings.Issuer
                            , _settings.Audience
                            , claims
                            , DateTime.UtcNow
                            , DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
