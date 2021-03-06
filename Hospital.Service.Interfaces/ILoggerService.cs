﻿namespace Hospital.Service.Interfaces
{
    public interface ILoggerService<T>
        where T : class
    {
        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
    }
}