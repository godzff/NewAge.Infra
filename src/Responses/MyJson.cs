using NewAge.Infra.Enums;
using NewAge.Infra.Extensions;

namespace NewAge.Infra.Responses
{
    /// <summary>
    /// 无需返回数据时
    /// </summary>
    public class MyJson 
    {
        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get; set; } = "请求成功";
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; } = (int)EMyJson.Success;
        public MyJson(int code = (int)EMyJson.Success, string message = "")
        {
            if (message.IsNullOrWhiteSpace() && code == (int)EMyJson.Success)
                message = "请求成功";
            Code = code;
            Msg = message;
        }
    }
    /// <summary>
    /// 需返回数据集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyJson<T> : MyJson where T : class { 
        /// <summary>
        /// 数据集
        /// </summary>
        public T Data { get; set; }

        public MyJson() : base((int)EMyJson.Success) { }
        public MyJson(int code,T data,string message = "") : base(code, message)
        {
            Data = data;
        }
    }
}
