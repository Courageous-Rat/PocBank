using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerilogToKibana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = CreateSerilogConfiguration();
            var logger = configuration.CreateLogger();
            var random = new Random();

            while(true)
            {
                var waitTime = random.Next(1000);
                Thread.Sleep(waitTime);
                logger.Information(Guid.NewGuid().ToString(), new { Public = "Hello World", Private = "This is a Secret" });
            }
        }

        private static LoggerConfiguration CreateSerilogConfiguration()
        {
            var elasticSearchOptions = new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                CustomFormatter = new CustomElastiFormatter()
            };

            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(elasticSearchOptions);
        }
    }
}
