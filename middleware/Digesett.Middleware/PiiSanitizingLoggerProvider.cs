using Microsoft.Extensions.Logging;
using System;

public class PiiSanitizingLoggerProvider : ILoggerProvider
{
    private readonly ILoggerProvider _consoleProvider;

    public PiiSanitizingLoggerProvider()
    {
        _consoleProvider = LoggerFactory.Create(b => b.AddConsole()).CreateLogger<PiiSanitizingLoggerProvider>() is ILogger logger
            ? new WrappedLoggerProvider(logger)
            : new NullLoggerProvider();
    }

    public ILogger CreateLogger(string categoryName)
    {
        var inner = _consoleProvider.CreateLogger(categoryName);
        return new PiiSanitizingLogger(inner);
    }

    public void Dispose() => _consoleProvider.Dispose();

    private class WrappedLoggerProvider : ILoggerProvider
    {
        private readonly ILogger _logger;
        public WrappedLoggerProvider(ILogger logger) => _logger = logger;
        public ILogger CreateLogger(string categoryName) => _logger;
        public void Dispose() { }
    }

    private class NullLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new NullLogger();
        public void Dispose() { }
    }

    private class NullLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => false;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) { }
    }
}
