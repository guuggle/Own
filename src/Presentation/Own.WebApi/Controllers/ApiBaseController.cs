using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Own.WebApi.Controllers
{
    /// <summary>
    /// 控制器基类
    /// <remarks>
    /// 在方法上添加更多ProducesAttribute以支持更多媒体类型
    /// <see cref="https://www.youtube.com/watch?v=hn0OCI76wkk&ab_channel=RahulNath"/>
    /// </remarks>
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
    }
}
