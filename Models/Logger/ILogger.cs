// Copyright © 2024 Ten. All rights reserved.
namespace LoggerModule;

/*

Description :

    Define interface for Logging class.

Version :

    Beta 0.0.1

*/


public interface ILogger
{
    void SetClassLogger(object classInstance);
    
    void Log (string message, params object[] args);

    void Trace (string message, params object[] args);

    void Info (string message, params object[] args);

    void Debug (string message, params object[] args);

    void Warn (string message, params object[] args);

    void Fatal (string message, params object[] args);
}

/*
    **********GuideLine**********

    *****ILogger Definition***** 

    Log - Use this as temp debug, might be easier to control?

    Fatal - Program Crash Error ( program could not continue )

    Warning - FileNotFound etc ( with handling )

    Info - UserHasLoggerIn etc

    Debug - Debug( Running Function )

    Trace - Save Execution Data
*/
