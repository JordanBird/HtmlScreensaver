using HTMLScreensaver.Services;
using HTMLScreensaver.ViewModels;
using HTMLScreensaver.ViewModels.Abstract;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace HTMLScreensaver.Controllers
{
    public class ScreensaverController
    {
        public void Show()
        {
            var settings = new SettingsService();

            foreach (Screen screen in Screen.AllScreens)
            {
                var screenSettings = settings.MonitorSettings.FirstOrDefault(x => x.MonitorName == screen.DeviceName);
                var colours = screenSettings?.InitialBackgroundColour.Replace("rgba", "").Trim('(', ')').Split(',');
                var colour = colours.Length < 4 ? "Black" : Color.FromArgb(byte.Parse(colours[0]), byte.Parse(colours[1]), byte.Parse(colours[2]), byte.Parse(colours[3])).ToString();

                Screensaver screensaver = new Screensaver()
                {
                    Left = screen.WorkingArea.Left,
                    Top = screen.WorkingArea.Top,
                    Width = screen.WorkingArea.Width,
                    Height = screen.WorkingArea.Height,
                    DataContext = new ScreensaverViewModel()
                    {
                        URL = screenSettings?.URL,
                        BackgroundColour = colour
                    }
                };

                screensaver.Show();

                //We have to set this after so the view knows which monitor it belongs to.
                screensaver.WindowState = WindowState.Maximized;
            }

            Mouse.OverrideCursor = System.Windows.Input.Cursors.None;
        }
    }
}