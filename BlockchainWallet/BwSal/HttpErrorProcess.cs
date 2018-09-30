using System;

namespace BwSal
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public static class HttpErrorProcess
    {
        /// <summary>
        /// HTTP错误统一处理
        /// 在所有Http自定义错误错误处理之前执行
        /// bool:是否继续执行
        /// </summary>
        public static Func<int, string, bool> ActionHttpError;
        /// <summary>
        /// TOKEN验证失败
        /// </summary>
        public static Action<int, string> ActionTokenVerifyFail;
        /// <summary>
        /// 服务器异常
        /// </summary>
        public static Action<int, string> ActionServerError;
        /// <summary>
        /// 数据库异常
        /// </summary>
        public static Action<int, string> ActionDatabaseError;
        /// <summary>
        /// 用户无权限
        /// </summary>
        public static Action<int, string> ActionUserNoAuthority;
        /// <summary>
        /// Post数据为空
        /// </summary>
        public static Action<int, string> ActionPostDataIsNull;
        /// <summary>
        /// 请求有误
        /// </summary>
        public static Action<int, string> ActionRequestError;
    }
}
