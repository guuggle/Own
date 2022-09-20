using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Own.Infrastructure.CachingInMemory;
using Own.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace Own.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CacheFilter : Attribute, IAsyncResourceFilter
    {
        private readonly int _absoluteDuration;
        private readonly int _slidingDuration;

        /// <summary>
        /// Cache Attribute
        /// </summary>
        /// <param name="absoluteDuration">绝对过期时间, 单位秒</param>
        /// <param name="slidingDuration">滑动过期时间, 单位秒, 小于绝对过期时间</param>
        /// <remarks>
        /// Filters that are implemented as attributes and added directly to controller classes or action methods
        /// cannot have constructor dependencies provided by dependency injection (DI).
        /// Constructor dependencies cannot be provided by DI because:
        ///     Attributes must have their constructor parameters supplied where they're applied.
        ///     This is a limitation of how attributes work.
        /// 相关文档说明
        /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-3.1#dependency-injection-1
        /// </remarks>
        public CacheFilter(int absoluteDuration, int slidingDuration)
        {
            if (slidingDuration > absoluteDuration)
                throw new ArgumentOutOfRangeException(
                    $"sliding duration({slidingDuration}) should be less than absolution duration({absoluteDuration})");
            _absoluteDuration = absoluteDuration;
            _slidingDuration = slidingDuration;
        }

        public CacheFilter()
        {
            _absoluteDuration = 60 * 10;
            _slidingDuration = 60 * 5;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // TODO: 性能优化
            string key = $"{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString.Value}";

            var cachedValue = CacheFactory.Get<object>(key);
            if (cachedValue != null)
            {
                context.Result = new OkObjectResult(cachedValue);
            }
            else
            {
                var ctx = await next();
                if (ctx?.Result != null && ctx.Result is OkObjectResult obj)
                {
                    CacheFactory.Create(
                        key,
                        obj.Value.Clone(),
                        TimeSpan.FromSeconds(_slidingDuration),
                        TimeSpan.FromSeconds(_absoluteDuration));
                }
            }

        }
    }
}
