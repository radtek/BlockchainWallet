using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.CustomerServiceSystem.ReceivablesInformation
{
    public class ThirdCollectionInfoModelGet
    {
        public int UserId { get; set; }
        public string AccountType { get; set; }

    }
    public class ThirdCollectionInfoModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 收款码/收款信息图片
        /// </summary>
        public string CollectionCodeImage { get; set; }
        /// <summary>
        /// 账号类型1:支付宝 2微信
        /// </summary>
        public string AccountType { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public string SubmitTime { get; set; }
        /// <summary>
        /// 客服编号
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public string DisposeTime { get; set; }
        /// <summary>
        /// 处理结果:0等待中 1通过 2不通过
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
    public class UploadThirdCollectionInfoModelGet
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 收款码/收款信息图片
        /// </summary>
        public string CollectionCodeImage { get; set; }
        /// <summary>
        /// 账号类型1:支付宝 2微信
        /// </summary>
        public string AccountType { get; set; }
        public string PayPassowrd { get; set; } 
    }


}