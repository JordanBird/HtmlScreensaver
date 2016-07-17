using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLScreenSaver.Helpers
{
    public class SettingsHelper
    {
        public Dictionary<string, string> ReadFromSettings()
        {
            Dictionary<string, string> ScreensAndURLs = new Dictionary<string, string>();

            if (!File.Exists($@"{Application.StartupPath}\htmlsssettings.txt"))
            {
                return ScreensAndURLs;
            }

            string[] lines = File.ReadAllLines($@"{Application.StartupPath}\htmlsssettings.txt");

            foreach (var line in lines)
            {
                string[] split = line.Split(new string[] { "[SPLIT]" }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length != 2)
                {
                    break;
                }

                ScreensAndURLs.Add(split[0], split[1]);
            }

            return ScreensAndURLs;
        }

        public void WriteToSettings(Dictionary<string, string> screens)
        {
            string output = "";

            foreach (var screen in screens)
            {
                output += $"{screen.Key}[SPLIT]{screen.Value}{Environment.NewLine}";
            }

            File.WriteAllText($@"{Application.StartupPath}\htmlsssettings.txt", output);
        }
    }
}