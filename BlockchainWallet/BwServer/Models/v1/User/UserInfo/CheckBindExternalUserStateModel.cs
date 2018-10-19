using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserInfo
{
    public class CheckBindExternalUserStateModelGet
    {
        public int UserId { get; set; }
        public string ExternalUserId { get; set; }
        public int AppId { get; set; }
    }
    public class CheckBindExternalUserStateModelResult
    {
        public string OpenUserId { get; set; }
    }
}