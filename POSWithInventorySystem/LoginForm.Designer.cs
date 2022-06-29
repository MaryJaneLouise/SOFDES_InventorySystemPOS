namespace POSWithInventorySystem
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelUp = new System.Windows.Forms.Panel();
            this.lblMinimizeForm = new System.Windows.Forms.Label();
            this.lblFormClose = new System.Windows.Forms.Label();
            this.lblLoginForm = new System.Windows.Forms.Label();
            this.txtUsername = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.timerFormLoad = new System.Windows.Forms.Timer(this.components);
            this.lblValidaton = new System.Windows.Forms.Label();
            this.btnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.Teal;
            this.panelUp.Controls.Add(this.lblMinimizeForm);
            this.panelUp.Controls.Add(this.lblFormClose);
            this.panelUp.Controls.Add(this.lblLoginForm);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(861, 51);
            this.panelUp.TabIndex = 0;
            // 
            // lblMinimizeForm
            // 
            this.lblMinimizeForm.AutoSize = true;
            this.lblMinimizeForm.Font = new System.Drawing.Font("DM Sans", 14.25F);
            this.lblMinimizeForm.Location = new System.Drawing.Point(778, 17);
            this.lblMinimizeForm.Name = "lblMinimizeForm";
            this.lblMinimizeForm.Size = new System.Drawing.Size(22, 25);
            this.lblMinimizeForm.TabIndex = 0;
            this.lblMinimizeForm.Text = "-";
            this.lblMinimizeForm.Click += new System.EventHandler(this.lblMinimizeForm_Click);
            // 
            // lblFormClose
            // 
            this.lblFormClose.AutoSize = true;
            this.lblFormClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFormClose.Location = new System.Drawing.Point(810, 14);
            this.lblFormClose.Name = "lblFormClose";
            this.lblFormClose.Size = new System.Drawing.Size(24, 25);
            this.lblFormClose.TabIndex = 0;
            this.lblFormClose.Text = "X";
            this.lblFormClose.Click += new System.EventHandler(this.lblFormClose_Click);
            // 
            // lblLoginForm
            // 
            this.lblLoginForm.AutoSize = true;
            this.lblLoginForm.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblLoginForm.Location = new System.Drawing.Point(12, 13);
            this.lblLoginForm.Name = "lblLoginForm";
            this.lblLoginForm.Size = new System.Drawing.Size(177, 25);
            this.lblLoginForm.TabIndex = 0;
            this.lblLoginForm.Text = "DMN Programming";
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.HintForeColor = System.Drawing.Color.Empty;
            this.txtUsername.HintText = "";
            this.txtUsername.isPassword = false;
            this.txtUsername.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txtUsername.LineIdleColor = System.Drawing.Color.Black;
            this.txtUsername.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txtUsername.LineThickness = 5;
            this.txtUsername.Location = new System.Drawing.Point(386, 129);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(428, 59);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username";
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.OnValueChanged += new System.EventHandler(this.txtUsername_OnValueChanged);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HintForeColor = System.Drawing.Color.Empty;
            this.txtPassword.HintText = "";
            this.txtPassword.isPassword = false;
            this.txtPassword.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txtPassword.LineIdleColor = System.Drawing.Color.Black;
            this.txtPassword.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txtPassword.LineThickness = 5;
            this.txtPassword.Location = new System.Drawing.Point(386, 224);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(428, 59);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.OnValueChanged += new System.EventHandler(this.txtPassword_OnValueChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // timerFormLoad
            // 
            this.timerFormLoad.Interval = 30;
            this.timerFormLoad.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblValidaton
            // 
            this.lblValidaton.AutoSize = true;
            this.lblValidaton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidaton.ForeColor = System.Drawing.Color.Red;
            this.lblValidaton.Location = new System.Drawing.Point(535, 290);
            this.lblValidaton.Name = "lblValidaton";
            this.lblValidaton.Size = new System.Drawing.Size(0, 19);
            this.lblValidaton.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Activecolor = System.Drawing.Color.DarkCyan;
            this.btnLogin.BackColor = System.Drawing.Color.Teal;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.ButtonText = "Sign In";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnLogin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogin.Iconimage = null;
            this.btnLogin.Iconimage_right = null;
            this.btnLogin.Iconimage_right_Selected = null;
            this.btnLogin.Iconimage_Selected = null;
            this.btnLogin.IconMarginLeft = 0;
            this.btnLogin.IconMarginRight = 0;
            this.btnLogin.IconRightVisible = true;
            this.btnLogin.IconRightZoom = 0D;
            this.btnLogin.IconVisible = true;
            this.btnLogin.IconZoom = 90D;
            this.btnLogin.IsTab = false;
            this.btnLogin.Location = new System.Drawing.Point(386, 337);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Normalcolor = System.Drawing.Color.Teal;
            this.btnLogin.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogin.selected = false;
            this.btnLogin.Size = new System.Drawing.Size(428, 54);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Tag = "";
            this.btnLogin.Text = "Sign In";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Textcolor = System.Drawing.Color.White;
            this.btnLogin.TextFont = new System.Drawing.Font("Segoe UI", 15.75F);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelUp;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POSWithInventorySystem.Properties.Resources.Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(32, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 438);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblValidaton);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.panelUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelUp;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPassword;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUsername;
        private System.Windows.Forms.Label lblMinimizeForm;
        private System.Windows.Forms.Label lblFormClose;
        private System.Windows.Forms.Label lblLoginForm;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogin;
        private System.Windows.Forms.Timer timerFormLoad;
        private System.Windows.Forms.Label lblValidaton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}

