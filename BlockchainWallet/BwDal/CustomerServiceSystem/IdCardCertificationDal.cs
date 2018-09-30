using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.CustomerServiceSystem
{
    public class IdCardCertificationDal
    {
        /// <summary>
        /// 实名认证记录查询
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIdCardCertification()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT i.Id,i.UserId,ui.Nickname UserName,i.`Name`,i.IdCard,date_format(i.SubmitTime, '%Y-%m-%d %H:%i:%s') SubmitTime," +
                                                            "i.EmployeeId,e.Nickname EmployeeName,date_format(i.DisposeTime, '%Y-%m-%d %H:%i:%s') DisposeTime,i.State " +
                                                            "FROM idcard_certification i " +
                                                            "LEFT JOIN user_info AS ui ON i.UserId = ui.ID " +
                                                            "LEFT JOIN employee_info AS e ON i.EmployeeId=e.ID " +
                                                            "ORDER BY i.SubmitTime DESC");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 实名审核
        /// </summary>
        /// <returns></returns>
        public bool CheckIdCard(int id, int employeeId, string state, string remark, int userId, string name, string idCard, string frontImage, string reverseImage)
        {
            using (var mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    string strSql = string.Format("UPDATE idcard_certification SET FrontImage='{0}',ReverseImage='{1}', EmployeeId={2},State='{3}',DisposeTime=now(),Remark='{4}' WHERE Id={5}",
                        frontImage, reverseImage, employeeId, state, remark, id);
                    int rows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSql, null);
                    if (rows != 1)
                    {
                        mySqlTransaction.Rollback();
                        return false;
                    }
                    if (state == "1")
                    {
                        string strSql1 = string.Format("UPDATE user_info SET Name='{0}', IdCard='{1}' WHERE Id={2}", name, idCard, userId);
                        rows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSql1, null);
                        if (rows != 1)
                        {
                            mySqlTransaction.Rollback();
                            return false;
                        }
                    }
                    mySqlTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    mySqlTransaction.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 查询认证信息详情
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIdCardCertificationInfo(int id, int userId)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT i.Id,i.UserId,ui.Nickname UserName,i.`Name`,i.IdCard,date_format(i.SubmitTime, '%Y-%m-%d %H:%i:%s') SubmitTime," +
                                                            "i.EmployeeId,e.Nickname EmployeeName,date_format(i.DisposeTime, '%Y-%m-%d %H:%i:%s') DisposeTime,i.State,i.Remark,i.FrontImage,i.ReverseImage " +
                                                            "FROM idcard_certification i " +
                                                            "LEFT JOIN user_info AS ui ON i.UserId = ui.ID " +
                                                            "LEFT JOIN employee_info AS e ON i.EmployeeId=e.ID " +
                                                            "WHERE 1=1 " +
                                                            (id == 0 ? " " : "AND i.Id=" + id) +
                                                            (userId == 0 ? " " : "AND i.UserId=" + userId) +
                                                            " ORDER BY i.SubmitTime DESC");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        public int InsertIdCardCertificationInfo(int userId, string name, string idCard, string frontImage, string reverseImage)
        {
            string strSql = string.Format("INSERT INTO idcard_certification(UserId,`Name`,IdCard,FrontImage,ReverseImage,SubmitTime,State) VALUES({0},'{1}','{2}','{3}','{4}',now(),'0')", userId, name, idCard, frontImage, reverseImage);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }
        public object CheckIdCardExisit(string idCard)
        {
            string strSql = string.Format("SELECT UserId FROM  idcard_certification WHERE State !='2' AND IdCard='{0}' ", idCard);
            return MySqlHelper.Single.ExecuteScalar(strSql);
        }

    }
}
