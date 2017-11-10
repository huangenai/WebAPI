using System;

namespace HEA.Util
{
    public interface IDataCache
    {

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns>对象</returns>
        T Get<T>(string key);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="depFile">文件路径</param>
        /// <returns>对象</returns>
        T Get<T>(string key, string depFile);

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回值，表示是否写入成功</returns>
        bool Set<T>(string key, T value);
        /// <summary>
        /// 写入缓存，设置过期时间点
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">过期时间点</param>
        /// <returns>返回值，表示是否写入成功</returns>
        bool Set<T>(string key, T value, DateTime expiresAt);
        /// <summary>
        /// 写入缓存，设置过期秒数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresSecond">过期秒数</param>
        /// <returns>返回值，表示是否写入成功</returns>
        bool Set<T>(string key, T value, int expiresSecond);
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="depFile">文件路径</param>
        /// <returns>返回值，表示是否写入成功</returns>
        bool Set<T>(string key, T value, string depFile);
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>返回值，表示是否删除成功</returns>
        int Delete(string key);
        /// <summary>
        /// 删除多个缓存
        /// </summary>
        /// <param name="keys">缓存Key数组</param>
        /// <returns>返回值，表示是否删除成功</returns>
        int Delete(string[] keys);
    }
}