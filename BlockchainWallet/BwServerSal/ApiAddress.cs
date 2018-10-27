using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwServerSal
{
    public static class ApiAddress
    {
        public static string LocalHost = "http://192.168.1.150:8077";
        //public static string LocalHost = "http://192.168.1.150:8088";

        public static string ApiUrlRoot = LocalHost + "/api";
        //====================用户相关=================================
        public static string EmployeeLogin = ApiUrlRoot + "/v1/Employee/EmployeeLogin/Login";
        public static string QueryUser = ApiUrlRoot + "/v1/User/User_/QueryUser";
        //公司账户信息
        public static string QueryComapnyAccountInfo = ApiUrlRoot + "/v1/User/CompanyAccountInfo/QueryCompanyAccountInfo";

        //====================员工账户相关=================================
        public static string QueryEmployeeInfo = ApiUrlRoot + "/v1/Employee/EmployeeInfo/QueryEmployeeInfo";

        //====================会员相关=================================
        public static string QueryVipInfo = ApiUrlRoot + "/v1/User/VipInfo/QueryVipInfo";
        public static string InsertVipUrFans = ApiUrlRoot + "/v1/User/VipInfo/InsertVipUrFans";
        public static string UpdateVipUrFans = ApiUrlRoot + "/v1/User/VipInfo/UpdateVipUrFans";
        public static string DeleteVipUrFans = ApiUrlRoot + "/v1/User/VipInfo/RemoveVipUrFans";
        public static string InsertVipUrCloudMiner = ApiUrlRoot + "/v1/User/VipInfo/InsertVipUrCloudMiner";
        public static string UpdateVipUrCloudMiner = ApiUrlRoot + "/v1/User/VipInfo/UpdateVipUrCloudMiner";
        public static string DeleteVipUrCloudMiner = ApiUrlRoot + "/v1/User/VipInfo/RemoveVipUrCloudMiner";


        //====================钱包相关=================================
        public static string QueryCurrency = ApiUrlRoot + "/v1/Wallet/CurrencyInfo_/QueryCurrency";
        public static string UpdateCurrencyPrice = ApiUrlRoot + "/v1/Wallet/CurrencyInfo_/UpdateCurrencyPrice";

        public static string QueryCurrencyPriceRecord = ApiUrlRoot + "/v1/Wallet/CurrencyInfo_/QueryCurrencyPriceRecord";
        public static string UpdateCurrencyPriceRecord = ApiUrlRoot + "/v1/Wallet/CurrencyInfo_/UpdateCurrencyPriceRecord";

        public static string QueryUserWallet = ApiUrlRoot + "/v1/Wallet/WalletInfo_/QueryUserWallet";

        //====================分销相关=================================
        public static string QueryCloudMinerProductionRecord = ApiUrlRoot + "/v1/Agent/CloudMinerProduction_/QueryCloudMinerProductionRecord";
        public static string QueryUserCloudMinerProductionRecord = ApiUrlRoot + "/v1/Agent/CloudMinerProduction_/QueryUserCloudMinerProductionRecord";
        public static string QueryCloudMinerDistributionRecord = ApiUrlRoot + "/v1/Agent/CloudMinerDistribution_/QueryCloudMinerDistributionRecord";
        public static string QueryUserCloudMinerDistributionRecord = ApiUrlRoot + "/v1/Agent/CloudMinerDistribution_/QueryUserCloudMinerDistributionRecord";

        //====================商品相关=================================
        public static string QueryCommodityInfo = ApiUrlRoot + "/v1/Commodity/CommodityInfo/QueryCommodityInfo";
        public static string QueryCloudMiner = ApiUrlRoot + "/v1/Commodity/CloudMiner_/QueryCloudMiner";

        public static string RunCloudMiner = ApiUrlRoot + "/v1/Commodity/CloudMiner_/RunCloudMiner";
        public static string CheckCloudMiner = ApiUrlRoot + "/v1/Commodity/CloudMiner_/CheckCloudMiner";

        public static string GaveCommodityStoreOrder = ApiUrlRoot + "/v1/Commodity/StoreOrder_/GaveCommodityStoreOrder";
        public static string QueryStoreOrder = ApiUrlRoot + "/v1/Commodity/StoreOrder_/QueryStoreOrder";
        public static string QueryGaveCommodityStoreOrder = ApiUrlRoot + "/v1/Commodity/StoreOrder_/QueryGaveCommodityStoreOrder";


        public static string QueryUserCloudMiner = ApiUrlRoot + "/v1/Commodity/UserCloudMiner_/QueryUserCloudMiner";

        //====================维护相关=================================
        public static string QuerySystemMaintenanceRecord = ApiUrlRoot + "/v1/System/SystemMaintenance_/QuerySystemMaintenanceRecord";
        public static string InsertSystemMaintenanceRecord = ApiUrlRoot + "/v1/System/SystemMaintenance_/InsertSystemMaintenanceRecord";
        public static string UpdateSystemMaintenanceRecord = ApiUrlRoot + "/v1/System/SystemMaintenance_/UpdateSystemMaintenanceRecord";


        //====================公告相关=================================
        public static string QueryAnnouncementInfo = ApiUrlRoot + "/v1/System/AnnouncementInfo/QueryAnnouncementInfo";
        public static string InsertAnnouncementInfo = ApiUrlRoot + "/v1/System/AnnouncementInfo/InsertAnnouncementInfo";
        public static string UpdateAnnouncementInfo = ApiUrlRoot + "/v1/System/AnnouncementInfo/UpdateAnnouncementInfo";
        public static string DeleteAnnouncementInfo = ApiUrlRoot + "/v1/System/AnnouncementInfo/RemoveAnnouncementInfo";

        //====================客服相关=================================
        public static string CheckIdCard = ApiUrlRoot + "/v1/CustomerServiceSystem/IdCardCertification/CheckIdCard";
        public static string QueryIdCardCertification = ApiUrlRoot + "/v1/CustomerServiceSystem/IdCardCertification/QueryIdCardCertification";
        public static string QueryIdCardCertificationInfo = ApiUrlRoot + "/v1/CustomerServiceSystem/IdCardCertification/QueryIdCardCertificationInfo";


    }
}
