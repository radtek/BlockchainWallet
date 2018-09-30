using System.Collections.Generic;
using BwBackModel;
using BwBackModel.UserMgmt.EmployeeInfo;

namespace BwServerSal.ServiceApi.Employee
{
    public class EmployeeInfoApi
    {

        public List<EmployeeInfoQueryModelGet> QuerEmployeeInfoModel(EmployeeInfoQueryModelSend employeeInfoModelSend)
        {
            HeadModelGet<List<EmployeeInfoQueryModelGet>> employeeInfoModelGets = BwHttpApiAccess<HeadModelGet<List<EmployeeInfoQueryModelGet>>>.PostMsg(
                ApiAddress.QueryEmployeeInfo, employeeInfoModelSend);
            return employeeInfoModelGets.Code == 0 ? employeeInfoModelGets.Data : null;
        }
    }
}
