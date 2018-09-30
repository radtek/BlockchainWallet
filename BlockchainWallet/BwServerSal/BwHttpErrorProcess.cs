using System;
using BwSal;

namespace BwServerSal
{
    public class AsHttpErrorProcess
    {
        /// <summary>
        /// 服务访问错误
        /// </summary>
        public Func<Exception, ErrorResultEntity> ActionHttpServerError;
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        public Func<object, ErrorResultEntity> ActionHttpServiceError;
        /// <summary>
        /// 本地错误
        /// </summary>
        public Func<Exception, ErrorResultEntity> ActionHttpLocalError;

        /// <summary>
        /// 服务内部错误处理
        /// </summary>
        public class HttpServiceErrorProcess
        {
            /// <summary>
            /// HTTP错误统一处理
            /// 在所有Http自定义错误错误处理之前执行
            /// bool:是否继续执行
            /// </summary>
            public static Func<ServiceErrorEntity, bool> ActionHttpError;
            /// <summary>
            /// 验证失败
            /// </summary>
            public static Action<ServiceErrorEntity> ActionUserVerifyFail;
            /// <summary>
            /// 服务器异常
            /// </summary>
            public static Action<ServiceErrorEntity> ActionServerError;
            /// <summary>
            /// 数据库异常
            /// </summary>
            public static Action<ServiceErrorEntity> ActionDatabaseError;
            /// <summary>
            /// 用户无权限
            /// </summary>
            public static Action<ServiceErrorEntity> ActionUserNoAuthority;
            /// <summary>
            /// Post数据为空
            /// </summary>
            public static Action<ServiceErrorEntity> ActionPostDataIsNull;
            /// <summary>
            /// 请求有误
            /// </summary>
            public static Action<ServiceErrorEntity> ActionRequestError;
        }
    }
}
