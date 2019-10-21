using Hospital.Core.Interfaces;
using NLog;

namespace Hospital.Services
{
    public class LoggerService<T> : ILoggerService<T> 
        where T:class
    {
        private readonly Logger _logger;
        public LoggerService()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
        }
        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
           _logger.Warn(message);
        }

        public void Error(string message)
        {
           _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}