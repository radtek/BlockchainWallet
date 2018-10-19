using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OAuthTest.Controllers
{
    public class CodesController : ApiController
    {
        [HttpGet]
        [Route("api/authorization_code")]
        public HttpResponseMessage Get(string code)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(code, Encoding.UTF8, "text/plain")
            };
        }
    }
}