namespace NewAge.Infra.Extensions
{
    public static class IntExtension
    {
        /// <summary>
        /// 转Int
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt(this object obj, int defaultVal = 0)
        {
            if (obj == null)
                return defaultVal;
            if (!int.TryParse(obj.ToStr(), out int retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
