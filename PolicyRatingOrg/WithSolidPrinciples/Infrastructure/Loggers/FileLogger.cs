using System.IO;

namespace PolicyRatingOrg.WithSolidPrinciples.Infrastructure.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
