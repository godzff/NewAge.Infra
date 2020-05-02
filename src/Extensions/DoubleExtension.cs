namespace NewAge.Infra.Extensions
{
    public static class DoubleExtension
    {
        /// <summary>
        /// 转Double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(this object obj, double defaultVal = 0)
        {
            if (obj == null)
                return defaultVal;
            if (!double.TryParse(obj.ToStr(), out double retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
