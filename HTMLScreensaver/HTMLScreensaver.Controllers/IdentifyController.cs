using HTMLScreensaver.Controllers.Classes;
using HTMLScreensaver.ViewModels;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace HTMLScreensaver.Controllers
{
    public class IdentifyController
    {
        public void Show()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                var identify = ApplyScreenToWindow.Apply(new Identify()
                {
                    DataContext = new IdentifyViewModel()
                    {
                        MonitorName = screen.DeviceName
                    }
                }, screen);

                CloseFormAfter(identify, 5);
                identify.Show();
            }
        }

        private void CloseFormAfter(Identify identify, double seconds)
        {
            var timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(seconds)
            };
            timer.Tick += (sender, e) => { CloseFormAfterTick(sender, e, identify); };
            timer.Start();
        }

        private void CloseFormAfterTick(object sender, EventArgs e, Identify identify)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();

            identify.Close();
        }
    }
}