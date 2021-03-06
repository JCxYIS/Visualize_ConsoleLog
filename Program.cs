﻿using System;
using System.Diagnostics;

namespace DebugNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string exe_path = @"YOUR_PROGRAM_PATH"; // e.g. E:\Downloads\a.exe
            string exe_param = "YOUR PARAMS";       // e.g. -f -g idk

            if (args.Length > 0)
            {
                exe_path = args[0];
                args[0] = "";
            }
            if (args.Length > 1)
            {
                exe_param = String.Join(" ", args);
            }

            Console.WriteLine($"path={exe_path}\nparam={exe_param}");

            Debugger debugger = new Debugger(exe_path, exe_param);

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
