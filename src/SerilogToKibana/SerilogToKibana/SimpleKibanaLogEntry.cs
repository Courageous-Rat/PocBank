using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogToKibana
{
    public class SimpleKibanaLogEntry
    {
        public DateTime Timestamp { get; set; }

        public string PublicData { get; set; }

        public string PrivateData { get; set; }
    }
}
