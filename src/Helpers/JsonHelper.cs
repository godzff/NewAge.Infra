using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewAge.Infra.Helpers
{
    /// <summary>
    /// Json操作
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T JsonTo<T>(this string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="isConvertToSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJson(this object source, bool isConvertToSingleQuotes = false)
        {
            var timeFormat = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            var result = JsonConvert.SerializeObject(source, Formatting.None,timeFormat);
            if (isConvertToSingleQuotes)
                result = result.Replace("\"", "'");
            return result;
        }
    }
}
