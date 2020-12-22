using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HTMLScreensaver.Controllers.Classes
{
    //Sourced with thanks: https://stackoverflow.com/questions/38330214/actual-resolution-of-secondary-screen-for-custom-dpi
    public static class GetRatio
    {
        public static double Get()
        {
            return Math.Max(Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
                        Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);
        }
    }
}