using HTMLScreensaver.ViewModels;
using HTMLScreensaver.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using static HTMLScreensaver.Controllers.Classes.Interop;

namespace HTMLScreensaver.Controllers
{
    public class PreviewController
    {
        public void Show(string previewHandleArgument)
        {
            Screensaver screensaver = new Screensaver()
            {
                DataContext = new ScreensaverViewModel()
                {
                    URL = "www.google.co.uk",
                    BackgroundColour = "Red"
                }
            };

            Int32 previewHandle = Convert.ToInt32(previewHandleArgument);
            IntPtr pPreviewHnd = new IntPtr(previewHandle);
            RECT lpRect = new RECT();
            bool bGetRect = Win32API.GetClientRect(pPreviewHnd, ref lpRect);

            HwndSourceParameters sourceParameters = new HwndSourceParameters("sourceParameters")
            {
                PositionX = 0,
                PositionY = 0,
                Height = lpRect.Bottom - lpRect.Top,
                Width = lpRect.Right - lpRect.Left,
                ParentWindow = pPreviewHnd,
                WindowStyle = (int)(WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN)
            };

            var winWPFContent = new HwndSource(sourceParameters);
            winWPFContent.Disposed += (o, args) => screensaver.Close();
            winWPFContent.RootVisual = screensaver.GetMainGrid();
        }
    }
}