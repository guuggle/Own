using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Own.WebApi.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
    }
}
