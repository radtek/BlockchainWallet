using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.Commodity;
using BwServer.Controllers.v1.User;
using BwServer.Models;
using BwServer.Models.v1.Commodity.CommodityInfo;

namespace BwServer.Controllers.v1.Commodity
{
    public class CommodityInfoController : ApiController
    {
        private readonly CommodityDal _commodityDal = new CommodityDal();
        public IHttpActionResult QueryCommodityInfo(CommodityInfoModelGet commodityInfoModelGet)
        {
            DataTable dtDataTable = _commodityDal.QueryCommodityInfo(commodityInfoModelGet.State, commodityInfoModelGet.Type);
            IList<CommodityInfoModelResult> list =
                ModelConvertHelper<CommodityInfoModelResult>.ConvertToModel(dtDataTable);
            return Json(new ResultDataModel<IList<CommodityInfoModelResult>> { Data = list });
        }

        /// <summary>
        /// 购买资格信息
        /// </summary>
        /// <param name="buyQualificationInfoModelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryBuyQualificationInfo(BuyQualificationInfoModelGet buyQualificationInfoModelGet)
        {
            FansController fansController = new FansController();
            BuyQualificationInfoModelResult buyQualificationInfoModelResult = new BuyQualificationInfoModelResult();
            //buyQualificationInfoModelResult.FansGenerationCountModelResults =
            //    fansController.QueryAllFansVipInfo(buyQualificationInfoModelGet.UserId);
            buyQualificationInfoModelResult.FansVipCountModelResults =
                fansController.QueryFirstFansVipCount(buyQualificationInfoModelGet.UserId);
            return Json(new ResultDataModel<BuyQualificationInfoModelResult> { Data = buyQualificationInfoModelResult });
        }


        public IHttpActionResult InsertCommodity(CommodityInfoModelGet commodityInfoModelGet)
        {

            return null;
        }
        public IHttpActionResult UpdateCommodity()
        {
            return null;
        }
        public IHttpActionResult DeleteCommodity()
        {
            return null;
        }
    }
}