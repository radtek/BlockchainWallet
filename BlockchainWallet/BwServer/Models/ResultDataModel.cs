using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models
{
    public class ResultDataModel<T>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Messages { get; set; }
        /// <summary>
        /// Json数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 分页数据返回
        /// </summary>
        public DataPagingModelResult DataPagingResult { get; set; }
    }
}