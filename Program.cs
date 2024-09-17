namespace TestingGround;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;

public class Program
{
    public static void Main(string[] args)
    {
        // This is the main program. ( Program Entry )

        // Try to design the program logic here be4 doing a GUI binding.

        // Following IMS original design.

        


        Console.WriteLine("*****Program Started*****");

        // Enter Program Logic Here

        // Load Config File for Logging Module
        LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");


        Console.WriteLine("*****Program Ended*****");

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