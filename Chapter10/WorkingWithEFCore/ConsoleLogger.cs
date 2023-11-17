using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;     //ILoggerProvider, ILogger, LogLevel
using static System.Console;

namespace Packt.Shared;

public class ConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        //we could have different logger implementations for different categoryName values, but we only have one
        return new ConsoleLogger();
    }

    //if the logger uses unmanaged resources you can dispose of them here!
    public void Dispose() { }

}

public class ConsoleLogger : ILogger
{
    // if your logger uses unmanaged resources, you can return the class that implements IDisposable here
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        //to avoid overlogging you can filter on the log level
        switch (logLevel)
        {
            case LogLevel.Trace:
            case LogLevel.Information:
            case LogLevel.None:
                return false;
            case LogLevel.Debug:
            case LogLevel.Warning:
            case LogLevel.Error:
            case LogLevel.Critical:
            default:
                return true;
        };
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId , TState state, Exception? exception, Func<TState, Exception, string> formatter)
    {

        if(eventId == 20100)
        {
            // log the level and the identifier
            Write("Level: {0}, Event Id: {1}, Event: {2}", logLevel, eventId.Id, eventId.Name);
        }

        if(state != null)
        {
            Write($", State: {state}");
        }
        if(exception != null)
        {
            Write($", Exception: {exception.Message}");
        }
        WriteLine();
    }
}
