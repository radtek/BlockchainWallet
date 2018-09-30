using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.UserMgmt.EmployeeInfo;
using BwBackModel.UserMgmt.User;

namespace BwServerSal.ServiceApi.User
{
    public class UserInfoApi
    {
        public List<UserInfoQueryModelGet> QueryUserInfo(UserInfoQueryModelSend userInfoQueryModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<UserInfoQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<UserInfoQueryModelGet>>>.PostMsg(
                ApiAddress.QueryUser, userInfoQueryModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult;
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

        public List<CompanyAccountInfoQueryModelGet> QueryCompanyAccountInfo(CompanyAccountInfoQueryModelSend companyAccountInfoQueryModelSend)
        {
            HeadModelGet<List<CompanyAccountInfoQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CompanyAccountInfoQueryModelGet>>>.PostMsg(
                ApiAddress.QueryComapnyAccountInfo, companyAccountInfoQueryModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }


        #region 会员信息相关
        public List<VipSettingQueryModelGet> QueryVipSetting(VipSettingQueryModelSend vipSettingQueryModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.QueryVipInfo, vipSettingQueryModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public bool InsertVipUrFans(VipUrFansModelSend vipUrFansModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.InsertVipUrFans, vipUrFansModelSend);
            return headModelGet.Code == 0;
        }

        public bool UpdateVipUrFans(VipUrFansModelSend vipUrFansModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.UpdateVipUrFans, vipUrFansModelSend);
            return headModelGet.Code == 0;
        }

        public bool DeleteVipUrFans(VipUrFansModelSend vipUrFansModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.DeleteVipUrFans, vipUrFansModelSend);
            return headModelGet.Code == 0;
        }

        public bool InsertVipUrCloudminer(VipUrCloudminerModelSend vipUrCloudminerModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.InsertVipUrCloudminer, vipUrCloudminerModelSend);
            return headModelGet.Code == 0;
        }

        public bool UpdateVipUrCloudminer(VipUrCloudminerModelSend vipUrCloudminerModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.UpdateVipUrCloudminer, vipUrCloudminerModelSend);
            return headModelGet.Code == 0;
        }

        public bool DeleteVipUrCloudminer(VipUrCloudminerModelSend vipUrCloudminerModelSend)
        {
            HeadModelGet<List<VipSettingQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<VipSettingQueryModelGet>>>.PostMsg(
                ApiAddress.DeleteVipUrCloudminer, vipUrCloudminerModelSend);
            return headModelGet.Code == 0;
        }
        #endregion

    }
}
