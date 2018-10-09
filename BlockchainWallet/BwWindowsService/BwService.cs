using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BwWindowsService
{
    partial class BwService : ServiceBase
    {
        public BwService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开启Windows服务
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // TODO:  在此处添加代码以启动服务。
        }

        /// <summary>
        /// 关闭Windows 服务
        /// </summary>
        protected override void OnStop()
        {
            // TODO:  在此处添加代码以执行停止服务所需的关闭操作。
        }


    }
}
