using System;
using System.Diagnostics;
using System.IO;

namespace ProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Please enter all three argunments <process name> <max lifetime in minutes> <monitoring frequency in minutes>");
                return;
            }

            string processName = args[0];
            int maxProcessLifetime = int.Parse(args[1]);
            int frequencyMonitor = int.Parse(args[2]);

            bool exitFlag = false;
            do
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    exitFlag = true;
                    Console.WriteLine("Quitting...");
                }
                else
                {
                    var processes = Process.GetProcessesByName(processName);
                    foreach (var process in processes)
                    {
                        var lifetime = DateTime.Now - process.StartTime;
                        if (lifetime.TotalMinutes > maxProcessLifetime)
                        {
                            Console.WriteLine($"Killing process {process.ProcessName}, started at {process.StartTime}, lifetime {lifetime.TotalMinutes:F2} minutes");
                            process.Kill();
                        }
                    }

                    System.Threading.Thread.Sleep(frequencyMonitor * 60 * 1000);
                }
            } while (!exitFlag);
        }
    }
}
