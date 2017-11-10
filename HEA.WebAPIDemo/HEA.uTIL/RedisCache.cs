using System;
using System.IO;
using ServiceStack.Redis;

namespace HEA.Util
{
    /// <summary>
    /// Redis缓存服务器
    /// 客户端下载：https://github.com/MSOpenTech/redis/releases
    /// 服务端下载：https://github.com/ServiceStack/ServiceStack.Redis
    /// </summary>
    public class RedisCache:IDataCache
    {
        private static RedisClient _redis = null;
        /// <summary>
        /// Redis客户端
        /// </summary>
        public static RedisClient Redis
        {
            get
            {
                if (_redis == null)
                {
                    _redis = new RedisClient("127.0.0.1", 5520);//要开启服务器才能连接
                }
                return _redis;
            }
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型（对象必须可序列变化，否则可以作为Object类型取出再类型转换，不然会报错）</typeparam>
        /// <param name="key">缓存key</param>
        /// <returns>对象</returns>
        public T Get<T>(string key)
        {
            return Redis.Get<T>(key);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="depFile">路径</param>
        /// <returns>对象</returns>
        public T Get<T>(string key, string depFile)
        {
            string timeKey = key + "_time";
            if (Redis.Exists(timeKey) > 0 && Redis.Exists(key) > 0)
            {
                DateTime objTime = Get<DateTime>(timeKey);
                T objCache = Get<T>(key);
                if (File.Exists(depFile))
                {
                    FileInfo fi = new FileInfo(depFile);
                    if (objTime != fi.LastWriteTime)
                    {
                        Delete(key);
                        Delete(timeKey);
                        return default(T);
                    }
                    return objCache;
                }
                throw new Exception("文件(" + depFile + ")不存在！");
            }
            return default(T);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回值，表示是否写入成功</returns>
        public bool Set<T>(string key, T value)
        {
            return Redis.Set(key, value);
        }
        /// <summary>
        /// 写入缓存，设置过期时间点
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">过期时间点</param>
        /// <returns>返回值，表示是否写入成功</returns>
        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            return Redis.Set(key, value, expiresAt);
        }
        /// <summary>
        /// 写入缓存，设置过期秒数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresSecond">过期秒数</param>
        /// <returns>返回值，表示是否写入成功</returns>
        public bool Set<T>(string key, T value, int expiresSecond)
        {
            return Redis.Set(key, value, DateTime.Now.AddSeconds(expiresSecond));
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="depFile">文件路径</param>
        /// <returns>返回值，表示是否写入成功</returns>
        public bool Set<T>(string key, T value, string depFile)
        {
            bool ret = Redis.Set(key, value);
            if (ret && File.Exists(depFile))
            {
                FileInfo fi = new FileInfo(depFile);
                DateTime lastWriteTime = fi.LastWriteTime;
                return Redis.Set(key + "_time", lastWriteTime);
            }
            return false;
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>返回值，表示是否删除成功</returns>
        public int Delete(string key)
        {
            return Redis.Del(key);
        }
        /// <summary>
        /// 删除多个缓存
        /// </summary>
        /// <param name="keys">缓存Key数组</param>
        /// <returns>返回值，表示是否删除成功</returns>
        public int Delete(string[] keys)
        {
            return Redis.Del(keys);
        }
        //~RedisCache()
        //{
        //    if (_redis != null)
        //    {
        //        _redis.Shutdown();
        //    }
        //}
        /// <summary>
        /// 在应用程序退出之前，调用Dispose释放Memcached客户端连接
        /// </summary>
        public void Dispose()
        {
            if (_redis != null)
            {
                _redis.Shutdown();//调用Dispose释放Redis客户端连接
            }
        }
    }
}