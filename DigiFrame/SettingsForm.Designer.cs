namespace DigiFrame
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.grp_settings = new System.Windows.Forms.GroupBox();
            this.btn_imgBrowse = new System.Windows.Forms.Button();
            this.lbl_imgInterval = new System.Windows.Forms.Label();
            this.lbl_imgFolder = new System.Windows.Forms.Label();
            this.tt_imgInterval = new System.Windows.Forms.ToolTip(this.components);
            this.chbx_autoDisplay = new System.Windows.Forms.CheckBox();
            this.tkbar_imgInterval = new System.Windows.Forms.TrackBar();
            this.tbx_imgFolder = new System.Windows.Forms.TextBox();
            this.chbx_recursive = new System.Windows.Forms.CheckBox();
            this.grp_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbar_imgInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(165, 205);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(246, 205);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // grp_settings
            // 
            this.grp_settings.Controls.Add(this.chbx_recursive);
            this.grp_settings.Controls.Add(this.chbx_autoDisplay);
            this.grp_settings.Controls.Add(this.tkbar_imgInterval);
            this.grp_settings.Controls.Add(this.btn_imgBrowse);
            this.grp_settings.Controls.Add(this.tbx_imgFolder);
            this.grp_settings.Controls.Add(this.lbl_imgInterval);
            this.grp_settings.Controls.Add(this.lbl_imgFolder);
            this.grp_settings.Location = new System.Drawing.Point(9, 4);
            this.grp_settings.Name = "grp_settings";
            this.grp_settings.Size = new System.Drawing.Size(312, 195);
            this.grp_settings.TabIndex = 8;
            this.grp_settings.TabStop = false;
            // 
            // btn_imgBrowse
            // 
            this.btn_imgBrowse.Location = new System.Drawing.Point(221, 16);
            this.btn_imgBrowse.Name = "btn_imgBrowse";
            this.btn_imgBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_imgBrowse.TabIndex = 9;
            this.btn_imgBrowse.Text = "Browse";
            this.btn_imgBrowse.UseVisualStyleBackColor = true;
            // 
            // lbl_imgInterval
            // 
            this.lbl_imgInterval.AutoSize = true;
            this.lbl_imgInterval.Location = new System.Drawing.Point(14, 78);
            this.lbl_imgInterval.Name = "lbl_imgInterval";
            this.lbl_imgInterval.Size = new System.Drawing.Size(74, 13);
            this.lbl_imgInterval.TabIndex = 7;
            this.lbl_imgInterval.Text = "Image Interval";
            // 
            // lbl_imgFolder
            // 
            this.lbl_imgFolder.AutoSize = true;
            this.lbl_imgFolder.Location = new System.Drawing.Point(14, 21);
            this.lbl_imgFolder.Name = "lbl_imgFolder";
            this.lbl_imgFolder.Size = new System.Drawing.Size(68, 13);
            this.lbl_imgFolder.TabIndex = 6;
            this.lbl_imgFolder.Text = "Image Folder";
            // 
            // chbx_autoDisplay
            // 
            this.chbx_autoDisplay.AutoSize = true;
            this.chbx_autoDisplay.Checked = global::DigiFrame.Properties.Settings.Default.AutoDisplay;
            this.chbx_autoDisplay.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DigiFrame.Properties.Settings.Default, "AutoDisplay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chbx_autoDisplay.Location = new System.Drawing.Point(17, 154);
            this.chbx_autoDisplay.Name = "chbx_autoDisplay";
            this.chbx_autoDisplay.Size = new System.Drawing.Size(157, 17);
            this.chbx_autoDisplay.TabIndex = 11;
            this.chbx_autoDisplay.Text = "Auto-Display on Connection";
            this.chbx_autoDisplay.UseVisualStyleBackColor = true;
            // 
            // tkbar_imgInterval
            // 
            this.tkbar_imgInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DigiFrame.Properties.Settings.Default, "ImageInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tkbar_imgInterval.LargeChange = 1;
            this.tkbar_imgInterval.Location = new System.Drawing.Point(17, 102);
            this.tkbar_imgInterval.Maximum = 6;
            this.tkbar_imgInterval.Minimum = 1;
            this.tkbar_imgInterval.Name = "tkbar_imgInterval";
            this.tkbar_imgInterval.Size = new System.Drawing.Size(279, 45);
            this.tkbar_imgInterval.TabIndex = 10;
            this.tkbar_imgInterval.Value = global::DigiFrame.Properties.Settings.Default.ImageInterval;
            this.tkbar_imgInterval.Scroll += new System.EventHandler(this.tkbar_imgInterval_Scroll);
            // 
            // tbx_imgFolder
            // 
            this.tbx_imgFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DigiFrame.Properties.Settings.Default, "ImageFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbx_imgFolder.Location = new System.Drawing.Point(15, 45);
            this.tbx_imgFolder.Name = "tbx_imgFolder";
            this.tbx_imgFolder.Size = new System.Drawing.Size(281, 20);
            this.tbx_imgFolder.TabIndex = 8;
            this.tbx_imgFolder.Text = global::DigiFrame.Properties.Settings.Default.ImageFolder;
            // 
            // chbx_recursive
            // 
            this.chbx_recursive.AutoSize = true;
            this.chbx_recursive.Checked = global::DigiFrame.Properties.Settings.Default.Recursive;
            this.chbx_recursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_recursive.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DigiFrame.Properties.Settings.Default, "Recursive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chbx_recursive.Location = new System.Drawing.Point(181, 154);
            this.chbx_recursive.Name = "chbx_recursive";
            this.chbx_recursive.Size = new System.Drawing.Size(111, 17);
            this.chbx_recursive.TabIndex = 12;
            this.chbx_recursive.Text = "Recursive Search";
            this.chbx_recursive.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 240);
            this.Controls.Add(this.grp_settings);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grp_settings.ResumeLayout(false);
            this.grp_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbar_imgInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox grp_settings;
        private System.Windows.Forms.TrackBar tkbar_imgInterval;
        private System.Windows.Forms.Button btn_imgBrowse;
        private System.Windows.Forms.TextBox tbx_imgFolder;
        private System.Windows.Forms.Label lbl_imgInterval;
        private System.Windows.Forms.Label lbl_imgFolder;
        private System.Windows.Forms.ToolTip tt_imgInterval;
        private System.Windows.Forms.CheckBox chbx_autoDisplay;
        private System.Windows.Forms.CheckBox chbx_recursive;
    }
}