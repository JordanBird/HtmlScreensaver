using HTMLScreensaver.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HTMLScreensaver.Services
{
    public class SettingsService
    {
        private string _StartupPath;

        public List<Monitor> MonitorSettings = new List<Monitor>();

        public SettingsService()
        {
            _StartupPath = AppDomain.CurrentDomain.BaseDirectory;

            LoadExistingSettings();
        }

        public void SetMonitor(Monitor monitor)
        {
            var monitorIndex = GetMonitorIndexByName(monitor.MonitorName);

            var properties = monitor.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(MonitorSettings[monitorIndex], property.GetValue(monitor));
                }
            }
        }

        public void Save()
        {
            if (MonitorSettings.Count == 0)
            {
                return;
            }

            var output = "";
            var properties = MonitorSettings.FirstOrDefault().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var monitor in MonitorSettings)
            {
                foreach (var property in properties)
                {
                    output += $"[{monitor.MonitorName}{{HTML}}{property.Name}{{HTML}}{property.GetValue(monitor)}]{Environment.NewLine}";
                }
            }

            File.WriteAllText(GetFileLocation(), output);
        }

        private void LoadExistingSettings()
        {
            if (!File.Exists(GetFileLocation()))
            {
                return;
            }

            string[] lines = File.ReadAllLines(GetFileLocation());

            foreach (var line in lines)
            {
                var settingParts = line.Trim('[', ']').Split(new string[] { "{HTML}" }, StringSplitOptions.None);
                var monitorID = settingParts[0];
                var settingName = settingParts[1];
                var settingValue = settingParts[2];

                var monitorIndex = GetMonitorIndexByName(monitorID);

                var prop = MonitorSettings[monitorIndex].GetType().GetProperty(settingName, BindingFlags.Public | BindingFlags.Instance);
                if (null != prop && prop.CanWrite)
                {
                    prop.SetValue(MonitorSettings[monitorIndex], Convert.ChangeType(settingValue, prop.PropertyType), null);
                }
            }
        }

        private int GetMonitorIndexByName(string monitorName)
        {
            var monitorIndex = MonitorSettings.FindIndex(x => x.MonitorName == monitorName);
            if (monitorIndex < 0)
            {
                MonitorSettings.Add(new Monitor()
                {
                    MonitorName = monitorName
                });
                monitorIndex = MonitorSettings.Count - 1;
            }

            return monitorIndex;
        }

        private string GetFileLocation()
        {
            return $@"{_StartupPath}\htmlsssettings.txt";
        }
    }
}