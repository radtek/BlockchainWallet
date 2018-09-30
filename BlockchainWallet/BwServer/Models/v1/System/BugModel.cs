namespace BwServer.Models.v1.System
{
    public class BugModelGet
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
    }
    public class BugModelResult
    {
        public int Id;
        public string Content { get; set; }
        public string Type { get; set; }
        public int SubmitUserId { get; set; }
        public string SubmitUserName { get; set; }
        public string SubmitUserPhoneAreaId { get; set; }
        public string SubmitUserPhone { get; set; }
        public string SubmitTime { get; set; }
        /// <summary>
        /// 处理状态  0等待处理 1已处理
        /// </summary>
        public string State { get; set; }
        public string DisposeTime { get; set; }
        public string DisposeEmployeeId { get; set; }
        public string Remark { get; set; }
    }
}