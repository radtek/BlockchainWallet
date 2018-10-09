using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.SystemMgmt;

namespace BwServerSal.ServiceApi.System
{
    public class SystemMaintenanceApi
    {
        public List<SystemMaintenanceModelGet> QuerySystemMaintenanceRecord(SystemMaintenanceModelSend systemMaintenanceModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<SystemMaintenanceModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<SystemMaintenanceModelGet>>>.PostMsg(
                ApiAddress.QuerySystemMaintenanceRecord, systemMaintenanceModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public bool InsertSystemMaintenanceRecord(SystemMaintenanceModelSend systemMaintenanceModelSend)
        {
            HeadModelGet<List<SystemMaintenanceModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<SystemMaintenanceModelGet>>>.PostMsg(
                ApiAddress.InsertSystemMaintenanceRecord, systemMaintenanceModelSend);
            return headModelGet.Code == 0;
        }
        public bool UpdateSystemMaintenanceRecord(SystemMaintenanceModelSend systemMaintenanceModelSend)
        {
            HeadModelGet<List<SystemMaintenanceModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<SystemMaintenanceModelGet>>>.PostMsg(
                ApiAddress.UpdateSystemMaintenanceRecord, systemMaintenanceModelSend);
            return headModelGet.Code == 0;
        }
    }
}
