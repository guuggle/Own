// using FluentValidation;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Own.Application.Interfaces;
// using Own.Domain.Entites;
// using Own.WebApi.Contracts.v1.Requests;
// using Own.WebApi.Filters;
// using System.ComponentModel.DataAnnotations;
// using System.Net.Mime;
// using System.Threading.Tasks;

// namespace Own.WebApi.Controllers.v1
// {
//     [Produces(MediaTypeNames.Application.Json)]
//     public class UserController : ApiBaseController
//     {
//         private readonly IUserService _service;
//         private readonly ILogger<UserController> _logger;
//         private readonly IValidator<CreateUserRequest> _validator;

//         public UserController(IUserService service, ILogger<UserController> logger, IValidator<CreateUserRequest> validator)
//         {
//             this._service = service;
//             this._logger = logger;
//             this._validator = validator;
//         }

//         /// <summary>
//         /// Get Sys User
//         /// </summary>
//         /// <param name="userId"></param>
//         /// <returns></returns>
//         [HttpGet]
//         [Cached(10, 5)]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult<SysUser>> GetSysUser([FromQuery]string userId)
//         {
//             return Ok(await _service.GetSysUser(userId));
//         }

//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         public async Task<IActionResult> CreateUser(CreateUserRequest request)
//         {
//             var result = await _validator.ValidateAsync(request);
//             if (!result.IsValid)
//             {
//                 return BadRequest(result.Errors);
//             }
//             return Ok();
//         }
//     }
// }
