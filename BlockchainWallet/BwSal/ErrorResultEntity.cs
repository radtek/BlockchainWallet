namespace BwSal
{
    public class ErrorResultEntity
    {
        /// <summary>
        /// 服务访问出现异常后返回的参数
        /// </summary>
        public byte[] Result { get; set; }
        /// <summary>
        /// 是否需要返回Result
        /// </summary>
        public bool IsReturn { get; set; }

    }

    public class ServiceErrorEntity
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 错误内容
        /// </summary>
        public string messages { get; set; }
    }
}
