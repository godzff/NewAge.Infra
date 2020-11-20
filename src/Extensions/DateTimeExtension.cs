using System;

namespace NewAge.Infra.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj, DateTime defaultVal = new DateTime())
        {
            if (obj == null)
                return defaultVal;
            if (!DateTime.TryParse(obj.ToStr(), out DateTime retVal))
                retVal = defaultVal;
            return retVal;
        }

        /// <summary>
        /// 秒级时间戳转日期时间
        /// </summary>
        /// <param name="timeSpan">秒级时间戳</param>
        /// <param name="isUtc">是否格林威治时间</param>
        /// <returns></returns>
        public static DateTime TimeStampToDateTime(this long timeSpan, bool isUtc = false)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, (isUtc ? 0 : 8), 0, 0, 0).AddSeconds(timeSpan);
            return dateTime;
        }
        /// <summary>
        /// 毫秒级时间戳转日期时间
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="isUtc">是否格林威治时间</param>
        /// <returns></returns>
        public static DateTime MillisecondsTimeStampToDateTime(this long timeSpan, bool isUtc = false)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, (isUtc ? 0 : 8), 0, 0, 0).AddMilliseconds(timeSpan);
            return dateTime;
        }
    }
}
