using SwaggerAutoAuthentication.ViewModels;

namespace SwaggerAutoAuthentication.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
