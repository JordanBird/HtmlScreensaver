using HTMLScreensaver.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTMLScreensaver.ViewModels
{
    public class ScreensaverViewModel : ObservableObject
    {
        public string URL { get; set; }
        public string BackgroundColour { get; set; }
    }
}