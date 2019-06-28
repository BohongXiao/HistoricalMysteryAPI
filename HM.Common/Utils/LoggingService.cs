using HM.Interfaces.IUtils;
using NLog;
using NLog.Web;

namespace HM.Common.Utils
{
    public class LoggingService : ILoggingService
    {
        private static readonly Logger Log = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public void Trace(string message)
        {
            Log.Trace(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Warn(string message)
        {
            Log.Warn(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }
    }
}