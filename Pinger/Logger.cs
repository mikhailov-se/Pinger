using NLog;
using ILogger = Pinger.Interfaces.ILogger;

namespace Pinger
{
    public class Logger : ILogger
    {
        private static NLog.Logger _logger;

        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void LogSuccess(string mes)
        {
            _logger.Info(mes);
        }

        public void LogError(string mes)
        {
            _logger.Error(mes);
        }
    }
}