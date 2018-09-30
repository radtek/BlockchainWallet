using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using BwCommon.Log;

namespace BwCommon.Cache
{
    public class PhoneVerificationCacheHelper
    {
        private static readonly System.Web.Caching.Cache CachePhoneVerification = null;
        static PhoneVerificationCacheHelper()
        {
            CachePhoneVerification = new System.Web.Caching.Cache();
        }

        /// <summary>
        /// 缓存验证码信息
        /// </summary>
        /// <param name="phoneAreaId"></param>
        /// <param name="phone"></param>
        /// <param name="outTime">保存时间 单位：秒</param>
        /// <param name="type"></param>
        /// <param name="verificationNo"></param>
        public static void SetCache(string phoneAreaId, string phone, int outTime, string type, string verificationNo)
        {
            if (CachePhoneVerification.Get(phoneAreaId + phone + type) != null)
            {
                try
                {
                    CachePhoneVerification.Remove(phoneAreaId + phone + type);
                }
                catch (Exception exception)
                {
                    LogHelper.warn("缓存验证码信息时清楚已存在的键出错：" + exception);
                }
            }
            CachePhoneVerification.Insert(phoneAreaId + phone + type, verificationNo, null, DateTime.Now.AddSeconds(outTime), TimeSpan.Zero);
        }
        /// <summary>
        /// 缓存验证码信息
        /// </summary>
        /// <param name="phoneAreaId"></param>
        /// <param name="phone"></param>
        /// <param name="outTime"></param>
        /// <param name="type"></param>
        /// <param name="verificationNo"></param>
        public static bool CheckVerification(string phoneAreaId, string phone, string type, string verificationNo)
        {
            var temp = CachePhoneVerification.Get(phoneAreaId + phone + type);
            if (temp == null) return false;
            return (string)temp == verificationNo;
        }
    }
}
