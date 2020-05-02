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
    }
}
