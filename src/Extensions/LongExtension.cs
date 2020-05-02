namespace NewAge.Infra.Extensions
{
    public static class LongExtension
    {
        /// <summary>
        /// 转Long
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long ToLong(this object obj, long defaultVal = 0)
        {
            if (obj == null)
                return defaultVal;
            if (!long.TryParse(obj.ToStr(), out long retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
