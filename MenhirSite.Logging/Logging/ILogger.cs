using MenhirSite.Model;

namespace MenhirSite.BusinessLogic.Logging
{
    public interface ILogger
    {
        void WriteLog(LogLevel logLevel, string message);
        void WriteLog(LogLevel logLevel, string message, string exception);
        void WriteLog(LogLevel logLevel, string message, string exception, string stack);
        void WriteLog(LogLevel logLevel, string message, string exception, string stack, string incidentId);
    }
}
