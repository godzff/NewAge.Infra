using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace NewAge.Infra.Helpers
{
    public static class MyHelper
    {
        #region 验证手机号
        /// <summary>
        /// 验证手机号是否正确
        /// </summary>
        /// <param name="phoneNumber">待验证的手机号</param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            #region 正则验证区间说明
            /*
            手机号码前三位列表：
            13(老)号段：130、131、132、133、134、135、136、137、138、139
            14(新)号段：1400、1410、1440、145、146、147、148、149
            15(新)号段：150、151、152、153、155、156、157、158、159
            16(新)号段：165、166
            17(新)号段：170、171、172、173、175、176、177、178、1740（0-5）、1740（6-9）、1740（10-12）
            18(3G)号段：180、181、182、183、184、185、186、187、188、189
            19(新)号段：198、199
            13(老)号段
            130：中国联通，GSM
            131：中国联通，GSM
            132：中国联通，GSM
            133：中国联通，后转给中国电信，CDMA
            134：中国移动，GSM
            135：中国移动，GSM
            136：中国移动，GSM
            137：中国移动，GSM
            138：中国移动，GSM
            139：中国移动，GSM
            14号段
            1400（0-9）号段：中国联通，物联网网号
            1410（0-9）号段：中国电信，物联网网号
            1440（0-9）号段：中国移动，物联网网号
            145：中国联通，上网卡
            146：中国联通，公众移动通信网号（物联网业务专用号段）
            147：中国移动，上网卡
            148：中国移动，公众移动通信网号（物联网业务专用号段）
            149：中国电信
            15(新)号段
            150：中国移动，GSM
            151：中国移动，GSM
            152：中国联通，网友反映实际是中国移动的
            153：中国联通，后转给中国电信，CDMA
            155：中国联通，GSM
            156：中国联通，GSM
            157：中国移动，GSM
            158：中国移动，GSM
            159：中国移动，GSM
            16(新)号段
            165：中国移动，公众移动通信网号（移动通信转售业务专用号段）
            166：中国联通，公众移动通信网号
            17(4G)号段
            170：虚拟运营商
            171：联通
            172：移动
            173：电信
            1740（0-5）：中国电信，卫星移动通信业务号
            1740（6-9）：工业和信息化部应急通讯保障中心，卫星移动通信业务号（用于国际应急通讯需求）
            1740（10-12）：工业和信息化部应急通讯保障中心，卫星移动通信业务号（用于国际应急通讯需求）
            175：联通
            176：联通
            177：电信
            178：移动
            18(3G)号段
            180：中国电信，3G
            181：中国电信，3G
            182：中国移动，3G
            183：中国移动，3G
            184：中国移动，3G
            185：中国联通，3G
            186：中国联通，3G
            187：中国移动，3G
            188：中国移动，3G，TD-CDMA
            189：中国电信，3G，CDMA，天翼189，2008年底开始对外放号
            19新号段
            198：中国移动，公众移动通信网号
            199：中国电信，公众移动通信网号
             */
            #endregion
            Regex rx = new Regex(@"^0{0,1}(13[0-9]|14[0-1]|14[4-9]|15[0-3]|15[5-9]|16[5-6]|17[0-8]|18[0-9]|19[8-9])[0-9]{8}$");
            bool isTrue;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                if (rx.IsMatch(phoneNumber)) //匹配
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            else
            {
                isTrue = false;
            }

            return isTrue;
        }
        #endregion

        #region 对象通过反射进行赋值

        /// <summary>
        /// 属性同步
        /// </summary>
        /// <typeparam name="T">同步目标的类型</typeparam>
        /// <param name="sourceObj">同步源对象</param>
        /// <param name="targetObj">同步目标对象</param>
        /// <param name="ignoreFileds">不需要同步的键值</param>
        public static void AttributeSync<T>(Object sourceObj, ref T targetObj, params string[] ignoreFileds) where T : class
        {
            Type sourceType = sourceObj.GetType();
            Type targetType = targetObj.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            if (ignoreFileds == null)
            {
                ignoreFileds = new string[0];
            }
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                //if(ignoreFileds.Contains(sourceProperty.Name))
                if (ignoreFileds.Any(x => x.Equals(sourceProperty.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    continue;
                }
                foreach (PropertyInfo targetProperty in targetProperties)
                {
                    if (targetProperty.Name.Equals(sourceProperty.Name, StringComparison.CurrentCultureIgnoreCase) && sourceProperty.GetValue(sourceObj, null) != null)
                    {
                        targetProperty.SetValue(targetObj, sourceProperty.GetValue(sourceObj, null), null);
                        break;
                    }
                }
            }
        }

        #endregion

        #region 通过反射比对对象是否相等
        /// <summary>
        /// 对象属性值比对
        /// </summary>
        /// <param name="sourceObj">需要比对对象</param>
        /// <param name="targetObj">需要比对对象</param>
        /// <param name="ignoreFileds">不需要比对的键值</param>
        public static bool ComparisonObject(Object sourceObj, Object targetObj, params string[] ignoreFileds)
        {
            Type sourceType = sourceObj.GetType();
            Type targetType = targetObj.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            if (ignoreFileds == null)
            {
                ignoreFileds = new string[0];
            }
            if (sourceProperties.Count() != targetProperties.Count())
            {
                return false;
            }
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                bool isIn = false;
                if (ignoreFileds.Contains(sourceProperty.Name))
                {
                    continue;
                }
                foreach (PropertyInfo targetProperty in targetProperties)
                {
                    if (targetProperty.Name.Equals(sourceProperty.Name, StringComparison.CurrentCulture))
                    {
                        if (sourceProperty.GetValue(sourceObj, null) == targetProperty.GetValue(targetObj, null))
                        {
                            isIn = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (!isIn)
                {
                    return isIn;
                }
            }
            return true;
        }
        #endregion

        #region 生成验证码
        /// <summary>
        /// 创建指定位数的随机数
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 创建指定位数的纯数字随机数
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode_Number(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(10);
                if (temp == t)
                {
                    return CreateRandomCode_Number(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        #endregion
        #region 根据生成的验证码生成图片流
        public static byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 49.0), 62);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 60; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 36, (FontStyle.Bold | FontStyle.Italic));

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 0, 0);

                //画图片的前景干扰线
                for (int i = 0; i < 220; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion
    }
}
