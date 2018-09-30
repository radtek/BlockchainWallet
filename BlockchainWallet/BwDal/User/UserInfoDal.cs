using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BwCommon.EncryptionDecryption;
using BwCommon.Log;
using BwCommon.Verification;
using BwDal.Helper;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.User
{
    public class UserInfoDal
    {
        public DataSet QueryUser(string phone, string name, DataPagingModelGet dataPagingModelGet)
        {
            StringBuilder sbString = new StringBuilder();
            if (!string.IsNullOrEmpty(phone))
            {
                sbString.Append(string.Format(" AND phone LIKE '%{0}%' ", phone));
            }
            if (!string.IsNullOrEmpty(name))
            {
                sbString.Append(string.Format(" AND name LIKE '%{0}%' ", name));
            }

            string strSql =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS ID,AccountId,Nickname,Phone,PhoneAreaId,Name,IdCard,Email,Sex,date_format(Birthday, '%Y-%m-%d %H:%i:%s') Birthday,Type,State 
            FROM user_info 
            WHERE type!=3 {0} " + dataPagingModelGet.LimitString(), sbString.ToString());
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }

        private static readonly object _objLock = new object();

        public bool CheckPhone(string phone, string phoneAreaId)
        {
            try
            {
                string strCheckPhone =
                        string.Format(
                            "SELECT  Count(0) FROM user_info WHERE PhoneAreaId='{0}' AND Phone='{1}'", phoneAreaId, phone);
                int count = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(strCheckPhone));
                if (count != 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int RegisterUserInfo(string phone, string phoneAreaId, string password, int promotionUserId, int promotionId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    lock (_objLock)
                    {
                        string strCheckPhone =
                            string.Format(
                                "SELECT  Count(0) FROM user_info WHERE PhoneAreaId='{0}' AND Phone='{1}' ", phoneAreaId, phone);
                        int count = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strCheckPhone));
                        if (count > 0)
                        {
                            mySqlTransaction.Rollback();
                            return -2;
                        }

                        string strSql =
                            string.Format(
                                "INSERT INTO user_info (Nickname,Phone,PhoneAreaId,LoginPassword,PromotionUserId,Type,State,VipId,RegisterTime) VALUES('{0}','{1}','{2}','{3}',{4},'0','0',0,now()); SELECT LAST_INSERT_ID() as Id;",
                                "新用户" + phone.Substring(7), phone, phoneAreaId, password, promotionUserId);
                        int userId = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strSql));
                        if (userId <= 0)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }
                        object newsId = MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text,
                            "SELECT Id FROM promotion ORDER BY ID DESC LIMIT 1 ");
                        int pId = 20000;
                        if (newsId != null)
                        {
                            pId = Convert.ToInt32(newsId);
                            if (pId < 20000)
                            {
                                pId = 20000;
                            }
                        }
                        //string myPromotionCode = Md5Helper.Md5Encrypt16(userId + "_1", Encoding.UTF8);
                        pId = GetPromotionCode(++pId);
                        string myPromotionCode = "QQH" + pId;
                        string strSqlPromotion =
                            string.Format("Insert into Promotion(Id,UId,PromotionCode,Way)values({0},{1},'{2}','{3}')", pId, userId,
                                myPromotionCode, "线下推广");
                        int row = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlPromotion);
                        if (row != 1)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }

                        string strSqlFans =
                            string.Format("Insert into fans(UId,PromotionId,PromotionTime,FansId)values({0},{1},now(),{2})", promotionUserId, promotionId, userId
                            );
                        int rowFans = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlFans);
                        if (rowFans != 1)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }

                        #region 初始化个人钱包
                        string strWallet = string.Format("Insert into Wallet_Info(UId,CurrencyID,Privatekey,AllAmount,FrozenAmount,CanUseAmount)values({0},{1},'{2}',{3},{4},{5})", userId, 0, "", 0, 0, 0
                        );
                        int rowCount = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strWallet);
                        if (rowCount != 1)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }

                        strWallet = string.Format("Insert into Wallet_Info(UId,CurrencyID,Privatekey,AllAmount,FrozenAmount,CanUseAmount)values({0},{1},'{2}',{3},{4},{5})", userId, 1, "", 0, 0, 0
                        );
                        rowCount = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strWallet);
                        if (rowCount != 1)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }

                        strWallet = string.Format("Insert into Wallet_Info(UId,CurrencyID,Privatekey,AllAmount,FrozenAmount,CanUseAmount)values({0},{1},'{2}',{3},{4},{5})", userId, 2, "", 0, 0, 0
                        );
                        rowCount = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strWallet);
                        if (rowCount != 1)
                        {
                            mySqlTransaction.Rollback();
                            return -1;
                        }
                    }
                        #endregion

                    mySqlTransaction.Commit();
                    return 1;
                }
                catch (Exception e)
                {
                    LogHelper.error(e.ToString());
                    mySqlTransaction.Rollback();
                    return -1;
                }
            }
        }

        private int GetPromotionCode(int id)
        {
            while (true)
            {
                if (!RegexHelper.CheckBeautifulNumber(id.ToString()))
                {
                    return id;
                }
                id++;
            }
        }

        public DataTable LoginUser(string account, string phoneAreaId, string type, string password)
        {
            StringBuilder stringBuilder = new StringBuilder(" SELECT u.ID,u.AccountId,u.Nickname,u.Phone,IFNULL(left(u.PayPassword,2),'0') IsSetPayPassword,u.PhoneAreaId,u.`Name`,u.IdCard,u.Email,u.Sex,date_format(u.Birthday, '%Y-%m-%d %H:%i:%s') Birthday,u.Type,u.State,p.PromotionCode,u.VipId,v.Rank,v.`Name` VipName FROM user_info u LEFT JOIN promotion as p ON u.Id=p.UId LEFT JOIN vip_rank_info as v ON u.VipId=v.Id WHERE u.type!=3 and (u.State='0' or u.State='2') ");
            if (type == "1")
            {
                SqlHelper.AppendAndWhereEqual("u.Phone", account, ref stringBuilder);
                SqlHelper.AppendAndWhereEqual("u.PhoneAreaId", phoneAreaId, ref stringBuilder);
            }
            else if (type == "2")
            {
                SqlHelper.AppendAndWhereEqual("u.AccountId", account, ref stringBuilder);
            }
            else
            {
                SqlHelper.AppendAndWhereEqual("u.IdCard", account, ref stringBuilder);
            }
            SqlHelper.AppendAndWhereEqual("u.LoginPassword", password, ref stringBuilder);
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        public bool ExisitPhone(string phoneAreaId, string phone)
        {
            string strSql = string.Format("Select 1 from user_info WHERE Phone='{0}' AND PhoneAreaId='{1}'", phone, phoneAreaId);
            DataTable dt = MySqlHelper.Single.ExecuteDataTable(strSql);
            return dt.Rows.Count > 0;
        }

        public int UpdatePhone(int id, string phoneAreaId, string phone)
        {
            string strSql = string.Format("UPDATE user_info SET PhoneAreaId ='{0}',Phone='{1}' WHERE Id={2}", phoneAreaId, phone, id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }

        public int UpdateLoginPassword(int id, string oldPassword, string password)
        {
            string strSql = string.Format("UPDATE user_info SET LoginPassword ='{0}' WHERE Id={1} AND LoginPassword='{2}'", password, id, oldPassword);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }
        public int RetrieveLoginPassword(string phoneAreaId, string phone, string password)
        {
            string strSql = string.Format("UPDATE user_info SET LoginPassword ='{0}' WHERE PhoneAreaId ='{1}' AND Phone='{2}' ", password, phoneAreaId, phone);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }

        public int UpdatePayPassword(int id, string password)
        {
            string strSql = string.Format("UPDATE user_info SET PayPassword ='{0}' WHERE Id={1}", password, id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }

        public int UpdateNickname(int id, string nickname)
        {
            string strSql = string.Format("UPDATE user_info SET Nickname ='{0}' WHERE Id={1}", nickname, id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }
        public int UpdateSex(int id, string sex)
        {
            string strSql = string.Format("UPDATE user_info SET Sex ='{0}' WHERE Id={1}", sex, id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }

        public DataTable QueryUserInfoByPhone(string phoneAreaId, string phone)
        {
            string strSql = string.Format("Select Id,AccountId,Nickname From user_info WHERE PhoneAreaId='{0}' AND Phone='{1}'", phoneAreaId, phone);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        public bool CheckPayPassowrd(int userId, string payPassowrd)
        {
            string strSql = string.Format("SELECT Count(*) FROM user_info WHERE Id ={0} AND PayPassword ='{1}'", userId, payPassowrd);
            object obj = MySqlHelper.Single.ExecuteScalar(strSql);
            try
            {
                int rows = Convert.ToInt32(obj);
                return rows == 1;
            }
            catch (Exception exception)
            {
                LogHelper.error("检查支付密码时出错", exception);
                return false;
            }
        }

        public DataTable QueryUserVipInfo(int userId)
        {
            string strSql = string.Format("SELECT vri.ID,vri.`Name`,vri.Rank FROM  user_info u  LEFT JOIN vip_rank_info as vri ON vri.Id=u.VipId  WHERE u.Id={0} ", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        public bool UpdateUserVip(int userId, int vipId)
        {
            string strSql = string.Format("UPDATE user_info SET VipId ={0} WHERE Id={1} ", vipId, userId);
            return MySqlHelper.Single.ExecuteNonQuery(strSql) == 1;
        }
        /// <summary>
        /// 获取当前用户真实VIP等级Rank
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int CheckUserVipRank(uint userId)
        {
            string strSql = string.Format("SELECT vri.Rank FROM user_cloud_miner ucm LEFT JOIN vip_ur_cloudminer as vuc ON vuc.CommodityId=ucm.CommodityId LEFT JOIN vip_rank_info as vri ON vri.id=vuc.VipId WHERE ucm.State ='0' AND ucm.UserId={0} ORDER BY vri.Rank DESC LIMIT 1  ", userId);
            object obj = MySqlHelper.Single.ExecuteScalar(strSql);
            if (obj == null)
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 检查是否为股东账户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckIsShareholder(int userId)
        {
            string strSql = string.Format("select * FROM user_info WHERE Id={0} AND Type='2' ", userId);
            DataTable dataTable = MySqlHelper.Single.ExecuteDataTable(strSql);
            return dataTable.Rows.Count == 1;
        }
    }
}
