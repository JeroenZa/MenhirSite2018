using MenhirSite.Model;
using MenhirSite.Services.Interface;

namespace MenhirSite.BusinessLogic.Logging
{
    public class Logger : ILogger
    {
        private readonly ILoggingService _loggingService;

        public Logger(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void WriteLog(LogLevel logLevel, string message)
        {
            _loggingService.Create(CreateLogging(logLevel, message));
        }

        public void WriteLog(LogLevel logLevel, string message, string exception)
        {
            _loggingService.Create(CreateLogging(logLevel, message, exception));
        }

        public void WriteLog(LogLevel logLevel, string message, string exception, string stack)
        {
            _loggingService.Create(CreateLogging(logLevel, message, exception, stack));
        }

        public void WriteLog(LogLevel logLevel, string message, string exception, string stack, string incidentId)
        {
            _loggingService.Create(CreateLogging(logLevel, message, exception, stack, incidentId));
        }

        private static Model.Logging CreateLogging(LogLevel logLevel, string message, string exception = "", string stack = "", string incidentId = "")
        {
            var logging = new Model.Logging
            {
                Level = logLevel,
                Message = message,
                Exception = exception,
                Stack = stack,
                IncidentId = incidentId,
                EventId = 1
            };

            return logging;
        }
    }
}