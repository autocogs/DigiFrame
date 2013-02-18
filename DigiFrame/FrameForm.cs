using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiFrame
{
    public partial class FrameForm : Form
    {
        private MenuItem mi_playCtrl;
        private string imageFolder;
        private Timer t_imgTransition;
        private string[] imageList;
        private int img_idx;
        private PictureBox picbx_visible;
        private PictureBox picbx_next;

        public FrameForm(Screen s)
        {
            InitializeComponent();
            
            /* Set Form Positioning in Secondary Window */
            this.Left = s.Bounds.Left;
            this.Top = s.Bounds.Top;
            this.Size = s.Bounds.Size;
            this.WindowState = FormWindowState.Maximized;

            /* Create Right Click Menu */
            ContextMenu cxtMnu = new ContextMenu();

            this.mi_playCtrl = new MenuItem("Pause", mi_playCtrl_Clicked);
            cxtMnu.MenuItems.Add(this.mi_playCtrl);
            cxtMnu.MenuItems.Add("-");
            cxtMnu.MenuItems.Add("Close Frame", delegate(object sndr, EventArgs e) { this.Close(); });

            this.ContextMenu = cxtMnu;

            /* Load Image Settings */
            this.t_imgTransition = new Timer();
            this.t_imgTransition.Tick += t_imgTransition_Tick;
            LoadSettings();

            /* Initiate Picture Boxes */
#if DEBUG
            System.Diagnostics.Debug.Print("Initialize picbx_visible");
#endif
            img_idx = 0;
            picbx_visible = new PictureBox();
            picbx_visible.Parent = this;
            picbx_visible.Size = this.Size;
            picbx_visible.Location = new Point(0, 0);
            picbx_visible.Hide();
            if (imageList.Length > 0)
                picbx_visible.Image = Image.FromFile(imageList[0]);

#if DEBUG
            System.Diagnostics.Debug.Print("Initialize picbx_next");
#endif
            picbx_next = new PictureBox();
            picbx_next.Parent = this;
            picbx_next.Size = this.Size;
            picbx_next.Location = new Point(0, 0);
            picbx_next.Hide();
            if (imageList.Length > 1)
                picbx_next.Image = Image.FromFile(imageList[1]);
#if DEBUG
            System.Diagnostics.Debug.Print(picbx_next.Parent.ToString());
#endif

            picbx_visible.FitContainer();
            picbx_visible.Center();
            picbx_visible.Show();

            Properties.Settings.Default.SettingsSaving += delegate(object sndr, CancelEventArgs e){ LoadSettings(); };

            /* Start Timer */
            this.t_imgTransition.Start();
        }

        void t_imgTransition_Tick(object sender, EventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.Print("Timer Triggered");
            System.Diagnostics.Debug.Print("Image - {0:D}: {1}", this.img_idx, this.imageList[this.img_idx]);
#endif

            /* Swap Picture Objects */
            PictureBox tmp = this.picbx_next;
            this.picbx_next = this.picbx_visible;
            this.picbx_visible = tmp;
#if DEBUG
            System.Diagnostics.Debug.Print(picbx_visible.ToString());
#endif
            this.picbx_visible.FitContainer();
            this.picbx_visible.Center();
            this.picbx_visible.Show();

            this.picbx_next.Hide();

            while (!File.Exists(this.imageList[this.img_idx]) && this.imageList.Length > this.img_idx)
            {
                this.img_idx++;
            }

            if (this.imageList.Length <= this.img_idx)
            {
                UpdateImageList();
                this.img_idx = 0;
            }

            this.picbx_next.Image = Image.FromFile(this.imageList[this.img_idx++]);
        }

        public void mi_playCtrl_Clicked(object sender, EventArgs evntArgs)
        {
            this.t_imgTransition.Enabled = !this.t_imgTransition.Enabled;
            this.mi_playCtrl.Text = (this.t_imgTransition.Enabled ? "Pause" : "Play");
        }

        private string[] GetFilesByExtension(string path, string searchPattern, System.IO.SearchOption searchOptions){
            List<string> files = new List<string>();
            string[] patterns = searchPattern.Split('|');
            foreach (string p in patterns)
            {
                files.AddRange(System.IO.Directory.GetFiles(path, "*."+p, searchOptions));
            }
            return files.ToArray();
        }

        private void LoadSettings()
        {
            if (this.t_imgTransition.Interval != Properties.Settings.Default.ImageInterval * 10000)
            {
                bool running = this.t_imgTransition.Enabled;
                this.t_imgTransition.Stop();
                this.t_imgTransition.Interval = Properties.Settings.Default.ImageInterval * 10000; // dekaseconds => milliseconds
                if (running)
                    this.t_imgTransition.Start();
            }
            if (this.imageFolder != Properties.Settings.Default.ImageFolder)
            {
                this.imageFolder = Properties.Settings.Default.ImageFolder;
                UpdateImageList();
            }
        }

        private void UpdateImageList()
        {
            this.imageList = GetFilesByExtension(this.imageFolder, Properties.Settings.Default.ImageExt,
                    SearchOption.AllDirectories);
        }

        private void FrameForm_Load(object sender, EventArgs e)
        {

        }

        private void FrameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.t_imgTransition.Enabled = false;
        }

        ~FrameForm()
        {
            this.t_imgTransition.Enabled = false;
            this.t_imgTransition.Dispose();
            this.mi_playCtrl.Dispose();
            this.picbx_visible.Dispose();
            this.picbx_next.Dispose();
        }



    }
}
