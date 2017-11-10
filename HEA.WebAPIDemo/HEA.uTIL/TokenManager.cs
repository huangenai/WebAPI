using System;
using System.Data;
using System.Web;

namespace HEA.Util
{
    /// <summary>
    /// 令牌缓存管理
    /// </summary>
    public class TokenManager
    {
        static readonly IDataCache RedisCache=new RedisCache();        
        /// <summary>
        /// 获取令牌信息，根据手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>令牌信息</returns>
        public static TokenInfo GetToken(string phone)
        {
            return RedisCache.Get<TokenInfo>(phone);
        }
        /// <summary>
        /// 设置令牌信息，根据手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="model">令牌信息</param>
        public static void SetToken(string phone,TokenInfo model)
        {
            RedisCache.Set(phone, model);
        }
        /// <summary>
        /// 删除令牌信息，根据手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        public static void DeleteToken(string phone)
        {
            RedisCache.Delete(phone);
        }
        /// <summary>
        /// 更新令牌信息，根据手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="model">令牌信息</param>
        public static void UpdateToken(string phone,TokenInfo model)
        {
            RedisCache.Delete(phone);
            RedisCache.Set(phone, model);
        }
    }
}