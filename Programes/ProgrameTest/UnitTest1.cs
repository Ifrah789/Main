using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace ProgramTest
{
    [TestFixture]
    public class ProcessMonitorTest
    {
        [Test]
        public void Monitor_Calculator_Less_Than_Max_Lifetime_Does_Not_Kill_It()
        {
            const string calculatorPath = "/System/Applications/Calculator.app";
            const string processName = "Calculator";
            const Double maxLifetime = 0.30;
            const int frequency = 1;
            var startInfo = new ProcessStartInfo
            {
                FileName = calculatorPath,
                UseShellExecute = true
            };
            var process = Process.Start(startInfo);

            var thread = new Thread(() => Program.Main(new[] { processName, maxLifetime.ToString(), frequency.ToString() }));
            thread.Start();
            Thread.Sleep(5000);

            process.Refresh();
            Assert.That(process.HasExited, Is.False);

            process.CloseMainWindow();
            thread.Join();
        }
    }
}
