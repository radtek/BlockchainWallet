using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserInfo
{
    public class UpdatePayPasswordModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string PhoneAreaId { get; set; }

        public string VerificationCode { get; set; }
        public string PayPassword { get; set; }
    }
}