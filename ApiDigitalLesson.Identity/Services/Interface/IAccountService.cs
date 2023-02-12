using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Request;

namespace ApiDigitalLesson.Identity.Services.Interface
{
    public interface IAccountService
    {
        Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string uri);
        Task<BaseResponse<string>> RegisterAsync(RegisterRequest request, string uri);
        Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPasswordAsync(ForgotPasswordRequest request, string uri);
        Task<BaseResponse<string>> ResetPasswordAsync(string userId, ResetPasswordRequest request);
        Task<BaseResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenRequest request);
        Task<BaseResponse<string>> LogoutAsync(string emailOrName);
        Task<List<UserListDto>> GetUsers();
    }
}
