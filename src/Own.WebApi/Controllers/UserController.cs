using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Own.Application;
using Own.Core;

namespace Own.WebApi.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly ISysUserService _service;

        public UserController(ISysUserService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Get Sys User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public SysUser GetSysUser(string userId)
        {
            return _service.GetSysUser(userId);
        }
    }
}
