using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.CustomerServiceSystem.IdCardCertification
{
    public class UploadIdCardCertificationInfoModelGet
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string FrontImage { get; set; }
        public string ReverseImage { get; set; }
    }

    public class UploadIdCardCertificationInfoModelResult
    {

    }
}