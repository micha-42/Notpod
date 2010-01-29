﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using iTunesAgent.UI.Properties;

namespace iTunesAgent.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             
            if (Properties.Settings.Default.UpgradeSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
            }

            if (String.IsNullOrEmpty(Settings.Default.Language ))
                Settings.Default.Language = "en-GB";
            Application.CurrentCulture = new CultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
            
            Application.Run(new MainForm());
        }
    }
}
