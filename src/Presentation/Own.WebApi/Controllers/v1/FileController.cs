using Own.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace Own.WebApi.Controllers.v1
{
    public class FileController : ApiBaseController
    {
        /// <summary>
        /// Download
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Octet)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetFile(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileRepo", fileName);
            if (!System.IO.File.Exists(path))
                return BadRequest("file not exist");
            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(path);
            return File(fileBytes, "application/octet-stream", fileName);
        }

        /// <summary>
        /// upload
        /// </summary>
        /// <param name="description">描述</param>
        /// <param name="clientDate">客户端日期</param>
        /// <param name="file">文件</param>
        [HttpPost]
        public void UploadFile(string description, [FromForm] DateTime clientDate, IFormFile file)
        {

        }


        /// <summary>
        /// Test Post Action for V2
        /// </summary>
        /// <param name="testField1">测试域</param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(GroupName = "v2")]
        public string PostSomething(string testField1)
        {
            return string.Empty;
        }
    }
}
