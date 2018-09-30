using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.System.Announcement
{
    public class AnnouncementInfoDal
    {
        /// <summary>
        /// 查询公告
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAnnouncementInfo()
        {
            return MySqlHelper.Single.ExecuteDataTable("SELECT a.Id, a.Titel, a.PublishEmployeeId,a.Content,ei.Nickname PublishEmployeeName,date_format(a.DisplayTime, '%Y-%m-%d %H:%i:%s') DisplayTime FROM announcement a LEFT JOIN employee_info AS ei ON a.PublishEmployeeId=ei.Id WHERE 1=1 ORDER BY a.PublishTime DESC");
        }
        /// <summary>
        /// 查询公告
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAnnouncement()
        {
            return MySqlHelper.Single.ExecuteDataTable("SELECT a.Titel,a.Content,ei.Nickname PublishEmployeeName,date_format(a.DisplayTime, '%Y-%m-%d %H:%i:%s') DisplayTime FROM announcement a LEFT JOIN employee_info AS ei ON a.PublishEmployeeId=ei.Id WHERE 1=1 And a.PublishTime<now() ORDER BY a.PublishTime DESC");
        }

        /// <summary>
        /// 新增公告
        /// </summary>
        /// <returns></returns>
        public int InsertAnnouncementInfo(string titel, int publishEmployeeId, string content, string displayTime)
        {
            string sqlStr = string.Format(
                 "INSERT INTO announcement (Titel,PublishEmployeeId,Content,PublishTime,DisplayTime) VALUES('{0}',{1},'{2}',now(),'{3}')", titel, publishEmployeeId, content, displayTime);
            return MySqlHelper.Single.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// 修改公告
        /// </summary>
        /// <returns></returns>
        public int UpdateAnnouncementInfo(int id, string titel, int updateEmployeeId, string content, string displayTime)
        {

            string sqlStr = string.Format(
                "UPDATE announcement SET Titel='{0}',Content='{1}',DisplayTime='{2}',UpdateEmployeeId={3},UpdateTime=now() WHERE Id={4}", titel, content, displayTime, updateEmployeeId, id);
            return MySqlHelper.Single.ExecuteNonQuery(sqlStr);
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <returns></returns>
        public int DeleteAnnouncementInfo(int id)
        {
            return MySqlHelper.Single.ExecuteNonQuery("DELETE FROM announcement WHERE Id=" + id);
        }
    }
}
