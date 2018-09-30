using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CustomerServiceSystem.IdCardCertification;

namespace BwServerSal.ServiceApi.CustomerServiceSystem
{
    public class IdCardCertificationApi
    {
        public List<IdCardCertificationModelGet> QueryIdCardCertification(IdCardCertificationModelSend idCardCertificationModelSend)
        {
            HeadModelGet<List<IdCardCertificationModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<IdCardCertificationModelGet>>>.PostMsg(
                ApiAddress.QueryIdCardCertification, idCardCertificationModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

        public bool CheckIdCard(IdCardCheckModelSend idCardCheckModelSend)
        {
            HeadModelGet<List<IdCardCertificationModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<IdCardCertificationModelGet>>>.PostMsg(
                ApiAddress.CheckIdCard, idCardCheckModelSend);
            return headModelGet.Code == 0;
        }

        public IdCardCertificationModelGet QueryIdCardCertificationInfo(IdCardCertificationModelSend idCardCertificationModelSend)
        {
            HeadModelGet<IdCardCertificationModelGet> headModelGet = BwHttpApiAccess<HeadModelGet<IdCardCertificationModelGet>>.PostMsg(
                ApiAddress.QueryIdCardCertificationInfo, idCardCertificationModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
