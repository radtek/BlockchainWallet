using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Common
{
    public class ServerHelper
    {
        public static string GetToken
        {
            get
            {
                return Guid.NewGuid().ToString().Substring(16);
            }
        }
    }
}