using Microsoft.Extensions.Logging;
using NReco.Logging.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Internal;

namespace Pragmatic.Client.MT4.Hourglass.Extensions
{
    internal class FileLoggerFactory<T> : ILogger<T> where T : class
    {
        private readonly ILogger _logger;
        public FileLoggerFactory(ILoggerProvider factory)
        {
            _logger = factory.CreateLogger(typeof(T).FullName);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}
