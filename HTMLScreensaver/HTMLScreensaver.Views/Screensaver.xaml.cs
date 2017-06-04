using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTMLScreensaver.Views
{
    /// <summary>
    /// Interaction logic for Screensaver.xaml
    /// </summary>
    public partial class Screensaver : Window
    {
        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);
        int mouseMovethreshold = 5;

        public Screensaver()
        {
            InitializeComponent();
        }
        
        public void CloseScreensaver(object sender, EventArgs e)
        {
            Mouse.OverrideCursor = null;

            Application.Current.Shutdown();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (OriginalLocation.X == int.MaxValue & OriginalLocation.Y == int.MaxValue)
            {
                OriginalLocation = e.GetPosition(null);
            }

            if (Math.Abs(e.GetPosition(null).X - OriginalLocation.X) > mouseMovethreshold | Math.Abs(e.GetPosition(null).Y - OriginalLocation.Y) > mouseMovethreshold)
            {
                CloseScreensaver(sender, e);
            }
        }

        public Grid GetMainGrid()
        {
            return this.GridMain;
        }
    }
}