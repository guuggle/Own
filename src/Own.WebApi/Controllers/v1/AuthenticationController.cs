using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Own.Application.Services.Authentication;
using Own.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Own.WebApi.Controllers.v1
{
    [AllowAnonymous]
    public class AuthenticationController : ApiBaseController
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            this._service = service;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _service.Register(
                request.UserName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = await _service.Login(
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapResults(authResult)),
                errors => Problem(errors)
            );
        }


        private static AuthenticationResponse MapResults(AuthenticationResult result)
        {
            return new AuthenticationResponse()
            {
                Id = result.Id,
                UserName = result.UserName,
                Email = result.Email,
                Token = result.Token
            };
        }
    }
}
