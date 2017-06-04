using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLScreensaver.Models
{
    public class Monitor
    {
        public string MonitorName { get; set; }

        public string URL { get; set; }
        public string InitialBackgroundColour { get; set; }
        public bool Enabled { get; set; }
    }
}