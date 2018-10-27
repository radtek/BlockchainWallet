using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BwBackModel.CommodityMgmt;
using BwBackModel.SystemMgmt;
using BwCommon.Log;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;
using Quartz;

namespace BwConsoleService
{
    public class RunCloudMinerJob : IJob
    {
        private static readonly CloudMinerApi CloudMinerApi = SalApiFactory<CloudMinerApi>.GetSalApi();

        public Task Execute(IJobExecutionContext context)
        {
            RunCloudMiner();
            return Task.FromResult(true);
        }

        /// <summary>
        /// 运行一次云矿机
        /// </summary>
        public void RunCloudMiner()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***************************[Begin]{0:yyyy-MM-dd HH:mm:ss}**************************", DateTime.Now);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    Start cloud miner server");
            LogHelper.info("Start cloud miner server");
            DateTime dateTime = DateTime.Now;
            RunCloudMinerModelSend runCloudMinerModelSend = new RunCloudMinerModelSend();
            runCloudMinerModelSend.EmployeeId = LoginedUserInfo.Id;
            string result = CloudMinerApi.RunCloudMiner(runCloudMinerModelSend);
            if (result != "0")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    Error for cloud miner server :" + result);
                LogHelper.error("Error for cloud miner server :" + result);
                return;
            }
            while (true)
            {
                Thread.Sleep(40 * 1000);
                result = CloudMinerApi.CheckCloudMiner(runCloudMinerModelSend);
                switch (result)
                {
                    case "0":
                        Console.WriteLine("    Cloud miner server is Closed");
                        Console.WriteLine("****************************[End]{0:yyyy-MM-dd HH:mm:ss}****************************", DateTime.Now);
                        return;
                    case "1":
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        TimeSpan timeSpan = (DateTime.Now - dateTime);
                        string str =
                            string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                "    Cloud miner server succeed,spend [{0}:{1}:{2}:{3}]",
                                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
                        Console.WriteLine(str);
                        LogHelper.info(str);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("****************************[End]{0:yyyy-MM-dd HH:mm:ss}****************************", DateTime.Now);
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    Error for cloud miner server :" + result);
                        LogHelper.error("Error for cloud miner server :" + result);
                        Console.WriteLine("****************************[End]{0:yyyy-MM-dd HH:mm:ss}****************************", DateTime.Now);
                        return;
                }
            }
        }
    }
}
