using System;
using System.Data;
using System.Web.Http;
using BwCommon.Cache;
using BwDal.Employee;
using BwServer.Common;
using BwServer.Models;
using BwServer.Models.v1.Employee.EmployeeLogin;

namespace BwServer.Controllers.v1.Employee
{
    public class EmployeeLoginController : ApiController
    {
        private readonly EmployeeInfoDal _employeeInfoDal = new EmployeeInfoDal();
        [AllowAnonymous]
        public IHttpActionResult Login(EmployeeLoginModelGet adminLoginModelGet)
        {
            DataRow dataRow = _employeeInfoDal.Login(adminLoginModelGet.AccountId, adminLoginModelGet.LoginPassword);
            EmployeeLoginModelResult adminLoginModelResult = null;
            if (dataRow != null)
            {
                adminLoginModelResult = new EmployeeLoginModelResult();
                adminLoginModelResult.AccountId = dataRow["AccountId"].ToString();
                adminLoginModelResult.Id = Convert.ToInt32(dataRow["Id"]);
                adminLoginModelResult.Nickname = dataRow["Nickname"].ToString();
                adminLoginModelResult.Phone = dataRow["Phone"].ToString();
                adminLoginModelResult.PhoneAreaId = dataRow["PhoneAreaId"].ToString();
                adminLoginModelResult.State = dataRow["State"].ToString();
                adminLoginModelResult.Type = dataRow["Type"].ToString();
                adminLoginModelResult.Token = ServerHelper.GetToken;
                WebCacheHelper.SetCache(adminLoginModelResult.Id + "_" + 0, adminLoginModelResult.Token);
            }
            return Json(new ResultDataModel<EmployeeLoginModelResult> { Code = dataRow == null ? -1 : 0, Data = adminLoginModelResult });
        }
    }
}