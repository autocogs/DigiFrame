using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace DigiFrame
{
    class NotificationMenuWrapper : Form
    {
        private NotifyIcon appIcon;
        private MenuItem mi_frameCtrl;
        private SettingsForm frm_settings = null;
        private FrameForm frm_frame = null;

        public NotificationMenuWrapper()
        {
            /* Modify Wrapper Form Appearance */
            this.ShowInTaskbar = false;

            this.FormClosed += this.NotificationMenuWrapper_FormClosed;

            /* Costruct NotifyIcon and Menu */
            this.appIcon = new NotifyIcon();
            this.appIcon.Icon = DigiFrame.Properties.Resources.NotifyIcon;
            this.appIcon.BalloonTipClicked += delegate(object s, EventArgs e) { FrameForm_Create(); };
            this.appIcon.Visible = true;
            
            ContextMenu cxtMnu = new ContextMenu();

            this.mi_frameCtrl = new MenuItem("Open",mi_frameCtrl_Clicked);
            cxtMnu.MenuItems.Add(this.mi_frameCtrl);
            cxtMnu.MenuItems.Add("-");
            cxtMnu.MenuItems.Add("Settings",SettingsForm_Clicked);       // Settings
            cxtMnu.MenuItems.Add("-");              // Separator
            cxtMnu.MenuItems.Add("Exit",            // Exit Menu
                delegate(object s, EventArgs e) { Application.Exit(); });

            this.appIcon.ContextMenu = cxtMnu;

            /* Register Function for Changed Display Settings */
            SystemEvents.DisplaySettingsChanged += PollDisplaySettings_EventHandler;

            PollDisplaySettings_EventHandler(null, null);
        }

        public void PollDisplaySettings_EventHandler(object sender, EventArgs evntArgs)
        {
            if (Screen.AllScreens.Length > 1) // IF Multiple Monitors Attached
            {
                this.mi_frameCtrl.Enabled = true;
                if (Properties.Settings.Default.AutoDisplay) // IF Auto-Display
                {
                    FrameForm_Create();
                }
                else
                {
                    this.appIcon.ShowBalloonTip(3000,"DigiFrame Compatible Monitor Detected",
                        "A second monitor has been detected on this computer. Click to make it a DigiFrame.",
                        ToolTipIcon.Info);
                }
                return;
            }
            // ELSE One Monitor
            this.mi_frameCtrl.Enabled = false;
            if (this.frm_frame != null) 
                this.frm_frame.Close();
        }

        public void mi_frameCtrl_Clicked(object sender, EventArgs evntArgs)
        {
            MenuItem s = (MenuItem)sender;
            if (this.frm_frame == null)
            {
                FrameForm_Create();
                return;
            }
            this.frm_frame.Close();
        }

        public void SettingsForm_Clicked(object sender, EventArgs evntArgs)
        {
            this.frm_settings = new SettingsForm();
            this.frm_settings.FormClosed += delegate(object s, FormClosedEventArgs e) { this.frm_settings.Dispose(); this.frm_settings = null; };
            this.frm_settings.Show();
        }

        public void FrameForm_Create()
        {
            Screen sec = Screen.AllScreens.FirstOrDefault(s => s != Screen.PrimaryScreen) ?? null;
            if (this.frm_frame == null && sec != null)
            {
                this.frm_frame = new FrameForm(sec);
                this.frm_frame.FormClosed += FrameForm_Closed;
                this.mi_frameCtrl.Text = "Close";
                this.frm_frame.Show();
            }
        }

        public void FrameForm_Closed(object sender, EventArgs evntArgs)
        {
            this.frm_frame.Dispose();
            this.frm_frame = null;
            this.mi_frameCtrl.Text = "Open";
        }

        public void NotificationMenuWrapper_FormClosed(object sender, FormClosedEventArgs e)
        {
            appIcon.Dispose();
        }

        ~NotificationMenuWrapper()
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NotificationMenuWrapper
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "NotificationMenuWrapper";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.NotificationMenuWrapper_Load);
            this.ResumeLayout(false);

        }

        private void NotificationMenuWrapper_Load(object sender, EventArgs e)
        {
            //this.Visible = false;
        }


    }
}
