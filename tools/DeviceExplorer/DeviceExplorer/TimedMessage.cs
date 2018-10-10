using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceExplorer
{
    public class TimedMessage
    {
        public int TimeStart { get; set; }
        public List<dynamic> Payload { get; set; }
    }
}
