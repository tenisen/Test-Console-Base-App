namespace ConsoleTestingGround.InventoryManagementSystem;
// Copyright © 2024 Ten. All rights reserved.

using System;

// Module
using LoggerModule;

public class InventoryManagementSystem
{
    private bool _isInitialized ;

    private readonly string _loggerConfigFile = "Nlog.config";

    /// <summary>
    /// 
    /// Start the program.
    /// 
    /// </summary>
    public void StartProgram()
    {
        
        Initialize();

        if(!_isInitialized)
        {
            // Not Initialized
            throw new InvalidOperationException("Program is not initialized!");
        }

        // All Modules should be Initialized. 
        // Initialize should only key in settings.
        // Working should be check during checking phase.

        ILogger logger = new LoggerBaseClass();
        logger.SetClassLogger(this);

        logger.Info("Program Started.");
        logger.Info("Start Modules Checking !");
        logger.Info("Connecting Database !");
        logger.Info("Program Running !");
        logger.Info("Accepting Input !");
        logger.Info("Program Ended");

        
    }

    /// <summary>
    /// 
    /// Initialize each module for this program.
    /// 
    /// </summary>
    private void Initialize()
    {
        try
        {
            InitializeLogger();
        }
        catch
        {
            _isInitialized = false;
            throw;
        }

        _isInitialized = true;
        
    }

    private void InitializeLogger()
    {
        try
        {
            LoggerModuleManager.LoggerInit(_loggerConfigFile);
        }
        catch
        {
            throw;
        }
    }


}

/*
    Module Required*****************************************************************************

    Logger ( Should be able to use for now.)

    Data Base ( Link sqlite )
    - Serializer to save settings
    - This was not implemented in a finite state machine structure.
    - This is a basic database structure.
    - Basic Database done, serializer attribute not yet.

    Functions ( Program Structure )
    - How to maintain these function
    - What function I Need ?
    - This one need to decide with flow.

    Login
    - How to control login ?

    Safety ( Backup )
    - How to backup ?

    ( FSM ?) ( Status method )

    21/12/2024
    
    Further Record

    - Data Driven Architecture

*/