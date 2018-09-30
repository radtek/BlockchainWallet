using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.Employee;
using BwServer.Models;
using BwServer.Models.v1.Employee.EmployeeInfo;

namespace BwServer.Controllers.v1.Employee
{

    public class EmployeeInfoController : ApiController
    {
        private readonly EmployeeInfoDal _employeeInfoDal = new EmployeeInfoDal();
        // GET api/<controller>/5
        public IHttpActionResult QueryEmployeeInfo()
        {
            DataTable dtEmployeeInfo = _employeeInfoDal.QueryEmployeeInfo();
            IList<EmployeeInfoModelResult> adminInfoModelResults = ModelConvertHelper<EmployeeInfoModelResult>.ConvertToModel(dtEmployeeInfo);
            return Json(new ResultDataModel<IList<EmployeeInfoModelResult>> { Data = adminInfoModelResults });
        }
    }

}