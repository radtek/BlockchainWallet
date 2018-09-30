using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace TimerTest
{
    class Program
    {
        public static object _objLock = new object();
        static void Main(string[] args)
        {
            bool state = false;
            DateTime dtLast = DateTime.Now;

            int count = 0;
            Timer timer = new Timer();
            timer = new Timer();
            timer.Interval = 3000;
            timer.Elapsed += (sender, e) =>
            {
                DateTime dtDateTime = DateTime.Now;
                double d = (dtDateTime - dtLast).TotalMilliseconds;
                dtLast = dtDateTime;
                Console.WriteLine("Running2..." + dtDateTime.ToString("yyyy-MM-dd HH:mm:ss:ffff      ") + "TimeSpan:" + d);

                return;
                timer.Interval = 1;
                if (state)
                {
                    Console.WriteLine("Running1...");
                    timer.Interval = 1000;
                    return;
                }
                lock (_objLock)
                {
                    if (state)
                    {
                        Console.WriteLine("Running2..." + dtDateTime.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
                        timer.Interval = 1000;
                        return;
                    }
                    state = true;
                    //timer.Interval = (DateTime.Now.AddDays(1) - DateTime.Now).TotalMilliseconds - 60 * 60 * 1000;
                }
                Console.WriteLine("RunCount: " + count + "   RunTime: " + dtDateTime.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
                count++;
                Thread.Sleep(2000);
                timer.Interval = 1;
                state = false;
            };
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            Console.WriteLine("StartRunServer...");
            Console.ReadKey();
        }
    }
}
