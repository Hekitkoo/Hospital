using System;
using Hospital.Core.Interfaces;

namespace Hospital.Services
{
    public class LoggerService : ILoggerService
    {
        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string message)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}