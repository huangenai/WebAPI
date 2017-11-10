using System;
using System.Security.Cryptography;
using System.Text;

namespace EasyPark.Util
{
    /// <summary>
    /// 令牌帮助类
    /// </summary>
    public class TokenHelper
    {
        #region Verify(校验令牌)
        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <param name="authenticator">校验串</param>
        /// <returns>校验结果</returns>
        public static bool Verify(string timestamp, string authenticator)
        {
            return Md5Encry(timestamp).Equals(authenticator);
        }
        #endregion
        #region Md5Encry(Md5加密)
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="text">加密源</param>
        /// <returns></returns>
        public static string Md5Encry(string text)
        {
            return Md5(text, Encoding.UTF8);
        }
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="text">加密源</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        private static string Md5(string text, Encoding encoding)
        {
            const string secret = "Eshore!@#";
            byte[] temp = encoding.GetBytes(text + secret);
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(temp, 0, temp.Length)).Replace("-", "");
        }
        #endregion
        #region 生成唯一令牌(GetGuidToken)
        /// <summary>
        /// 生成绝对唯一字符串，用于令牌
        /// </summary>
        /// <returns></returns>
        public static string GetGuidToken()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
        #endregion
    }
}
