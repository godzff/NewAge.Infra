namespace NewAge.Infra.Extensions
{
    public static class BooltExtension
    {
        /// <summary>
        /// 转Bool
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static bool ToBool(this object obj, bool defaultVal = false)
        {
            if (obj == null)
                return defaultVal;
            if (!bool.TryParse(obj.ToStr(), out bool retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
