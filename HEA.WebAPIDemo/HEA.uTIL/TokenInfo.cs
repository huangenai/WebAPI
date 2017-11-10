using System;

namespace HEA.Util
{
    /// <summary>
    /// 令牌信息
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string Imei { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 令牌-唯一
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime TimeOut { get; set; }
        /// <summary>
        /// 构造函数，初始化登录时间以及超时时长
        /// </summary>
        public TokenInfo()
        {
            LoginTime=DateTime.Now;
            TimeOut = DateTime.Now.AddDays(10);
        }
    }
}