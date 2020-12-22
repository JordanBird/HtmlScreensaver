using HTMLScreensaver.Controllers.Classes;
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
                var colour = "Black"; //TODO: Load this from a global settings file managed by the user.

                if (screenSettings != null)
                {
                    var colours = screenSettings?.InitialBackgroundColour.Replace("rgba", "").Trim('(', ')').Split(',');
                    colour = colours.Length < 4 ? "Black" : Color.FromArgb(byte.Parse(colours[0]), byte.Parse(colours[1]), byte.Parse(colours[2]), byte.Parse(colours[3])).ToString();
                }
                
                var screensaver = ApplyScreenToWindow.Apply(new Screensaver()
                {
                    DataContext = new ScreensaverViewModel()
                    {
                        URL = screenSettings?.URL ?? "",
                        BackgroundColour = colour
                    }
                }, screen);

                screensaver.Show();

                //We have to set this after so the view knows which monitor it belongs to.
                screensaver.WindowState = WindowState.Maximized;
            }

            Mouse.OverrideCursor = System.Windows.Input.Cursors.None;
        }
    }
}