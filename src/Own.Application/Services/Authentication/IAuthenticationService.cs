using System.Threading.Tasks;
using Own.Domain.OResult;

namespace Own.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<OResult<AuthenticationResult>> Register(string userName, string email, string password);
        Task<OResult<AuthenticationResult>> Login(string email, string password);
    }
}