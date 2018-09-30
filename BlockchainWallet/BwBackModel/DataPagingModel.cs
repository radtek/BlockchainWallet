using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel
{
    /// <summary>
    /// 获取数据内容页基类
    /// </summary>
    public class HeadDataBaseModelSend
    {
        /// <summary>
        /// 数据分页
        /// </summary>
        public DataPagingModelSend DataPagingModel { get; set; }
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    public class DataPagingModelSend
    {
        private int _startSize = 1;
        /// <summary>
        /// 开始页
        /// </summary>
        public int StartSize
        {
            get { return _startSize; }
            set
            {

                _startSize = value <= 0 ? 1 : value;
            }
        }

        private int _pageCount = 40;
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set { }
        }
    }

    /// <summary>
    /// 返回分页数据
    /// </summary>
    public class DataPagingModelGet
    {
        public DataPagingModelGet()
        {

        }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}
