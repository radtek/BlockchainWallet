using System;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log\\Log4Net.config", Watch = true)]
namespace BwCommon.Log
{
    public class LogHelper
    {
        private LogHelper() { }

        private static readonly ILog AppLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static LogHelper()
        {

        }

        public static void fatal(string message, Exception exception)
        {
            if (AppLog.IsFatalEnabled) AppLog.Fatal(message, exception);
        }
        public static void fatal(string message)
        {
            LogHelper.fatal(message, null);
        }

        public static void error(string message, Exception exception)
        {
            if (AppLog.IsErrorEnabled) AppLog.Error(message, exception);
        }
        public static void error(string message)
        {
            LogHelper.error(message, null);
        }

        public static void warn(string message)
        {
            if (AppLog.IsWarnEnabled) AppLog.Warn(message);
        }

        public static void info(string message)
        {
            if (AppLog.IsInfoEnabled) AppLog.Info(message);
        }

        public static void debug(string message)
        {
            if (AppLog.IsDebugEnabled) AppLog.Debug(message);
        }

    }
}