using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HEA.Util
{
    public class IocManager
    {
        private static IocManager _intance = null;
        private static object _iocLocker = new object();
        public static IocManager Intance
        {
            get
            {
                if (_intance == null)
                {
                    lock (_iocLocker)
                    {
                        if (_intance == null)
                        {
                            _intance = new IocManager();
                        }
                    }
                }
                return _intance;
            }
        }

        /// <summary>
        /// 避免外界new IocManager对象
        /// </summary>
        private IocManager()
        {

        }

        public T Reslove<T>()
        {
            throw new NotImplementedException();
        }
    }
}