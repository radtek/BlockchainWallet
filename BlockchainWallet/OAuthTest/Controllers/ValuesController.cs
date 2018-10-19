using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuthTest.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult GetTicket()
        {
            //TO DO
            return Json(new TicketModel() { Ticket = Guid.NewGuid().ToString() });
        }
        public class TicketModel
        {
            public string Ticket { get; set; }
        }
    }
}
