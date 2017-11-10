namespace HEA.Model
{
    /// <summary>
    /// Api请求数据结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Api请求状态
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 数据结果
        /// </summary>
        public object result { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 构造函数，空
        /// </summary>
        public ApiResult() { }
        /// <summary>
        /// 构造函数，初始化消息
        /// </summary>
        /// <param name="message">消息内容</param>
        public ApiResult(string message)
        {
            code = "0";
            result = "";
            this.message = message;
        }
        /// <summary>
        /// 构造函数，初始化请求状态，消息
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">消息内容</param>
        public ApiResult(string code, string message)
        {
            this.code = code;
            this.message = message;
            result = "";
        }
        /// <summary>
        /// 构造函数，初始化请求状态，消息，结果
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">消息内容</param>
        /// <param name="result">结果</param>
        public ApiResult(string code, string message, object result)
        {
            this.code = code;
            this.result = result;
            this.message = message;
        }
    }
    /// <summary>
    /// Api请求数据结果
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// Api请求状态
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 数据结果
        /// </summary>
        public T result { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 构造函数，初始化消息
        /// </summary>
        /// <param name="message">消息内容</param>
        public ApiResult(string message)
        {
            code = "0";
            this.message = message;
            result = default(T);
        }
        /// <summary>
        /// 构造函数，初始化请求状态，消息
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">消息内容</param>
        public ApiResult(string code,string message)
        {
            this.code = code;
            this.message = message;
            result = default(T);
        }
        /// <summary>
        /// 构造函数，初始化请求状态，消息，结果
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">消息内容</param>
        /// <param name="result">结果</param>
        public ApiResult(string code, string message,T result)
        {
            this.code = code;
            this.message = message;
            this.result = result;
        }
        /// <summary>
        /// 构造函数，初始化消息，结果
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="result">结果</param>
        public ApiResult(string message, T result)
        {
            this.code = "0";
            this.message = message;
            this.result = result;
        }
    }
}