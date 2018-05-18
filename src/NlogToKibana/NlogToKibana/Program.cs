using NLog;
using NLog.Config;
using System;
using System.Threading;

namespace NlogToKibana
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger("Kibana");
            var random = new Random();

            while (true)
            {
                var waitTime = random.Next(1000);
                Thread.Sleep(waitTime);
                logger.Info(Guid.NewGuid().ToString());
            }
        }
    }
}
