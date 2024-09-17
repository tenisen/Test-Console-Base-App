namespace Logger;

using NLog;

public class LoggerBaseClass : ILogger
{
    /// <summary>
    /// Use LoggerBaseClass as class base or use the SetClassLogger.
    /// </summary>
    private Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public void SetClassLogger(object classInstance)
    {
        logger = LogManager.GetLogger(classInstance.GetType().Name);
    }

    public void Log(string message, params object[] args)
    {
        logger.Log(LogLevel.Debug, message, args);
    }

    public void Debug(string message, params object[] args)
    {
        logger.Log(LogLevel.Debug, message, args);
    }

    public void Fatal(string message, params object[] args)
    {
        logger.Log(LogLevel.Fatal, message, args);
    }

    public void Info(string message, params object[] args)
    {
        logger.Log(LogLevel.Info, message, args);
    }

    public void Trace(string message, params object[] args)
    {
        logger.Log(LogLevel.Trace, message, args);
    }

    public void Warn(string message, params object[] args)
    {
        logger.Log(LogLevel.Warn, message, args);
    }
}