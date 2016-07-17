using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;

namespace HTMLScreenSaver
{
    public partial class frmScreensaver : Form
    {
        #region Preview API's
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
        #endregion

        bool IsPreviewMode = false;
        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);
        int mouseMovethreshold = 5;

        public ChromiumWebBrowser browser = new ChromiumWebBrowser("");
        public frmScreensaver(Rectangle Bounds, string url)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Bounds;
            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
                Enabled = false
            };
            this.Controls.Add(browser);
            Cursor.Hide();
        }

        public frmScreensaver(IntPtr PreviewHandle, string url)
        {
            InitializeComponent();

            //set the preview window as the parent of this window
            SetParent(this.Handle, PreviewHandle);

            //make this a child window, so when the select screensaver 
            //dialog closes, this will also close
            SetWindowLong(this.Handle, -16,
                  new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            //set our window's size to the size of our window's new parent
            Rectangle ParentRect;
            GetClientRect(PreviewHandle, out ParentRect);
            this.Size = ParentRect.Size;

            //set our location at (0, 0)
            this.Location = new Point(0, 0);

            
            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
                Enabled = false
            };
            this.Controls.Add(browser);
            Cursor.Hide();

            IsPreviewMode = true;
        }

        private void frmScreensaver_Load(object sender, EventArgs e)
        {
            this.Click += new EventHandler(ExitScreensaver);
            this.KeyDown += new KeyEventHandler(ExitScreensaver);
            this.MouseMove += new MouseEventHandler(MouseMoveDetector);
        }

        private void MouseMoveDetector(object sender, MouseEventArgs e)
        {
            if (OriginalLocation.X == int.MaxValue & OriginalLocation.Y == int.MaxValue)
            {
                OriginalLocation = e.Location;
            }

            if (Math.Abs(e.X - OriginalLocation.X) > mouseMovethreshold | Math.Abs(e.Y - OriginalLocation.Y) > mouseMovethreshold)
            {
                ExitScreensaver(sender, e);
            }
        }

        private void ExitScreensaver(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
