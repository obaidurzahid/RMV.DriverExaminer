using Microsoft.Extensions.Logging;
using RMV.DriverExaminer.Service.Interfaces;

namespace RMV.DriverExaminer.Infrastructure.Logging
{
    public class CustomLogger<T> : ICustomLogger<T>
    {
        private readonly ILogger<T> _logger;

        public CustomLogger(ILoggerFactory loggerFactory) 
        {
            _logger = loggerFactory.CreateLogger<T>();

        }
        public void Information(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
        public void Warning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
        public void Error(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}
