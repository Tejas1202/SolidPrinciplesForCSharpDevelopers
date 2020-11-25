using System;
using System.Collections.Generic;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    /// <summary>
    /// Seperately giving Logging responsibility given to ConsoleLogger class
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
