using System;
using System.Collections;

namespace BwServerSal
{
    /// <summary>
    /// 获取服务访问接口的唯一实例
    /// </summary>
    /// <typeparam name="T">Api类型</typeparam>
    public class SalApiFactory<T> where T : class
    {
        private static Hashtable _salApiCollection = null;

        static SalApiFactory()
        {
            _salApiCollection = new Hashtable();
        }

        public static T GetSalApi()
        {
            string fullName = typeof(T).FullName;
            if (!_salApiCollection.Contains(fullName))
            {
                T t = Activator.CreateInstance<T>();
                _salApiCollection.Add(fullName, t);
            }
            return _salApiCollection[fullName] as T;
        }
    }
}
