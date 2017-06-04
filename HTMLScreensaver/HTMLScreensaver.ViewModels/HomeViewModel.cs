using HTMLScreensaver.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTMLScreensaver.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public ICommand OpenScreensaverCommand { get; set; }
        public ICommand OpenConfigureCommand { get; set; }
        public ICommand OpenIdentifyCommand { get; set; }
    }
}