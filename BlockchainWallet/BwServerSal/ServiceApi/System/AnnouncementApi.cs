using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.SystemMgmt;

namespace BwServerSal.ServiceApi.System
{
    public class AnnouncementApi
    {
        public List<AnnouncementInfoModelGet> QueryAnnouncementInfo(AnnouncementInfoModelSend announcementInfoModelSend)
        {
            HeadModelGet<List<AnnouncementInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<AnnouncementInfoModelGet>>>.PostMsg(
                ApiAddress.QueryAnnouncementInfo, announcementInfoModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

        public bool InsertAnnouncementInfo(AnnouncementInfoModelSend announcementInfoModelSend)
        {
            HeadModelGet<List<AnnouncementInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<AnnouncementInfoModelGet>>>.PostMsg(
                ApiAddress.InsertAnnouncementInfo, announcementInfoModelSend);
            return headModelGet.Code == 0;
        }

        public bool UpdateAnnouncementInfo(AnnouncementInfoModelSend announcementInfoModelSend)
        {
            HeadModelGet<List<AnnouncementInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<AnnouncementInfoModelGet>>>.PostMsg(
                ApiAddress.UpdateAnnouncementInfo, announcementInfoModelSend);
            return headModelGet.Code == 0;
        }

        public bool DeleteAnnouncementInfo(AnnouncementInfoModelSend announcementInfoModelSend)
        {
            HeadModelGet<List<AnnouncementInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<AnnouncementInfoModelGet>>>.PostMsg(
                ApiAddress.DeleteAnnouncementInfo, announcementInfoModelSend);
            return headModelGet.Code == 0;
        }
    }
}
