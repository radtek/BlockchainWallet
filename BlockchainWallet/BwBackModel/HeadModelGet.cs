using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel
{
    public class HeadModelGet<T>
    {
        public int Code { get; set; }
        public string Messages { get; set; }
        public T Data { get; set; }
        public DataPagingModelGet DataPagingResult { get; set; }
    }
}
