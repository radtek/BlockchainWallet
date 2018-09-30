using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwDal
{
    /// <summary>
    /// 获取数据内容页基类
    /// </summary>
    public class HeadModelGet
    {
        /// <summary>
        /// 数据分页
        /// </summary>
        public DataPagingModelGet DataPagingModel { get; set; }
    }
    /// <summary>
    /// 获取数据内容页基类
    /// </summary>
    public class HeadModelResult
    {
        public HeadModelResult()
        {
        }

        public DataPagingModelResult DataPagingResult { get; set; }
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    public class DataPagingModelGet
    {
        private int _startSize = 0;
        /// <summary>
        /// 开始页
        /// </summary>
        public int StartSize
        {
            get { return _startSize; }
            set { _startSize = (value - 1) > 0 ? value - 1 : 0; }
        }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageCount { get; set; }
    }
    /// <summary>
    /// 返回分页数据
    /// </summary>
    public class DataPagingModelResult
    {
        public DataPagingModelResult() { }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}
