namespace SwaggerAutoAuthentication
{
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }
    }

    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }

    public class AuthService : IAuthService
    {
        readonly ITokenService tokenService;
        public AuthService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        async Task<UserLoginResponse> IAuthService.LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Username == "admin" && request.Password == "123456")
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
