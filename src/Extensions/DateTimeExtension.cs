﻿using System;

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
        /// 日期时间转秒级时间戳
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="isUtc">是否格林威治时间</param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime dateTime, bool isUtc = false)
        {
            TimeSpan ts = dateTime - new DateTime(1970, 1, 1, (isUtc ? 0 : 8), 0, 0, 0);
            return ts.TotalSeconds.ToLong();
        }
        /// <summary>
        /// 日期时间转毫秒级时间戳
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="isUtc">是否格林威治时间</param>
        /// <returns></returns>
        public static long ToMillisecondTimeStamp(this DateTime dateTime, bool isUtc = false)
        {
            TimeSpan ts = dateTime - new DateTime(1970, 1, 1, (isUtc ? 0 : 8), 0, 0, 0);
            return ts.TotalMilliseconds.ToLong();
        }
    }
}
