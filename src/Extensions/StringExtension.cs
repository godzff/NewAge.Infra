using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NewAge.Infra.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 验证数据是否为无效数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }
        /// <summary>
        /// 验证数据是否为无效数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToStr(this object source) {
            return source?.ToString().Trim() ?? string.Empty;
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <param name="encoding">加密采用的编码方式,为null时默认UTF-8</param>
        /// <returns></returns>
        public static string Base64Encode(this string source, Encoding encoding = null)
        {
            byte[] bytes;
            bytes = encoding == null ? Encoding.UTF8.GetBytes(source) : encoding.GetBytes(source);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return source;
            }
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="source">待解密的密文</param>
        /// <param name="encoding">解密采用的编码方式，注意和加密时采用的方式一致,为null时默认UTF-8</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(this string source, Encoding encoding = null)
        {
            byte[] bytes = Convert.FromBase64String(source);            
            try
            {
                return encoding == null ? Encoding.UTF8.GetString(bytes) : encoding.GetString(bytes);
            }
            catch
            {
                return source;
            }
        }
        /// <summary>
        /// 转为首字母大写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToFirstUpperStr(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        /// <summary>
        /// 转为首字母小写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToFirstLowerStr(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        /// <summary>
        /// 转为网络终结点IPEndPoint
        /// </summary>=
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static IPEndPoint ToIPEndPoint(this string str)
        {
            try
            {
                string[] strArray = str.Split(':').ToArray();
                string addr = strArray[0];
                int port = Convert.ToInt32(strArray[1]);
                return new IPEndPoint(IPAddress.Parse(addr), port);
            }
            catch
            {
                return null;
            }
        }
    }
}
