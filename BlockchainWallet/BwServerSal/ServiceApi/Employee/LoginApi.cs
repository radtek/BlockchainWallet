using System.Net;
using BwBackModel;
using BwBackModel.UserMgmt.Login;
using BwCommon.EncryptionDecryption;

namespace BwServerSal.ServiceApi.Employee
{
    public class LoginApi
    {
        public LoginModelGet Login(LoginModelSend loginModelSend)
        {
            loginModelSend.LoginPassword = Md5Helper.Md5Encrypt(Md5Helper.Md5Encrypt(loginModelSend.AccountId).ToUpper() +
                Md5Helper.Md5Encrypt(loginModelSend.LoginPassword).ToUpper()).ToUpper();
            //BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptType = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptDecryptType.Aes;
            HeadModelGet<LoginModelGet> loginModelGet = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.PostMsg(
                ApiAddress.EmployeeLogin, loginModelSend);
            if (loginModelGet.Code == 0)
            {
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.ClearCookie();
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("Token", loginModelGet.Data.Token), ApiAddress.ApiUrlRoot);
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("UserId", loginModelGet.Data.Id.ToString()), ApiAddress.ApiUrlRoot);
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("Type", "0"), ApiAddress.ApiUrlRoot);
            }
            //BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptType = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptDecryptType.Aes;
            return loginModelGet.Code == 0 ? loginModelGet.Data : null;
        }
        public LoginModelGet Login(LoginModelSend loginModelSend, out string messages)
        {
            if (loginModelSend.AccountId == "windowsserver")
            {
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("UserId", "6"), ApiAddress.ApiUrlRoot);
            }
            loginModelSend.LoginPassword = Md5Helper.Md5Encrypt(Md5Helper.Md5Encrypt(loginModelSend.AccountId).ToUpper() +
                Md5Helper.Md5Encrypt(loginModelSend.LoginPassword).ToUpper()).ToUpper();
            //BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptType = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptDecryptType.Aes;
            HeadModelGet<LoginModelGet> loginModelGet = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.PostMsg(
                ApiAddress.EmployeeLogin, loginModelSend);
            if (loginModelGet == null)
            {
                messages = "server connect fault";
                return null;
            }
            if (loginModelGet.Code == 0)
            {
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.ClearCookie();
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("Token", loginModelGet.Data.Token), ApiAddress.ApiUrlRoot);
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("UserId", loginModelGet.Data.Id.ToString()), ApiAddress.ApiUrlRoot);
                BwHttpApiAccess<HeadModelGet<LoginModelGet>>.AddCookie(new Cookie("Type", "0"), ApiAddress.ApiUrlRoot);
            }
            messages = string.IsNullOrEmpty(loginModelGet.Messages) ? "account or password fault " : loginModelGet.Messages;
            //BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptType = BwHttpApiAccess<HeadModelGet<LoginModelGet>>.EncryptDecryptType.Aes;
            return loginModelGet.Code == 0 ? loginModelGet.Data : null;
        }
    }
}
