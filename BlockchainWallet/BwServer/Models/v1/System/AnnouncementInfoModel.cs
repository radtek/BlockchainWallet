namespace BwServer.Models.v1.System
{
    public class AnnouncementInfoModelGet
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PublishEmployeeId { get; set; }
        public string Content { get; set; }
        public string DisplayTime { get; set; }
        public int UpdateEmployeeId { get; set; }
    }

    public class AnnouncementInfoModelResult
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PublishEmployeeId { get; set; }
        public string PublishEmployeeName { get; set; }
        public string Content { get; set; }
        public string PublishTime { get; set; }
        public string DisplayTime { get; set; }
        public int UpdateEmployeeId { get; set; }
        public string PubliUpdateTimeshTime { get; set; }
    }
}