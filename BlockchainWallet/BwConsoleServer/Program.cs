using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BwBackModel.CommodityMgmt;
using BwBackModel.UserMgmt.Login;
using BwCommon.Log;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;
using BwServerSal.ServiceApi.Employee;
using Quartz;
using Quartz.Impl;

namespace BwConsoleService
{
    class Program
    {
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll ", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);

        [DllImport("user32.dll ", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);

        private static readonly LoginApi LoginApi = SalApiFactory<LoginApi>.GetSalApi();
        static void Main(string[] args)
        {
            #region 禁止手动关闭窗体
            string fullPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //根据控制台标题找控制台
            int WINDOW_HANDLER = FindWindow(null, fullPath);
            //找关闭按钮
            IntPtr CLOSE_MENU = GetSystemMenu((IntPtr)WINDOW_HANDLER, IntPtr.Zero);
            int SC_CLOSE = 0xF060;
            //关闭按钮禁用
            RemoveMenu(CLOSE_MENU, SC_CLOSE, 0x0);
            #endregion

            #region 连接服务中显示
            Console.CursorVisible = false;
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(0, 0);
                        switch (i)
                        {
                            case 0:
                                Console.Write("Connect Server .  ");
                                break;
                            case 1:
                                Console.Write("Connect Server .. ");
                                break;
                            case 2:
                                Console.Write("Connect Server ...");
                                break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            });
            thread.Start();
            #endregion

            #region 登录服务
            LoginModelSend loginModelSend = new LoginModelSend();
            loginModelSend.AccountId = "windowsserver";
            loginModelSend.LoginPassword = "admin";
            string messages;
            LoginModelGet loginModelGet = LoginApi.Login(loginModelSend, out messages);
            thread.Abort();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            if (loginModelGet == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connect server failure");
                Console.WriteLine("Error for server :" + messages);
                Console.Write("Enter any key to exit");
                Console.ReadKey();
                return;
            }
            LoginedUserInfo.AccountId = loginModelGet.AccountId;
            LoginedUserInfo.Name = loginModelGet.Nickname;
            LoginedUserInfo.Token = loginModelGet.Token;
            LoginedUserInfo.Id = loginModelGet.Id;
            #endregion
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connect server successful");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start console server");
            LogHelper.info("Start console server");
            ConsoleServer consoleServer = new ConsoleServer();
            consoleServer.RunServer();

            #region 关闭服务
            while (true)
            {
                if (Console.ReadLine().ToLower() == "exit")
                {
                    Console.WriteLine("Sure close server？[Y/N]");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        LogHelper.info("Close console server");
                        return;
                    }
                }
            }
            #endregion
        }


        //调度器

    }
}
