using HTMLScreensaver.Models;
using HTMLScreensaver.Services;
using HTMLScreensaver.ViewModels;
using HTMLScreensaver.ViewModels.Abstract;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLScreensaver.Controllers
{
    public class ConfigureController
    {
        public void Show()
        {
            var screens = Screen.AllScreens.Select(x => x.DeviceName);
            var existing = new SettingsService().MonitorSettings;

            foreach (var screen in screens)
            {
                if (existing.Any(x => x.MonitorName == screen))
                {
                    continue;
                }

                existing.Add(new Monitor()
                {
                    MonitorName = screen
                });
            }

            Configure configure = new Configure()
            {
                DataContext = new ConfigureViewModel()
                {
                    Monitors = existing,
                    MonitorNames = existing.Select(x => x.MonitorName),
                    MonitorName = existing.FirstOrDefault().MonitorName,
                    SaveCommand = new DelegateCommand<List<Monitor>>(SaveCommand)
                }
            };
            configure.Show();
        }

        public void SaveCommand(List<Monitor> monitors)
        {
            var settings = new SettingsService();

            foreach (var monitor in monitors)
            {
                settings.SetMonitor(monitor);
            }
            
            settings.Save();
        }
    }
}