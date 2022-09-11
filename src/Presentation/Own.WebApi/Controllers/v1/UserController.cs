using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Own.Application.Interfaces;
using Own.Domain.Entites;
using Own.WebApi.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Own.WebApi.Controllers.v1
{
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            this._service = service;
            this._logger = logger;
        }

        /// <summary>
        /// Get Sys User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Cached(10, 5)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SysUser>> GetSysUser([FromQuery]string userId)
        {
            _logger.LogTrace("LogTrace");
            _logger.LogDebug("LogDebug");
            _logger.LogInformation("LogInformation");
            _logger.LogWarning("LogWarning");
            _logger.LogError("LogError");
            _logger.LogCritical("LogCritical");
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("null value detected!");
            }
            return Ok(await _service.GetSysUser(userId));
        }
    }
}
