using HTMLScreensaver.ViewModels;
using HTMLScreensaver.ViewModels.Abstract;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLScreensaver.Controllers
{
    public class HomeController
    {
        public void Show()
        {
            Home home = new Home()
            {
                DataContext = new HomeViewModel()
                {
                    OpenScreensaverCommand = new DelegateCommand(OpenScreensaver),
                    OpenConfigureCommand = new DelegateCommand(OpenConfigure),
                    OpenIdentifyCommand = new DelegateCommand(OpenIdentify)
                }
            };

            home.Show();
        }

        private void OpenScreensaver()
        {
            new ScreensaverController().Show();
        }

        private void OpenConfigure()
        {
            new ConfigureController().Show();
        }

        private void OpenIdentify()
        {
            new IdentifyController().Show();
        }
    }
}