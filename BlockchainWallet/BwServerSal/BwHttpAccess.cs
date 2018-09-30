using System;
using BwSal;

namespace BwServerSal
{
    /// <summary>
    /// 动态人脸识别Http服务访问类
    /// </summary>
    public class AsHttpAccess : HttpAccess
    {
        private static AsHttpAccess _dfrHttpAccess = null;
        public AsHttpErrorProcess DfrHttpErrorProcess = null;
        #region 构造方法
        private AsHttpAccess()
        {
            DfrHttpErrorProcess = new AsHttpErrorProcess();
        }
        #endregion

        #region 获取当前类实例
        /// <summary>
        /// 获取当前类实例
        /// </summary>
        /// <returns></returns>
        public static AsHttpAccess Single
        {
            get
            {
                if (_dfrHttpAccess == null)
                {
                    _dfrHttpAccess = new AsHttpAccess();
                }
                return _dfrHttpAccess;
            }
        }
        #endregion

        #region 错误处理
        /// <summary>
        /// 本地错误处理
        /// </summary>
        /// <param name="e"></param>
        public override byte[] LocalError(Exception e, out bool isUserReturn)
        {
            if (DfrHttpErrorProcess.ActionHttpLocalError == null)
            {
                isUserReturn = false;
                return null;
            }
            ErrorResultEntity errorResultEntity = DfrHttpErrorProcess.ActionHttpLocalError(e);
            isUserReturn = errorResultEntity.IsReturn;
            if (isUserReturn) return errorResultEntity.Result;
            isUserReturn = false;
            return null;
        }

        /// <summary>
        /// 服务访问错误处理
        /// </summary>
        /// <param name="e"></param>
        public override byte[] ServerError(Exception e, out bool isUserReturn)
        {
            if (DfrHttpErrorProcess.ActionHttpLocalError == null)
            {
                isUserReturn = false;
                return null;
            }
            ErrorResultEntity errorResultEntity = DfrHttpErrorProcess.ActionHttpServerError(e);
            isUserReturn = errorResultEntity.IsReturn;
            return isUserReturn ? errorResultEntity.Result : null;
        }

        /// <summary>
        /// 服务内部访问错误处理
        /// </summary>
        /// <param name="o"></param>
        public override void ServiceError(object o)
        {

        }
        /// <summary>
        /// 再错误处理之前执行
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="o"></param>
        public override void BeforError(ErrorType errorType, object o)
        {
            switch (errorType)
            {
                case ErrorType.LocalError:
                    break;
                case ErrorType.ServerError:
                    break;
                case ErrorType.ServiceError:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("errorType", errorType, null);
            }
        }
        /// <summary>
        /// 在错误处理之后执行
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="o"></param>
        public override void AfterError(ErrorType errorType, object o)
        {

        }
        #endregion
    }

}
