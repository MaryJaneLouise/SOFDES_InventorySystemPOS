namespace POSWithInventorySystem
{
    partial class MainForm
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnBackup = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator8 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator7 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnMyAccount = new Bunifu.Framework.UI.BunifuFlatButton();
            this.BtnSales = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSignOut = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblUserTypeValue = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblTodayAndTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblDateAndTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator6 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator5 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnHistoryLog = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator3 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnTransaction = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMenu = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBoxUsers = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblPOSInventory = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.transitionPanel = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panelMenusForm = new System.Windows.Forms.Panel();
            this.transitionLogo = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.transitionPanel2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.timerDateNTime = new System.Windows.Forms.Timer(this.components);
            this.timerFormLoad = new System.Windows.Forms.Timer(this.components);
            this.panelSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSignOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsers)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.Teal;
            this.panelSideMenu.Controls.Add(this.btnBackup);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator8);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator7);
            this.panelSideMenu.Controls.Add(this.btnMyAccount);
            this.panelSideMenu.Controls.Add(this.BtnSales);
            this.panelSideMenu.Controls.Add(this.btnSignOut);
            this.panelSideMenu.Controls.Add(this.lblUserTypeValue);
            this.panelSideMenu.Controls.Add(this.lblNameValue);
            this.panelSideMenu.Controls.Add(this.lblTodayAndTime);
            this.panelSideMenu.Controls.Add(this.lblDateAndTime);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator6);
            this.panelSideMenu.Controls.Add(this.btnUsers);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator5);
            this.panelSideMenu.Controls.Add(this.btnHistoryLog);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator3);
            this.panelSideMenu.Controls.Add(this.btnStocks);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator2);
            this.panelSideMenu.Controls.Add(this.bunifuSeparator1);
            this.panelSideMenu.Controls.Add(this.btnTransaction);
            this.panelSideMenu.Controls.Add(this.btnMenu);
            this.panelSideMenu.Controls.Add(this.pictureBoxUsers);
            this.transitionPanel.SetDecoration(this.panelSideMenu, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.panelSideMenu, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.panelSideMenu, BunifuAnimatorNS.DecorationType.None);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 43);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(262, 745);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnBackup
            // 
            this.btnBackup.Activecolor = System.Drawing.Color.Teal;
            this.btnBackup.BackColor = System.Drawing.Color.Teal;
            this.btnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackup.BorderRadius = 0;
            this.btnBackup.ButtonText = "     Backup";
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnBackup, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnBackup, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnBackup, BunifuAnimatorNS.DecorationType.None);
            this.btnBackup.DisabledColor = System.Drawing.Color.DimGray;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBackup.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_backup_white_48;
            this.btnBackup.Iconimage_right = null;
            this.btnBackup.Iconimage_right_Selected = null;
            this.btnBackup.Iconimage_Selected = null;
            this.btnBackup.IconMarginLeft = 0;
            this.btnBackup.IconMarginRight = 0;
            this.btnBackup.IconRightVisible = true;
            this.btnBackup.IconRightZoom = 0D;
            this.btnBackup.IconVisible = true;
            this.btnBackup.IconZoom = 58D;
            this.btnBackup.IsTab = true;
            this.btnBackup.Location = new System.Drawing.Point(2, 609);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Normalcolor = System.Drawing.Color.Teal;
            this.btnBackup.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnBackup.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBackup.selected = false;
            this.btnBackup.Size = new System.Drawing.Size(259, 66);
            this.btnBackup.TabIndex = 23;
            this.btnBackup.Text = "     Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Textcolor = System.Drawing.Color.White;
            this.btnBackup.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // bunifuSeparator8
            // 
            this.bunifuSeparator8.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator8, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator8, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator8.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator8.LineThickness = 1;
            this.bunifuSeparator8.Location = new System.Drawing.Point(2, 600);
            this.bunifuSeparator8.Name = "bunifuSeparator8";
            this.bunifuSeparator8.Size = new System.Drawing.Size(258, 10);
            this.bunifuSeparator8.TabIndex = 22;
            this.bunifuSeparator8.Transparency = 255;
            this.bunifuSeparator8.Vertical = false;
            // 
            // bunifuSeparator7
            // 
            this.bunifuSeparator7.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator7, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator7, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator7.LineThickness = 1;
            this.bunifuSeparator7.Location = new System.Drawing.Point(0, 460);
            this.bunifuSeparator7.Name = "bunifuSeparator7";
            this.bunifuSeparator7.Size = new System.Drawing.Size(262, 10);
            this.bunifuSeparator7.TabIndex = 21;
            this.bunifuSeparator7.Transparency = 255;
            this.bunifuSeparator7.Vertical = false;
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.Activecolor = System.Drawing.Color.Black;
            this.btnMyAccount.BackColor = System.Drawing.Color.Black;
            this.btnMyAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMyAccount.BorderRadius = 0;
            this.btnMyAccount.ButtonText = "Edit Account";
            this.btnMyAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnMyAccount, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnMyAccount, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnMyAccount, BunifuAnimatorNS.DecorationType.None);
            this.btnMyAccount.DisabledColor = System.Drawing.Color.Black;
            this.btnMyAccount.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMyAccount.Iconimage = null;
            this.btnMyAccount.Iconimage_right = null;
            this.btnMyAccount.Iconimage_right_Selected = null;
            this.btnMyAccount.Iconimage_Selected = null;
            this.btnMyAccount.IconMarginLeft = 0;
            this.btnMyAccount.IconMarginRight = 0;
            this.btnMyAccount.IconRightVisible = true;
            this.btnMyAccount.IconRightZoom = 0D;
            this.btnMyAccount.IconVisible = true;
            this.btnMyAccount.IconZoom = 90D;
            this.btnMyAccount.IsTab = false;
            this.btnMyAccount.Location = new System.Drawing.Point(134, 209);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Normalcolor = System.Drawing.Color.Black;
            this.btnMyAccount.OnHovercolor = System.Drawing.Color.Black;
            this.btnMyAccount.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMyAccount.selected = false;
            this.btnMyAccount.Size = new System.Drawing.Size(118, 42);
            this.btnMyAccount.TabIndex = 18;
            this.btnMyAccount.Text = "Edit Account";
            this.btnMyAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMyAccount.Textcolor = System.Drawing.Color.White;
            this.btnMyAccount.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.btnMyAccount.Click += new System.EventHandler(this.btnMyAccount_Click);
            // 
            // BtnSales
            // 
            this.BtnSales.Activecolor = System.Drawing.Color.Teal;
            this.BtnSales.BackColor = System.Drawing.Color.Teal;
            this.BtnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSales.BorderRadius = 0;
            this.BtnSales.ButtonText = "     Sales";
            this.BtnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.BtnSales, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.BtnSales, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.BtnSales, BunifuAnimatorNS.DecorationType.None);
            this.BtnSales.DisabledColor = System.Drawing.Color.DimGray;
            this.BtnSales.ForeColor = System.Drawing.Color.White;
            this.BtnSales.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnSales.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_calculate_white_48;
            this.BtnSales.Iconimage_right = null;
            this.BtnSales.Iconimage_right_Selected = null;
            this.BtnSales.Iconimage_Selected = null;
            this.BtnSales.IconMarginLeft = 0;
            this.BtnSales.IconMarginRight = 0;
            this.BtnSales.IconRightVisible = true;
            this.BtnSales.IconRightZoom = 0D;
            this.BtnSales.IconVisible = true;
            this.BtnSales.IconZoom = 58D;
            this.BtnSales.IsTab = true;
            this.BtnSales.Location = new System.Drawing.Point(3, 399);
            this.BtnSales.Name = "BtnSales";
            this.BtnSales.Normalcolor = System.Drawing.Color.Teal;
            this.BtnSales.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.BtnSales.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnSales.selected = false;
            this.BtnSales.Size = new System.Drawing.Size(259, 66);
            this.BtnSales.TabIndex = 20;
            this.BtnSales.Text = "     Sales";
            this.BtnSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSales.Textcolor = System.Drawing.Color.White;
            this.BtnSales.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.BtnSales.Click += new System.EventHandler(this.BtnSales_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.btnSignOut, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnSignOut, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.btnSignOut, BunifuAnimatorNS.DecorationType.None);
            this.btnSignOut.Image = global::POSWithInventorySystem.Properties.Resources.round_logout_white_48;
            this.btnSignOut.ImageActive = null;
            this.btnSignOut.Location = new System.Drawing.Point(202, 70);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(40, 40);
            this.btnSignOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSignOut.TabIndex = 17;
            this.btnSignOut.TabStop = false;
            this.btnSignOut.Zoom = 10;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // lblUserTypeValue
            // 
            this.lblUserTypeValue.AutoSize = true;
            this.transitionPanel2.SetDecoration(this.lblUserTypeValue, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.lblUserTypeValue, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.lblUserTypeValue, BunifuAnimatorNS.DecorationType.None);
            this.lblUserTypeValue.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblUserTypeValue.ForeColor = System.Drawing.Color.White;
            this.lblUserTypeValue.Location = new System.Drawing.Point(15, 180);
            this.lblUserTypeValue.Name = "lblUserTypeValue";
            this.lblUserTypeValue.Size = new System.Drawing.Size(128, 25);
            this.lblUserTypeValue.TabIndex = 15;
            this.lblUserTypeValue.Text = "labelTypeValue";
            // 
            // lblNameValue
            // 
            this.lblNameValue.AutoSize = true;
            this.transitionPanel2.SetDecoration(this.lblNameValue, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.lblNameValue, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.lblNameValue, BunifuAnimatorNS.DecorationType.None);
            this.lblNameValue.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblNameValue.ForeColor = System.Drawing.Color.White;
            this.lblNameValue.Location = new System.Drawing.Point(14, 151);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(138, 25);
            this.lblNameValue.TabIndex = 13;
            this.lblNameValue.Text = "labelNameValue";
            // 
            // lblTodayAndTime
            // 
            this.lblTodayAndTime.AutoSize = true;
            this.transitionPanel2.SetDecoration(this.lblTodayAndTime, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.lblTodayAndTime, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.lblTodayAndTime, BunifuAnimatorNS.DecorationType.None);
            this.lblTodayAndTime.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTodayAndTime.ForeColor = System.Drawing.Color.White;
            this.lblTodayAndTime.Location = new System.Drawing.Point(12, 712);
            this.lblTodayAndTime.Name = "lblTodayAndTime";
            this.lblTodayAndTime.Size = new System.Drawing.Size(121, 25);
            this.lblTodayAndTime.TabIndex = 11;
            this.lblTodayAndTime.Text = "Day and Time";
            // 
            // lblDateAndTime
            // 
            this.lblDateAndTime.AutoSize = true;
            this.transitionPanel2.SetDecoration(this.lblDateAndTime, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.lblDateAndTime, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.lblDateAndTime, BunifuAnimatorNS.DecorationType.None);
            this.lblDateAndTime.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblDateAndTime.ForeColor = System.Drawing.Color.White;
            this.lblDateAndTime.Location = new System.Drawing.Point(12, 683);
            this.lblDateAndTime.Name = "lblDateAndTime";
            this.lblDateAndTime.Size = new System.Drawing.Size(91, 25);
            this.lblDateAndTime.TabIndex = 11;
            this.lblDateAndTime.Text = "Date Now";
            // 
            // bunifuSeparator6
            // 
            this.bunifuSeparator6.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator6, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator6, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator6, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator6.LineThickness = 1;
            this.bunifuSeparator6.Location = new System.Drawing.Point(1, 673);
            this.bunifuSeparator6.Name = "bunifuSeparator6";
            this.bunifuSeparator6.Size = new System.Drawing.Size(258, 10);
            this.bunifuSeparator6.TabIndex = 10;
            this.bunifuSeparator6.Transparency = 255;
            this.bunifuSeparator6.Vertical = false;
            // 
            // btnUsers
            // 
            this.btnUsers.Activecolor = System.Drawing.Color.Teal;
            this.btnUsers.BackColor = System.Drawing.Color.Teal;
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsers.BorderRadius = 0;
            this.btnUsers.ButtonText = "     Users";
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnUsers, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnUsers, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnUsers, BunifuAnimatorNS.DecorationType.None);
            this.btnUsers.DisabledColor = System.Drawing.Color.DimGray;
            this.btnUsers.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUsers.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_manage_accounts_white_48;
            this.btnUsers.Iconimage_right = null;
            this.btnUsers.Iconimage_right_Selected = null;
            this.btnUsers.Iconimage_Selected = null;
            this.btnUsers.IconMarginLeft = 0;
            this.btnUsers.IconMarginRight = 0;
            this.btnUsers.IconRightVisible = true;
            this.btnUsers.IconRightZoom = 0D;
            this.btnUsers.IconVisible = true;
            this.btnUsers.IconZoom = 58D;
            this.btnUsers.IsTab = true;
            this.btnUsers.Location = new System.Drawing.Point(3, 537);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Normalcolor = System.Drawing.Color.Teal;
            this.btnUsers.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUsers.selected = false;
            this.btnUsers.Size = new System.Drawing.Size(259, 66);
            this.btnUsers.TabIndex = 9;
            this.btnUsers.Text = "     Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Textcolor = System.Drawing.Color.White;
            this.btnUsers.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // bunifuSeparator5
            // 
            this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator5, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator5, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator5.LineThickness = 1;
            this.bunifuSeparator5.Location = new System.Drawing.Point(0, 529);
            this.bunifuSeparator5.Name = "bunifuSeparator5";
            this.bunifuSeparator5.Size = new System.Drawing.Size(262, 10);
            this.bunifuSeparator5.TabIndex = 8;
            this.bunifuSeparator5.Transparency = 255;
            this.bunifuSeparator5.Vertical = false;
            // 
            // btnHistoryLog
            // 
            this.btnHistoryLog.Activecolor = System.Drawing.Color.Teal;
            this.btnHistoryLog.BackColor = System.Drawing.Color.Teal;
            this.btnHistoryLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistoryLog.BorderRadius = 0;
            this.btnHistoryLog.ButtonText = "     History ";
            this.btnHistoryLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnHistoryLog, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnHistoryLog, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnHistoryLog, BunifuAnimatorNS.DecorationType.None);
            this.btnHistoryLog.DisabledColor = System.Drawing.Color.DimGray;
            this.btnHistoryLog.ForeColor = System.Drawing.Color.White;
            this.btnHistoryLog.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHistoryLog.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_manage_search_white_48;
            this.btnHistoryLog.Iconimage_right = null;
            this.btnHistoryLog.Iconimage_right_Selected = null;
            this.btnHistoryLog.Iconimage_Selected = null;
            this.btnHistoryLog.IconMarginLeft = 0;
            this.btnHistoryLog.IconMarginRight = 0;
            this.btnHistoryLog.IconRightVisible = true;
            this.btnHistoryLog.IconRightZoom = 0D;
            this.btnHistoryLog.IconVisible = true;
            this.btnHistoryLog.IconZoom = 58D;
            this.btnHistoryLog.IsTab = true;
            this.btnHistoryLog.Location = new System.Drawing.Point(3, 468);
            this.btnHistoryLog.Name = "btnHistoryLog";
            this.btnHistoryLog.Normalcolor = System.Drawing.Color.Teal;
            this.btnHistoryLog.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnHistoryLog.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHistoryLog.selected = false;
            this.btnHistoryLog.Size = new System.Drawing.Size(259, 66);
            this.btnHistoryLog.TabIndex = 7;
            this.btnHistoryLog.Text = "     History ";
            this.btnHistoryLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoryLog.Textcolor = System.Drawing.Color.White;
            this.btnHistoryLog.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnHistoryLog.Click += new System.EventHandler(this.btnHistoryLog_Click);
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator3, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator3, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator3.LineThickness = 1;
            this.bunifuSeparator3.Location = new System.Drawing.Point(0, 392);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Size = new System.Drawing.Size(262, 10);
            this.bunifuSeparator3.TabIndex = 6;
            this.bunifuSeparator3.Transparency = 255;
            this.bunifuSeparator3.Vertical = false;
            // 
            // btnStocks
            // 
            this.btnStocks.Activecolor = System.Drawing.Color.Teal;
            this.btnStocks.BackColor = System.Drawing.Color.Teal;
            this.btnStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStocks.BorderRadius = 0;
            this.btnStocks.ButtonText = "     Inventory";
            this.btnStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnStocks, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnStocks, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnStocks, BunifuAnimatorNS.DecorationType.None);
            this.btnStocks.DisabledColor = System.Drawing.Color.DimGray;
            this.btnStocks.ForeColor = System.Drawing.Color.White;
            this.btnStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStocks.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_inventory_white_48;
            this.btnStocks.Iconimage_right = null;
            this.btnStocks.Iconimage_right_Selected = null;
            this.btnStocks.Iconimage_Selected = null;
            this.btnStocks.IconMarginLeft = 0;
            this.btnStocks.IconMarginRight = 0;
            this.btnStocks.IconRightVisible = true;
            this.btnStocks.IconRightZoom = 0D;
            this.btnStocks.IconVisible = true;
            this.btnStocks.IconZoom = 58D;
            this.btnStocks.IsTab = true;
            this.btnStocks.Location = new System.Drawing.Point(3, 331);
            this.btnStocks.Name = "btnStocks";
            this.btnStocks.Normalcolor = System.Drawing.Color.Teal;
            this.btnStocks.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnStocks.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStocks.selected = false;
            this.btnStocks.Size = new System.Drawing.Size(259, 66);
            this.btnStocks.TabIndex = 5;
            this.btnStocks.Text = "     Inventory";
            this.btnStocks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStocks.Textcolor = System.Drawing.Color.White;
            this.btnStocks.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnStocks.Click += new System.EventHandler(this.btnStocks_Click);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 324);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(262, 10);
            this.bunifuSeparator2.TabIndex = 4;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.White;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(3, 256);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(259, 10);
            this.bunifuSeparator1.TabIndex = 4;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Activecolor = System.Drawing.Color.Teal;
            this.btnTransaction.BackColor = System.Drawing.Color.Teal;
            this.btnTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTransaction.BorderRadius = 0;
            this.btnTransaction.ButtonText = "     POS";
            this.btnTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionPanel2.SetDecoration(this.btnTransaction, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnTransaction, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.btnTransaction, BunifuAnimatorNS.DecorationType.None);
            this.btnTransaction.DisabledColor = System.Drawing.Color.DimGray;
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTransaction.Iconimage = global::POSWithInventorySystem.Properties.Resources.round_point_of_sale_white_48;
            this.btnTransaction.Iconimage_right = null;
            this.btnTransaction.Iconimage_right_Selected = null;
            this.btnTransaction.Iconimage_Selected = null;
            this.btnTransaction.IconMarginLeft = 0;
            this.btnTransaction.IconMarginRight = 0;
            this.btnTransaction.IconRightVisible = true;
            this.btnTransaction.IconRightZoom = 0D;
            this.btnTransaction.IconVisible = true;
            this.btnTransaction.IconZoom = 58D;
            this.btnTransaction.IsTab = true;
            this.btnTransaction.Location = new System.Drawing.Point(3, 263);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Normalcolor = System.Drawing.Color.Teal;
            this.btnTransaction.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnTransaction.OnHoverTextColor = System.Drawing.Color.White;
            this.btnTransaction.selected = false;
            this.btnTransaction.Size = new System.Drawing.Size(259, 66);
            this.btnTransaction.TabIndex = 2;
            this.btnTransaction.Text = "     POS";
            this.btnTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Textcolor = System.Drawing.Color.White;
            this.btnTransaction.TextFont = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.btnMenu.Image = global::POSWithInventorySystem.Properties.Resources.round_menu_white_48;
            this.btnMenu.ImageActive = null;
            this.btnMenu.Location = new System.Drawing.Point(202, 15);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(40, 40);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 1;
            this.btnMenu.TabStop = false;
            this.btnMenu.Zoom = 10;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBoxUsers
            // 
            this.transitionPanel2.SetDecoration(this.pictureBoxUsers, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.pictureBoxUsers, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.pictureBoxUsers, BunifuAnimatorNS.DecorationType.None);
            this.pictureBoxUsers.Image = global::POSWithInventorySystem.Properties.Resources.placeholder;
            this.pictureBoxUsers.Location = new System.Drawing.Point(19, 15);
            this.pictureBoxUsers.Name = "pictureBoxUsers";
            this.pictureBoxUsers.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUsers.TabIndex = 0;
            this.pictureBoxUsers.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblPOSInventory);
            this.transitionPanel.SetDecoration(this.panelHeader, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.panelHeader, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.panelHeader, BunifuAnimatorNS.DecorationType.None);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1386, 43);
            this.panelHeader.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.btnMinimize.Image = global::POSWithInventorySystem.Properties.Resources.round_minimize_white_48;
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(1304, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.transitionPanel.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.Image = global::POSWithInventorySystem.Properties.Resources.round_close_white_48;
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1341, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPOSInventory
            // 
            this.lblPOSInventory.AutoSize = true;
            this.transitionPanel2.SetDecoration(this.lblPOSInventory, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.lblPOSInventory, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this.lblPOSInventory, BunifuAnimatorNS.DecorationType.None);
            this.lblPOSInventory.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblPOSInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPOSInventory.Location = new System.Drawing.Point(9, 5);
            this.lblPOSInventory.Name = "lblPOSInventory";
            this.lblPOSInventory.Size = new System.Drawing.Size(359, 30);
            this.lblPOSInventory.TabIndex = 0;
            this.lblPOSInventory.Text = "DMN Programming Inventory System";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelHeader;
            this.bunifuDragControl1.Vertical = true;
            // 
            // transitionPanel
            // 
            this.transitionPanel.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic;
            this.transitionPanel.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 20;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.transitionPanel.DefaultAnimation = animation1;
            // 
            // panelMenusForm
            // 
            this.panelMenusForm.BackColor = System.Drawing.Color.White;
            this.transitionPanel.SetDecoration(this.panelMenusForm, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this.panelMenusForm, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel2.SetDecoration(this.panelMenusForm, BunifuAnimatorNS.DecorationType.None);
            this.panelMenusForm.Location = new System.Drawing.Point(262, 43);
            this.panelMenusForm.Name = "panelMenusForm";
            this.panelMenusForm.Size = new System.Drawing.Size(1124, 745);
            this.panelMenusForm.TabIndex = 2;
            // 
            // transitionLogo
            // 
            this.transitionLogo.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.transitionLogo.Cursor = null;
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
            animation2.TransparencyCoeff = 0F;
            this.transitionLogo.DefaultAnimation = animation2;
            // 
            // transitionPanel2
            // 
            this.transitionPanel2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.transitionPanel2.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.transitionPanel2.DefaultAnimation = animation3;
            // 
            // timerDateNTime
            // 
            this.timerDateNTime.Tick += new System.EventHandler(this.timerDateNTime_Tick);
            // 
            // timerFormLoad
            // 
            this.timerFormLoad.Tick += new System.EventHandler(this.timerFormLoad_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panelMenusForm);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelHeader);
            this.transitionPanel2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transitionPanel.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transitionLogo.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "x`";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSignOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsers)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxUsers;
        private Bunifu.Framework.UI.BunifuImageButton btnMenu;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPOSInventory;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton btnTransaction;
        private BunifuAnimatorNS.BunifuTransition transitionPanel;
        private BunifuAnimatorNS.BunifuTransition transitionLogo;
        private BunifuAnimatorNS.BunifuTransition transitionPanel2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator4;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator5;
        private Bunifu.Framework.UI.BunifuFlatButton btnHistoryLog;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator3;
        private Bunifu.Framework.UI.BunifuFlatButton btnStocks;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator6;
        private Bunifu.Framework.UI.BunifuFlatButton btnUsers;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDateAndTime;
        private System.Windows.Forms.Timer timerDateNTime;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTodayAndTime;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblUserTypeValue;
        private System.Windows.Forms.Timer timerFormLoad;
        private Bunifu.Framework.UI.BunifuImageButton btnSignOut;
        private System.Windows.Forms.Panel panelMenusForm;
        private Bunifu.Framework.UI.BunifuFlatButton btnMyAccount;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator7;
        private Bunifu.Framework.UI.BunifuFlatButton BtnSales;
        private Bunifu.Framework.UI.BunifuFlatButton btnBackup;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator8;
    }
}