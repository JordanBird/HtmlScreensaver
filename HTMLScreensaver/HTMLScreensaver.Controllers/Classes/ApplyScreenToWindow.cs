using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HTMLScreensaver.Controllers.Classes
{
    public class ApplyScreenToWindow
    {
        public static T Apply<T>(T window, Screen screen) where T : Window
        {
            var ratio = GetRatio.Get();

            window.Left = screen.WorkingArea.Left / ratio;
            window.Top = screen.WorkingArea.Top / ratio;
            window.Width = screen.WorkingArea.Width / ratio;
            window.Height = screen.WorkingArea.Height / ratio;

            return window;
        }
    }
}