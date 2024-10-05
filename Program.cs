namespace ConsoleTestingGround;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ConsoleTestingGround.InventoryManagementSystem;
using DatabaseModule;
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


        Console.WriteLine(abd.a1.ToString());
        Console.WriteLine(abd.v1.ToString());
        Console.WriteLine(abd.B2.ToString());

        // Program Logic Here.

        // BasicDataBase basicDataBase = new BasicDataBase("test");
        

        // InventoryManagementSystem instance = new InventoryManagementSystem();
        // instance.StartProgram();

        Console.WriteLine("*****Program File Ended*****");

    }
}

enum abd
{
    a1,
    v1,
    B2
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