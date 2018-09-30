using System;

namespace BwSal
{
    public interface IIpServer
    {
        /// <summary>
        /// 测试数据连接
        /// </summary>
        /// <param name="ip">Ip地址</param>
        /// <param name="port">端口号</param>
        bool TestConnect(string ip, int port);
        /// <summary>
        /// 连接对象
        /// </summary>
        /// <param name="uri"></param>
        bool TestConnect(Uri uri);

    }
}
