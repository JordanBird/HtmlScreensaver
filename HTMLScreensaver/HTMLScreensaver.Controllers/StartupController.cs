using HTMLScreensaver.Controllers;
using HTMLScreensaver.Services;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace HTMLScreensaver.Controllers
{
    public class StartupController
    {
        public void Start(IEnumerable<string> arguments)
        {
            var argument = arguments.Count() == 0 ? "" : arguments.FirstOrDefault().ToLower().Substring(0, 2);

            new CefSharpService().InitCEF();

            switch (argument)
            {
                case "":
                    new HomeController().Show();
                    break;
                case "/p":
                    new PreviewController().Show(arguments.Skip(1).FirstOrDefault());
                    break;
                case "/c":
                    new ConfigureController().Show();
                    break;
                case "/s":
                default:
                    new ScreensaverController().Show();
                    break;
            }
        }
    }
}