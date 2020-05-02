namespace NewAge.Infra.Extensions
{
    public static class DecimalExtension
    {
        /// <summary>
        /// 转Decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj, decimal defaultVal = 0)
        {
            if (obj == null)
                return defaultVal;
            if (!decimal.TryParse(obj.ToStr(), out decimal retVal))
                retVal = defaultVal;
            return retVal;
        }
    }
}
