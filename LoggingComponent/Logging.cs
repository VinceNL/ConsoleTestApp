using System;
using System.Diagnostics;

namespace LoggingComponent
{
    public class Logging
    {
        [Conditional("LOG_INFO")]
        public static void LogToScreen(string message)
        {
            Console.WriteLine(message);
        }

        [Obsolete("Use LogToScreen instead", true)]
        public static void LogToFile(string message)
        {
            Console.WriteLine("Simulating logging text to file, " + message);
        }
    }
}
