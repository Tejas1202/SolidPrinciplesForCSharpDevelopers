using System;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    /// <summary>
    /// Seperately giving Logging responsibility given to ConsoleLogger class
    /// </summary>
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
