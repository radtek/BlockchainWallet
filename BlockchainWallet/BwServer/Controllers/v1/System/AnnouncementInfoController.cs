using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.System.Announcement;
using BwServer.Models;
using BwServer.Models.v1.System;
using BwServer.Models.v1.User.UserInfo;
using BwServer.Models.v1.User.VipInfo;

namespace BwServer.Controllers.v1.System
{
    public class AnnouncementInfoController : ApiController
    {
        private readonly AnnouncementInfoDal _announcementInfoDal = new AnnouncementInfoDal();
        // GET api/<controller>
        public IHttpActionResult QueryAnnouncementInfo(AnnouncementInfoModelGet announcementInfoModelGet)
        {
            DataTable dataTable = _announcementInfoDal.QueryAnnouncementInfo();
            IList<AnnouncementInfoModelResult> list = ModelConvertHelper<AnnouncementInfoModelResult>.ConvertToModel(dataTable);
            return Json(new ResultDataModel<IList<AnnouncementInfoModelResult>> { Data = list });
        }

        public IHttpActionResult InsertAnnouncementInfo(AnnouncementInfoModelGet announcementInfoModelGet)
        {
            int rows = _announcementInfoDal.InsertAnnouncementInfo(announcementInfoModelGet.Titel, announcementInfoModelGet.PublishEmployeeId, announcementInfoModelGet.Content, announcementInfoModelGet.DisplayTime);
            return Json(new ResultDataModel<VipUrFans> { Code = rows == 1 ? 0 : -1 });
        }

        public IHttpActionResult UpdateAnnouncementInfo(AnnouncementInfoModelGet announcementInfoModelGet)
        {
            int rows = _announcementInfoDal.UpdateAnnouncementInfo(announcementInfoModelGet.Id, announcementInfoModelGet.Titel, announcementInfoModelGet.UpdateEmployeeId, announcementInfoModelGet.Content, announcementInfoModelGet.DisplayTime);
            return Json(new ResultDataModel<VipUrFans> { Code = rows == 1 ? 0 : -1 });
        }

        public IHttpActionResult RemoveAnnouncementInfo(AnnouncementInfoModelGet announcementInfoModelGet)
        {
            int rows = _announcementInfoDal.DeleteAnnouncementInfo(announcementInfoModelGet.Id);
            return Json(new ResultDataModel<VipUrFans> { Code = rows == 1 ? 0 : -1 });
        }

        public IHttpActionResult QueryAnnouncement(AnnouncementInfoModelGet announcementInfoModelGet)
        {
            DataTable dataTable = _announcementInfoDal.QueryAnnouncement();
            IList<AnnouncementInfoModelResult> list = ModelConvertHelper<AnnouncementInfoModelResult>.ConvertToModel(dataTable);
            return Json(new ResultDataModel<IList<AnnouncementInfoModelResult>> { Data = list });
        }


    }
}