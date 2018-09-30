using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.Fans
{
    public class FansGenerationCountModelGet
    {
        public int UserId { get; set; }
    }

    public class FansGenerationCountModelResult
    {
        /// <summary>
        /// 粉丝代数
        /// </summary>
        public int GenerationId { get; set; }
        /// <summary>
        /// 此代人数
        /// </summary>
        public int GenerationCount { get; set; }
    }
}