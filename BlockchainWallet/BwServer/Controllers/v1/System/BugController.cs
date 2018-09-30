using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwDal.System;
using BwServer.Models;
using BwServer.Models.v1.System;

namespace BwServer.Controllers.v1.System
{
    public class BugController : ApiController
    {
        private readonly BugDal _bugDal = new BugDal();
        public IHttpActionResult SubmitBug(BugModelGet modelGet)
        {
            int rows = _bugDal.SubmitBug(modelGet.UserId, modelGet.Content, modelGet.Type);
            return Json(new ResultDataModel<BugModelGet>() { Code = rows == 1 ? 0 : -1, Messages = rows == 1 ? "" : "提交失败" });
        }
    }
}