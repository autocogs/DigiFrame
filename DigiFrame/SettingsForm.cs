using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiFrame
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Properties.Settings.Default.Reload();
        }

        private void tkbar_imgInterval_Scroll(object sender, EventArgs e)
        {
            TrackBar s = (TrackBar)sender;
            tt_imgInterval.SetToolTip(s, (s.Value * 10).ToString() + " sec");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
