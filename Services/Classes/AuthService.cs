using SwaggerAutoAuthentication.Services.Interfaces;
using SwaggerAutoAuthentication.ViewModels;

namespace SwaggerAutoAuthentication.Services.Classes
{
    public class AuthService : IAuthService
    {
        readonly ITokenService tokenService;
        public AuthService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        async Task<UserLoginResponse> IAuthService.LoginUserAsync(UserLoginRequest request)
        {
            var userName = "admin";
            var password = "123456";

            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Username == userName && request.Password == password)
            {
                var generatedTokenInformation = await tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            }

            return response;
        }
    }
}
