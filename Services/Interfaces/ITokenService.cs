using Microsoft.IdentityModel.Tokens;
using SwaggerAutoAuthentication.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwaggerAutoAuthentication.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
