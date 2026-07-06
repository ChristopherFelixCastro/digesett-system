using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System;

public class PiiSanitizingLogger : ILogger
{
    private readonly ILogger _inner;
    private static readonly (Regex regex, string replacement)[] _rules = new[]
    {
        (new Regex(@"\d{3}-\d{7}-\d", RegexOptions.Compiled), "[CEDULA-REDACTED]"),
        (new Regex(@"\b\d{16}\b", RegexOptions.Compiled), "[TARJETA-REDACTED]"),
        (new Regex(@"Bearer\s+eyJ[A-Za-z0-9\-_\.]+", RegexOptions.Compiled), "Bearer [TOKEN-REDACTED]"),
        (new Regex("\"cvv\"\\s*:\\s*\"\\d{3}\"", RegexOptions.Compiled), "\"cvv\":\"[CVV-REDACTED]\"")
    };

    public PiiSanitizingLogger(ILogger inner) => _inner = inner;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => _inner.BeginScope(state);
    public bool IsEnabled(LogLevel logLevel) => _inner.IsEnabled(logLevel);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!_inner.IsEnabled(logLevel)) return;
        var message = formatter(state, exception);
        foreach (var (regex, replacement) in _rules)
            message = regex.Replace(message, replacement);
        _inner.Log(logLevel, eventId, message, exception, (m, e) => m);
    }
}
