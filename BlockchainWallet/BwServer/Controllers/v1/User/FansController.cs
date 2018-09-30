using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.User.Fans;

namespace BwServer.Controllers.v1.User
{
    public class FansController : ApiController
    {
        private readonly FansDal _fansDal = new FansDal();
        /// <summary>
        /// 查询粉丝信息
        /// </summary>
        /// <param name="fansModelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryFans(FansModelGet fansModelGet)
        {
            DataTable dtFans = _fansDal.QueryFans(fansModelGet.Id);
            IList<FansModelResult> fansModelGets = ModelConvertHelper<FansModelResult>.ConvertToModel(dtFans);
            return Json(new ResultDataModel<IList<FansModelResult>> { Data = fansModelGets });
        }

        ///// <summary>
        ///// 查询所有粉丝信息
        ///// </summary>
        ///// <param name="modelGet"></param>
        ///// <returns></returns>
        //public IHttpActionResult QueryAllFansInfo(AllFansVipInfoModelGet modelGet)
        //{
        //    DataTable dt = _fansDal.QueryAllFansVipInfo(modelGet.FansId);
        //    IList<AllFansVipInfoModelResult> allFansVipInfoModelResults = ModelConvertHelper<AllFansVipInfoModelResult>.ConvertToModel(dt);
        //    return Json(new ResultDataModel<IList<AllFansVipInfoModelResult>> { Data = allFansVipInfoModelResults });
        //}
        #region 查询各代粉丝人数
        /// <summary>
        /// 查询粉丝各代人数信息
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryAllFansVipInfo(AllFansVipInfoModelGet modelGet)
        {
            IList<FansGenerationCountModelResult> fansVipCountModelResults = QueryAllFansVipInfo(modelGet.FansId);
            return Json(new ResultDataModel<IList<FansGenerationCountModelResult>> { Data = fansVipCountModelResults });
        }

        internal IList<FansGenerationCountModelResult> QueryAllFansVipInfo(int fansId)
        {
            DataTable dt = _fansDal.QueryAllFansVipInfo(fansId);
            IList<AllFansVipInfoModelResult> allFansVipInfoModelResults = ModelConvertHelper<AllFansVipInfoModelResult>.ConvertToModel(dt);

            IList<FansGenerationCountModelResult> fansVipCountModelResults = new List<FansGenerationCountModelResult>();
            GetFansVipCount(new List<uint> { 1 }, 1, allFansVipInfoModelResults, ref fansVipCountModelResults);
            return fansVipCountModelResults;
        }

        private void GetFansVipCount(List<uint> userIds, int generationId, IList<AllFansVipInfoModelResult> allFansVipInfoModelResults, ref IList<FansGenerationCountModelResult> fansGenerationCountModelResults)
        {
            FansGenerationCountModelResult fansGenerationCountModelResult = new FansGenerationCountModelResult();
            fansGenerationCountModelResult.GenerationCount = allFansVipInfoModelResults.Count(n => userIds.Contains(n.Id));
            fansGenerationCountModelResult.GenerationId = generationId;
            fansGenerationCountModelResults.Add(fansGenerationCountModelResult);
            if (fansGenerationCountModelResult.GenerationCount > 0)
            {
                List<uint> tUserIds = new List<uint>();

                foreach (var item in allFansVipInfoModelResults.Where(n => userIds.Contains(Convert.ToUInt32(n.ParentId))))
                {
                    tUserIds.Add(item.Id);
                }
                GetFansVipCount(tUserIds, ++generationId, allFansVipInfoModelResults, ref fansGenerationCountModelResults);
            }
        }
        #endregion

        ///// <summary>
        ///// 查询所有粉丝中各个VIP的数量
        ///// </summary>
        ///// <param name="modelGet"></param>
        ///// <returns></returns>
        //public IHttpActionResult QueryAllFansVipCount(AllFansVipInfoModelGet modelGet)
        //{
        //    DataTable dt = _fansDal.QueryAllFansVipInfo(modelGet.FansId);
        //    IList<AllFansVipInfoModelResult> allFansVipInfoModelResults = ModelConvertHelper<AllFansVipInfoModelResult>.ConvertToModel(dt);
        //    return Json(new ResultDataModel<IList<AllFansVipInfoModelResult>> { Data = allFansVipInfoModelResults });
        //}

        #region 查询直系粉丝中各个VIP的数量
        /// <summary>
        /// 查询直系粉丝中各个VIP的数量
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryFirstFansVipCount(FansVipCountModelGet modelGet)
        {
            IList<FansVipCountModelResult> allFansVipInfoModelResults = QueryFirstFansVipCount(modelGet.UserId);
            return Json(new ResultDataModel<IList<FansVipCountModelResult>> { Data = allFansVipInfoModelResults });
        }

        internal IList<FansVipCountModelResult> QueryFirstFansVipCount(int userId)
        {
            DataTable dt = _fansDal.QueryFirstFansVipCount(userId);
            return ModelConvertHelper<FansVipCountModelResult>.ConvertToModel(dt);

        }
        #endregion
    }
}