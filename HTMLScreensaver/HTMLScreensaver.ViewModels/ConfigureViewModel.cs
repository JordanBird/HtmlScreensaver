using HTMLScreensaver.Models;
using HTMLScreensaver.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace HTMLScreensaver.ViewModels
{
    public class ConfigureViewModel : ObservableObject
    {
        private string _MonitorName;
        public string MonitorName { get { return _MonitorName; }
            set
            {
                _MonitorName = value;
                RaisePropertyChangedEvent("MonitorName");
                ChangeSelectedMonitor();
            }
        }

        private string _MonitorURL;
        public string MonitorURL { get { return _MonitorURL; }
            set
            {
                _MonitorURL = value;
                RaisePropertyChangedEvent("MonitorURL");
                Monitors[GetCurrentMonitorIndex()].URL = MonitorURL;
            }
        }

        private Color _MonitorColour = Color.FromRgb(1, 1, 1);
        public Color MonitorColour { get { return _MonitorColour; }
            set
            {
                _MonitorColour = value;
                RaisePropertyChangedEvent("MonitorColour");
                Monitors[GetCurrentMonitorIndex()].InitialBackgroundColour = $"rgba({MonitorColour.A},{MonitorColour.R},{MonitorColour.G},{MonitorColour.B})";
            }
        }

        public List<Monitor> Monitors { get; set; }
        public IEnumerable<string> MonitorNames { get; set; }

        public ICommand SaveCommand { get; set; }
        
        private void ChangeSelectedMonitor()
        {
            var monitorIndex = Monitors.FindIndex(x => x.MonitorName == MonitorName);
            MonitorURL = Monitors[monitorIndex].URL;

            if (!String.IsNullOrEmpty(Monitors[monitorIndex].InitialBackgroundColour))
            {
                var colours = Monitors[monitorIndex].InitialBackgroundColour.Replace("rgba", "").Trim('(', ')').Split(',');
                MonitorColour = Color.FromArgb(byte.Parse(colours[0]), byte.Parse(colours[1]), byte.Parse(colours[2]), byte.Parse(colours[3]));
            }
            else
            {
                MonitorColour = Color.FromRgb(1, 1, 1);
            }
        }

        private int GetCurrentMonitorIndex()
        {
            return Monitors.FindIndex(x => x.MonitorName == MonitorName);
        }
    }
}