using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CommodityMgmt;
using BwBackModel.SystemMgmt;

namespace BwServerSal.ServiceApi.Commodity
{
    public class CloudMinerApi
    {
        public List<CloudMinerInfoModelGet> QueryCommodityInfo(CloudMinerInfoModelSend cloudMinerInfoModelSend)
        {
            HeadModelGet<List<CloudMinerInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CloudMinerInfoModelGet>>>.PostMsg(
                ApiAddress.QueryCloudMiner, cloudMinerInfoModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

        /// <summary>
        /// 运行矿机
        /// </summary>
        /// <param name="runCloudMinerModelSend"></param>
        /// <returns>返回启动结果：0 正常启动  非0 错误异常信息 </returns>
        public string RunCloudMiner(RunCloudMinerModelSend runCloudMinerModelSend)
        {
            HeadModelGet<List<UserCloudMinerModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<UserCloudMinerModelGet>>>.PostMsg(
                ApiAddress.RunCloudMiner, runCloudMinerModelSend);
            return headModelGet.Code == 0 ? "0" : headModelGet.Messages;
        }

        /// <summary>
        /// 检查矿机运行状态
        /// </summary>
        /// <param name="runCloudMinerModelSend"></param>
        /// <returns>返回启动结果：0 未运行 1 矿机运行中   2 正常结束  其他 错误异常信息 </returns>
        public string CheckCloudMiner(RunCloudMinerModelSend runCloudMinerModelSend)
        {
            HeadModelGet<UserCloudMinerModelGet> headModelGet = BwHttpApiAccess<HeadModelGet<UserCloudMinerModelGet>>.PostMsg(
                ApiAddress.CheckCloudMiner, runCloudMinerModelSend);
            return headModelGet.Messages;
        }
    }
}
