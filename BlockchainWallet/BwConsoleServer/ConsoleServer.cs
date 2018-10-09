using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace BwConsoleService
{
    /// <summary>
    /// 服务控制类
    /// </summary>
    public class ConsoleServer
    {
        //调度器工厂
        private ISchedulerFactory _factory;
        //调度器
        private IScheduler _scheduler;
        /// <summary>
        /// 开始运行服务
        /// </summary>
        public async void RunServer()
        {
            _factory = new StdSchedulerFactory();
            _scheduler = await _factory.GetScheduler();
            IJobDetail jobDetail = JobBuilder.Create<RunCloudMinerJob>().WithIdentity("RunCloudMinerJob", "RunCloudMinerJobGroup").Build();
            //ITrigger triggerRunCloudMinerJob = TriggerBuilder.Create()
            //    .WithIdentity("RunCloudMinerTrigger", "RunCloudMinerJobGroup").WithCronSchedule("0 0 3 * * ?").Build();
            ITrigger triggerRunCloudMinerJob = TriggerBuilder.Create()
                .WithIdentity("RunCloudMinerTrigger", "RunCloudMinerJobGroup").WithCronSchedule("0 0/1 * * * ?").Build();
            await _scheduler.ScheduleJob(jobDetail, triggerRunCloudMinerJob);
            await _scheduler.Start();
        }
    }
}
