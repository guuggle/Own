using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Own.Infrastructure.Extensions
{
    public static class ClassExtensions
    {
        public static T Clone<T>(this T obj)
            => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(obj));

    }
}
