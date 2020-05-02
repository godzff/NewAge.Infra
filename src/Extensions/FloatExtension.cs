namespace NewAge.Infra.Extensions
{
    public static class FloatExtension
    {
        /// <summary>
        /// 转Float
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float ToInt(this object obj, float defaultVal = 0)
        {
            if (obj == null)
                return defaultVal;
            if (!float.TryParse(obj.ToStr(), out float retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
