using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigiFrame.Properties;
using System.Configuration;

namespace DigiFrame
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
            
            // Configure Default Image Path Setting
            if (!System.IO.Directory.Exists(Settings.Default.ImageFolder))
            {
                Settings.Default.ImageFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Settings.Default.Save();
            }
            // NOTE: Assuming Click-Once is used, settings will auto-upgrade
            NotificationMenuWrapper nmw = new NotificationMenuWrapper();
            Application.Run();
        }
    }
}
