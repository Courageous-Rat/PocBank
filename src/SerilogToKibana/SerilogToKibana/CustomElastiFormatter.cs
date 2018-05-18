using Newtonsoft.Json;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogToKibana
{
    public class CustomElastiFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var logEntry = new SimpleKibanaLogEntry
            {
                Timestamp = logEvent.Timestamp.DateTime,
                PublicData = logEvent.MessageTemplate.Text,
                PrivateData = Guid.NewGuid().ToString()
            };

            var json = JsonConvert.SerializeObject(logEntry);
            output.Write(json);
        }
    }
}
