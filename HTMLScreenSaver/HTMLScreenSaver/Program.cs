using CefSharp;
using HTMLScreenSaver.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var settings = new SettingsHelper().ReadFromSettings();
            new CefHelper().InitCEF();

            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/s") //show
                {
                    ShowScreensaver();
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/p") //preview
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmScreensaver(new IntPtr(long.Parse(args[1])), settings.First().Value));
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/c") //configure
                {
                    ShowConfigure();
                }
            }
            else
            {
                ShowConfigure();
            }
        }

        private static void ShowConfigure()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmConfigure configure = new frmConfigure();
            configure.Show();

            Application.Run();
        }

        private static void ShowScreensaver()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Random r = new Random();

            var settings = new SettingsHelper().ReadFromSettings();

            foreach (Screen screen in Screen.AllScreens)
            {
                string url = "";

                if (settings.ContainsKey(screen.DeviceName))
                {
                    url = settings[screen.DeviceName];
                }

                frmScreensaver screensaver = new frmScreensaver(screen.Bounds, url);
                screensaver.Show();
            }

            Application.Run();
        }
    }
}