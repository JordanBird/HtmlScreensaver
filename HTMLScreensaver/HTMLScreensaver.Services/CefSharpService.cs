using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLScreensaver.Services
{
    public class CefSharpService
    {
        public void InitCEF()
        {
            var cefSettings = new CefSettings()
            {
                PersistSessionCookies = true
            };

            // Useful! http://peter.sh/experiments/chromium-command-line-switches/
            SetCefSetting(cefSettings, "enable-system-flash", "1");
            SetCefSetting(cefSettings, "ppapi-in-process", "1");
            SetCefSetting(cefSettings, "disable-app-window-cycling", "1");
            SetCefSetting(cefSettings, "disable-setuid-sandbox", "1");
            SetCefSetting(cefSettings, "enable-sandbox", "0");
            SetCefSetting(cefSettings, "no-sandbox", "1");
        
            Cef.Initialize(cefSettings);
        }
        
        private void SetCefSetting(CefSettings settings, string setting, string value)
        {
            if (!settings.CefCommandLineArgs.ContainsKey(setting))
            {
                settings.CefCommandLineArgs.Add(setting, value);
            }
            else
            {
                settings.CefCommandLineArgs[setting] = value;
            }
        }
    }
}