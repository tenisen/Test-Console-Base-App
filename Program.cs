namespace TestingGround;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ConsoleTestingGround.InventoryManagementSystem;
using NLog;
using NLog.Config;

public class Program
{
    public static void Main(string[] args)
    {
        // This is the main program. ( Program Entry )

        // Try to design the program logic here be4 doing a GUI binding.

        // Following IMS original design.

        // /home/ten/Desktop/Dotnet MAUI/TestingGroundFolder/ConsoleTestingGround/Nlog.config


        Console.WriteLine("*****Program File Started*****");

        // Program Logic Here.

        InventoryManagementSystem instance = new InventoryManagementSystem();
        instance.StartProgram();

        Console.WriteLine("*****Program File Ended*****");

    }
}
/*
    Module Required*****************************************************************************

    Logger

    Data Base

    Functions

    Login

    Safety ( Backup )

    ( FSM ?)
*/