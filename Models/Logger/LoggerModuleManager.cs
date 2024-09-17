namespace Logger;

using System.Collections.Generic;

/// <summary>
/// Module manager for Logger module.
/// 
/// Might as well create a module interface for easier control.
/// 
/// </summary>

public static class LoggerModuleManager
{

    /// <summary>
    /// 
    /// Records :
    /// 
    ///     LoggerList/_loggerList, preparation for future ILogger might required to be trace and
    ///     keep a record.
    /// 
    /// </summary>

    private static List<ILogger> _loggerList = new List<ILogger>();

    public static List<ILogger> LoggerList
    {
        get
        {
            return _loggerList;
        }

        private set
        {
            _loggerList = value;
        }
    }

    /// <summary>
    /// 
    /// Init logge with a config file.
    /// 
    /// This file seems to be look at the sln directory.
    /// </summary>
    /// <param name="configFile">File name of the config file. (Example : NLog.config)</param>
    public static void LoggerInit(string configFile)
    {
        NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configFile); 
        // NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("Nlog.config"); 
    }
}
