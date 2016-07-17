using CefSharp;
using CefSharp.WinForms;
using HTMLScreenSaver.Classes;
using HTMLScreenSaver.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLScreenSaver
{
    public partial class frmConfigure : Form
    {
        public Dictionary<string, string> ScreensAndURLs { get; set; } = new Dictionary<string, string>(); //Device Name, URL

        public ChromiumWebBrowser browser = new ChromiumWebBrowser("");

        public Suggestion suggestion;

        public frmConfigure()
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser("")
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(browser);
            browser.Parent = panPreview;
        }

        private void frmConfigure_Load(object sender, EventArgs e)
        {
            SetSuggestion(new SuggestionsHelper().GetRandomSuggestion());
            ScreensAndURLs = new SettingsHelper().ReadFromSettings();

            foreach (Screen screen in Screen.AllScreens)
            {
                lbScreens.Items.Add(screen.DeviceName);

                if (!ScreensAndURLs.ContainsKey(screen.DeviceName))
                {
                    ScreensAndURLs.Add(screen.DeviceName, "");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            new SettingsHelper().WriteToSettings(ScreensAndURLs);
            Application.Exit();
        }

        private void SetSuggestion(Suggestion suggestion)
        {
            this.suggestion = suggestion;

            lblSuggestionName.Text = suggestion.Name;
            lblSuggestionDescription.Text = suggestion.Description;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            if (lbScreens.SelectedIndex >= 0)
            {
                ScreensAndURLs[lbScreens.SelectedItem.ToString()] = txtURL.Text;
            }
            
            browser.Load(txtURL.Text);
        }

        private void lbScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtURL.Text = ScreensAndURLs[lbScreens.SelectedItem.ToString()];

            if (lbScreens.SelectedIndex >= 0)
            {
                browser.Load(ScreensAndURLs[lbScreens.SelectedItem.ToString()]);
            }
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                frmIdentify identify = new frmIdentify(screen.Bounds, screen.DeviceName);
                identify.Show();
            }
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            txtURL.Text = suggestion.URL;
        }
    }
}
