using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProgrameTest

{
    [TestFixture]
    public class ProcessMonitorTest
    {
        [Test]
        public void Main_WithValidArgs_ShouldNotThrowException()
        {
            // Arrange
            const string processName = "Calculator";
            const int maxLifetime = 1;
            const int frequencyMonitor = 1;
            var args = new[] { processName, maxLifetime.ToString(), frequencyMonitor.ToString() };

            // Act and Assert
            Assert.DoesNotThrow(() => Program.Main(args));
        }
    }
}



