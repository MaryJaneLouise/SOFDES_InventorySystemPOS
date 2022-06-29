namespace POSWithInventorySystem
{
    partial class BackupForm
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupForm));
            this.lblProductLogs = new System.Windows.Forms.Label();
            this.bunifuTransitionBackUp = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFileNameError = new System.Windows.Forms.Label();
            this.btnLockMe = new Bunifu.Framework.UI.BunifuTileButton();
            this.lblLocationError = new System.Windows.Forms.Label();
            this.btnBackUp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtDatabaseName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.btnBrowse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtLocation = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.PanelLocked = new System.Windows.Forms.Panel();
            this.btnUnlock = new Bunifu.Framework.UI.BunifuTileButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.PanelLocked.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductLogs
            // 
            this.lblProductLogs.AutoSize = true;
            this.lblProductLogs.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransitionBackUp.SetDecoration(this.lblProductLogs, BunifuAnimatorNS.DecorationType.None);
            this.lblProductLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.lblProductLogs.Location = new System.Drawing.Point(12, 9);
            this.lblProductLogs.Name = "lblProductLogs";
            this.lblProductLogs.Size = new System.Drawing.Size(315, 42);
            this.lblProductLogs.TabIndex = 48;
            this.lblProductLogs.Text = "Backup Database";
            // 
            // bunifuTransitionBackUp
            // 
            this.bunifuTransitionBackUp.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransitionBackUp.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.bunifuTransitionBackUp.DefaultAnimation = animation2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.lblFileNameError);
            this.panel2.Controls.Add(this.btnLockMe);
            this.panel2.Controls.Add(this.lblLocationError);
            this.panel2.Controls.Add(this.btnBackUp);
            this.panel2.Controls.Add(this.txtDatabaseName);
            this.panel2.Controls.Add(this.lblDatabaseName);
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.txtLocation);
            this.panel2.Controls.Add(this.lblLocation);
            this.bunifuTransitionBackUp.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(23, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 476);
            this.panel2.TabIndex = 0;
            // 
            // lblFileNameError
            // 
            this.lblFileNameError.AutoSize = true;
            this.bunifuTransitionBackUp.SetDecoration(this.lblFileNameError, BunifuAnimatorNS.DecorationType.None);
            this.lblFileNameError.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNameError.ForeColor = System.Drawing.Color.Red;
            this.lblFileNameError.Location = new System.Drawing.Point(659, 179);
            this.lblFileNameError.Name = "lblFileNameError";
            this.lblFileNameError.Size = new System.Drawing.Size(31, 21);
            this.lblFileNameError.TabIndex = 45;
            this.lblFileNameError.Text = "❌";
            // 
            // btnLockMe
            // 
            this.btnLockMe.BackColor = System.Drawing.Color.Silver;
            this.btnLockMe.color = System.Drawing.Color.Silver;
            this.btnLockMe.colorActive = System.Drawing.SystemColors.AppWorkspace;
            this.btnLockMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransitionBackUp.SetDecoration(this.btnLockMe, BunifuAnimatorNS.DecorationType.None);
            this.btnLockMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnLockMe.ForeColor = System.Drawing.Color.Black;
            this.btnLockMe.Image = null;
            this.btnLockMe.ImagePosition = 21;
            this.btnLockMe.ImageZoom = 50;
            this.btnLockMe.LabelPosition = 43;
            this.btnLockMe.LabelText = "Cancel Backup";
            this.btnLockMe.Location = new System.Drawing.Point(27, 325);
            this.btnLockMe.Margin = new System.Windows.Forms.Padding(6);
            this.btnLockMe.Name = "btnLockMe";
            this.btnLockMe.Size = new System.Drawing.Size(667, 58);
            this.btnLockMe.TabIndex = 1;
            this.btnLockMe.Click += new System.EventHandler(this.btnLockMe_Click);
            // 
            // lblLocationError
            // 
            this.lblLocationError.AutoSize = true;
            this.bunifuTransitionBackUp.SetDecoration(this.lblLocationError, BunifuAnimatorNS.DecorationType.None);
            this.lblLocationError.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationError.ForeColor = System.Drawing.Color.Red;
            this.lblLocationError.Location = new System.Drawing.Point(518, 81);
            this.lblLocationError.Name = "lblLocationError";
            this.lblLocationError.Size = new System.Drawing.Size(31, 21);
            this.lblLocationError.TabIndex = 44;
            this.lblLocationError.Text = "❌";
            // 
            // btnBackUp
            // 
            this.btnBackUp.Activecolor = System.Drawing.Color.Teal;
            this.btnBackUp.BackColor = System.Drawing.Color.Teal;
            this.btnBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackUp.BorderRadius = 0;
            this.btnBackUp.ButtonText = "Backup";
            this.btnBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransitionBackUp.SetDecoration(this.btnBackUp, BunifuAnimatorNS.DecorationType.None);
            this.btnBackUp.DisabledColor = System.Drawing.Color.Gray;
            this.btnBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnBackUp.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBackUp.Iconimage = null;
            this.btnBackUp.Iconimage_right = null;
            this.btnBackUp.Iconimage_right_Selected = null;
            this.btnBackUp.Iconimage_Selected = null;
            this.btnBackUp.IconMarginLeft = 0;
            this.btnBackUp.IconMarginRight = 0;
            this.btnBackUp.IconRightVisible = false;
            this.btnBackUp.IconRightZoom = 0D;
            this.btnBackUp.IconVisible = false;
            this.btnBackUp.IconZoom = 90D;
            this.btnBackUp.IsTab = false;
            this.btnBackUp.Location = new System.Drawing.Point(28, 258);
            this.btnBackUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Normalcolor = System.Drawing.Color.Teal;
            this.btnBackUp.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnBackUp.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBackUp.selected = false;
            this.btnBackUp.Size = new System.Drawing.Size(667, 58);
            this.btnBackUp.TabIndex = 43;
            this.btnBackUp.Text = "Backup";
            this.btnBackUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBackUp.Textcolor = System.Drawing.Color.White;
            this.btnBackUp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BorderColorFocused = System.Drawing.Color.Black;
            this.txtDatabaseName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDatabaseName.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtDatabaseName.BorderThickness = 2;
            this.txtDatabaseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransitionBackUp.SetDecoration(this.txtDatabaseName, BunifuAnimatorNS.DecorationType.None);
            this.txtDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDatabaseName.ForeColor = System.Drawing.Color.Gray;
            this.txtDatabaseName.isPassword = false;
            this.txtDatabaseName.Location = new System.Drawing.Point(27, 171);
            this.txtDatabaseName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(668, 38);
            this.txtDatabaseName.TabIndex = 42;
            this.txtDatabaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDatabaseName.OnValueChanged += new System.EventHandler(this.txtDatabaseName_OnValueChanged);
            this.txtDatabaseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatabaseName_KeyPress);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.bunifuTransitionBackUp.SetDecoration(this.lblDatabaseName, BunifuAnimatorNS.DecorationType.None);
            this.lblDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblDatabaseName.Location = new System.Drawing.Point(23, 140);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(113, 25);
            this.lblDatabaseName.TabIndex = 41;
            this.lblDatabaseName.Text = "File Name *";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Activecolor = System.Drawing.Color.Teal;
            this.btnBrowse.BackColor = System.Drawing.Color.Teal;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.BorderRadius = 7;
            this.btnBrowse.ButtonText = "Browse";
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransitionBackUp.SetDecoration(this.btnBrowse, BunifuAnimatorNS.DecorationType.None);
            this.btnBrowse.DisabledColor = System.Drawing.Color.Gray;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBrowse.Iconimage = null;
            this.btnBrowse.Iconimage_right = null;
            this.btnBrowse.Iconimage_right_Selected = null;
            this.btnBrowse.Iconimage_Selected = null;
            this.btnBrowse.IconMarginLeft = 0;
            this.btnBrowse.IconMarginRight = 0;
            this.btnBrowse.IconRightVisible = false;
            this.btnBrowse.IconRightZoom = 0D;
            this.btnBrowse.IconVisible = false;
            this.btnBrowse.IconZoom = 90D;
            this.btnBrowse.IsTab = false;
            this.btnBrowse.Location = new System.Drawing.Point(563, 73);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Normalcolor = System.Drawing.Color.Teal;
            this.btnBrowse.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnBrowse.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBrowse.selected = false;
            this.btnBrowse.Size = new System.Drawing.Size(132, 38);
            this.btnBrowse.TabIndex = 40;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowse.Textcolor = System.Drawing.Color.White;
            this.btnBrowse.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.BorderColorFocused = System.Drawing.Color.Black;
            this.txtLocation.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLocation.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtLocation.BorderThickness = 2;
            this.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransitionBackUp.SetDecoration(this.txtLocation, BunifuAnimatorNS.DecorationType.None);
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtLocation.ForeColor = System.Drawing.Color.Black;
            this.txtLocation.isPassword = false;
            this.txtLocation.Location = new System.Drawing.Point(27, 73);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(526, 38);
            this.txtLocation.TabIndex = 39;
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.bunifuTransitionBackUp.SetDecoration(this.lblLocation, BunifuAnimatorNS.DecorationType.None);
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblLocation.Location = new System.Drawing.Point(23, 43);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(99, 25);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location *";
            // 
            // PanelLocked
            // 
            this.PanelLocked.BackColor = System.Drawing.Color.Teal;
            this.PanelLocked.Controls.Add(this.btnUnlock);
            this.bunifuTransitionBackUp.SetDecoration(this.PanelLocked, BunifuAnimatorNS.DecorationType.None);
            this.PanelLocked.ForeColor = System.Drawing.SystemColors.Control;
            this.PanelLocked.Location = new System.Drawing.Point(182, 179);
            this.PanelLocked.Name = "PanelLocked";
            this.PanelLocked.Size = new System.Drawing.Size(764, 383);
            this.PanelLocked.TabIndex = 0;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.Teal;
            this.btnUnlock.color = System.Drawing.Color.Teal;
            this.btnUnlock.colorActive = System.Drawing.Color.DarkCyan;
            this.btnUnlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransitionBackUp.SetDecoration(this.btnUnlock, BunifuAnimatorNS.DecorationType.None);
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUnlock.ForeColor = System.Drawing.Color.White;
            this.btnUnlock.Image = null;
            this.btnUnlock.ImagePosition = 21;
            this.btnUnlock.ImageZoom = 50;
            this.btnUnlock.LabelPosition = 43;
            this.btnUnlock.LabelText = "Authorized Access Only! Click this warning to access this form.";
            this.btnUnlock.Location = new System.Drawing.Point(64, 136);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(6);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(621, 101);
            this.btnUnlock.TabIndex = 0;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.bunifuTransitionBackUp.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(182, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 510);
            this.panel1.TabIndex = 0;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1108, 706);
            this.Controls.Add(this.PanelLocked);
            this.Controls.Add(this.lblProductLogs);
            this.Controls.Add(this.panel1);
            this.bunifuTransitionBackUp.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "BackupForm";
            this.Text = "BackupForm";
            this.Load += new System.EventHandler(this.BackupForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelLocked.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProductLogs;
        private BunifuAnimatorNS.BunifuTransition bunifuTransitionBackUp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFileNameError;
        private Bunifu.Framework.UI.BunifuTileButton btnLockMe;
        private System.Windows.Forms.Label lblLocationError;
        private Bunifu.Framework.UI.BunifuFlatButton btnBackUp;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private Bunifu.Framework.UI.BunifuFlatButton btnBrowse;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Panel PanelLocked;
        private Bunifu.Framework.UI.BunifuTileButton btnUnlock;
        private System.Windows.Forms.Panel panel1;
    }
}