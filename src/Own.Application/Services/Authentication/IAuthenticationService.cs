

using Own.Domain.OResult;

namespace Own.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        OResult<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
        OResult<AuthenticationResult> Login(string email, string password);
    }
}