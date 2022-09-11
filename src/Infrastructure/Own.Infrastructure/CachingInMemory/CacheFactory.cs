using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Own.Infrastructure.CachingInMemory
{
    public static class CacheFactory
    {
        private static readonly IMemoryCache memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
        private static readonly ConcurrentDictionary<string, DateTime> keyDict = new ConcurrentDictionary<string, DateTime>();
        #region 获取缓存

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllKeys()
        {
            return keyDict.Keys.ToList();
        }

        /// <summary>
        /// 取得缓存数据
        /// </summary>
        /// <typeparam name="T">类型值</typeparam>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            memoryCache.TryGetValue<T>(key, out T value);

            return value;
        }

        #endregion 获取缓存

        #region 新增缓存

        /// <summary>
        /// 设置缓存(绝对时间过期+滑动过期:比如滑动过期设置半小时,绝对过期时间设置2个小时，
        /// 那么缓存开始后只要半小时内没有访问就会立马过期,如果半小时内有访问就会向后顺延半小时，但最多只能缓存2个小时)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        /// <param name="slidingSpan">滚动过期时间</param>
        /// <param name="absoluteSpan">绝对过期时间</param>
        public static void Create<T>(string key, T value, TimeSpan? slidingSpan = null, TimeSpan? absoluteSpan = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (memoryCache.TryGetValue(key, out T v))
                memoryCache.Remove(key);

            if (!keyDict.ContainsKey(key))
            {
                keyDict.TryAdd(key, DateTime.Now);
            }

            ICacheEntry entry = memoryCache.CreateEntry(key);
            entry.Value = value;
            entry.SlidingExpiration = slidingSpan;
            entry.AbsoluteExpirationRelativeToNow = absoluteSpan;
            entry.RegisterPostEvictionCallback((k, value, reason, state) =>
            {
                string ks = Convert.ToString(k);
                if (reason != EvictionReason.Replaced)
                {
                    keyDict.TryRemove(ks, out var v);
                }
            });
            entry.Dispose();
        }

        #endregion 新增缓存

        #region 清空缓存

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">关键字</param>
        public static void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            memoryCache.Remove(key);
            keyDict.TryRemove(key, out _);
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public static void Clear()
        {
            foreach (string key in keyDict.Keys)
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    memoryCache.Remove(key);
                }
            }
            keyDict.Clear();
        }

        #endregion 清空缓存
    }
}
