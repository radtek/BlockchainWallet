using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.System;
using BwServer.Models;
using BwServer.Models.v1.Agent.CloudMinerDistribution;
using BwServer.Models.v1.System;

namespace BwServer.Controllers.v1.System
{
    public class SystemMaintenance_Controller : ApiController
    {
        private readonly SystemMaintenanceDal_ _systemMaintenanceDal = new SystemMaintenanceDal_();

        public IHttpActionResult QuerySystemMaintenanceRecord(SystemMaintenanceModelGet_ modelGet)
        {
            DataSet dataSet = _systemMaintenanceDal.QuerySystemMaintenance(modelGet.DataPagingModel);
            IList<SystemMaintenanceModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<SystemMaintenanceModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<SystemMaintenanceModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }

        public IHttpActionResult InsertSystemMaintenanceRecord(SystemMaintenanceModelGet_ modelGet)
        {
            try
            {
                Convert.ToDateTime(modelGet.MaintenanceTimeBegin);
                Convert.ToDateTime(modelGet.MaintenanceTimeEnd);
            }
            catch (Exception e)
            {
                return Json(new ResultDataModel<IList<SystemMaintenanceModelResult_>> { Code = -1, Messages = "请求参数有误" });
            }
            int result = _systemMaintenanceDal.InsertSystemMaintenance(modelGet.MaintenanceTimeBegin, modelGet.MaintenanceTimeEnd, modelGet.EmployeeId);
            if (result > 0)
            {
                SystemMaintenance.Add(Convert.ToDateTime(modelGet.MaintenanceTimeBegin), Convert.ToDateTime(modelGet.MaintenanceTimeEnd));
            }
            return Json(new ResultDataModel<IList<SystemMaintenanceModelResult_>> { Code = result > 0 ? 0 : -1, Messages = result > 0 ? "" : "修改维护记录失败" });
        }

        public IHttpActionResult UpdateSystemMaintenanceRecord(SystemMaintenanceModelGet_ modelGet)
        {
            int result = _systemMaintenanceDal.UpdateSystemMaintenance(modelGet.EmployeeId, modelGet.Id);
            if (result > 0)
            {
                SystemMaintenance.Refresh();
            }
            return Json(new ResultDataModel<IList<SystemMaintenanceModelResult_>> { Code = result > 0 ? 0 : -1, Messages = result > 0 ? "" : "修改维护记录失败" });
        }
    }
}