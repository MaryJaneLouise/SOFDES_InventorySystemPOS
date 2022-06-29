namespace POSWithInventorySystem
{
    partial class POSForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlRegister = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewNotActiveUsers = new System.Windows.Forms.DataGridView();
            this.bunifuSwitchActivateUsers = new Bunifu.Framework.UI.BunifuSwitch();
            this.bunifuSwitchbtnDeactivateUsers = new Bunifu.Framework.UI.BunifuSwitch();
            this.btnActivateUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblNumberOfUsersValue = new System.Windows.Forms.Label();
            this.btnDeactivateUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSearchByUsers = new System.Windows.Forms.Label();
            this.lblNumberOfUsers = new System.Windows.Forms.Label();
            this.btnUpdateUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.comboBoxActiveOrNotUsers = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.bunifuSwitch = new Bunifu.Framework.UI.BunifuSwitch();
            this.btnDeleteUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.lblPasswordNotMatch = new System.Windows.Forms.Label();
            this.lblPasswordConfirmError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblErrorUsername = new System.Windows.Forms.Label();
            this.btnCreate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBrowseImage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBoxUserPic = new System.Windows.Forms.PictureBox();
            this.txtConfirmPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.groupBoxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.lblBirthdayError = new System.Windows.Forms.Label();
            this.lblContactError = new System.Windows.Forms.Label();
            this.lblAddressError = new System.Windows.Forms.Label();
            this.lblLastNameError = new System.Windows.Forms.Label();
            this.lblFirstNameError = new System.Windows.Forms.Label();
            this.txtContact = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtlAddress = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.DatepickerlBirthDay = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txtMiddleName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAge = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtFirstName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblBirthDay = new System.Windows.Forms.Label();
            this.lblMiddlleName = new System.Windows.Forms.Label();
            this.txtLastName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControlRegister.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotActiveUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPic)).BeginInit();
            this.groupBoxPersonalInfo.SuspendLayout();
            this.groupBoxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlRegister
            // 
            this.tabControlRegister.Controls.Add(this.tabPage1);
            this.tabControlRegister.Controls.Add(this.tabPage2);
            this.tabControlRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlRegister.Location = new System.Drawing.Point(21, 12);
            this.tabControlRegister.Name = "tabControlRegister";
            this.tabControlRegister.SelectedIndex = 0;
            this.tabControlRegister.Size = new System.Drawing.Size(1064, 682);
            this.tabControlRegister.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dataGridViewNotActiveUsers);
            this.tabPage1.Controls.Add(this.bunifuSwitchActivateUsers);
            this.tabPage1.Controls.Add(this.bunifuSwitchbtnDeactivateUsers);
            this.tabPage1.Controls.Add(this.btnActivateUsers);
            this.tabPage1.Controls.Add(this.lblNumberOfUsersValue);
            this.tabPage1.Controls.Add(this.btnDeactivateUsers);
            this.tabPage1.Controls.Add(this.btnSearchByUsers);
            this.tabPage1.Controls.Add(this.lblNumberOfUsers);
            this.tabPage1.Controls.Add(this.btnUpdateUsers);
            this.tabPage1.Controls.Add(this.comboBoxActiveOrNotUsers);
            this.tabPage1.Controls.Add(this.txtSearchValue);
            this.tabPage1.Controls.Add(this.lblSearch);
            this.tabPage1.Controls.Add(this.bunifuSwitch);
            this.tabPage1.Controls.Add(this.btnDeleteUsers);
            this.tabPage1.Controls.Add(this.dataGridViewUsers);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1056, 644);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users\' Information Table";
            // 
            // dataGridViewNotActiveUsers
            // 
            this.dataGridViewNotActiveUsers.AllowUserToAddRows = false;
            this.dataGridViewNotActiveUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewNotActiveUsers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNotActiveUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewNotActiveUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNotActiveUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewNotActiveUsers.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewNotActiveUsers.Location = new System.Drawing.Point(26, 100);
            this.dataGridViewNotActiveUsers.MultiSelect = false;
            this.dataGridViewNotActiveUsers.Name = "dataGridViewNotActiveUsers";
            this.dataGridViewNotActiveUsers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNotActiveUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewNotActiveUsers.RowHeadersVisible = false;
            this.dataGridViewNotActiveUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNotActiveUsers.Size = new System.Drawing.Size(1003, 430);
            this.dataGridViewNotActiveUsers.TabIndex = 65;
            this.dataGridViewNotActiveUsers.DoubleClick += new System.EventHandler(this.dataGridViewNotActiveUsers_DoubleClick);
            // 
            // bunifuSwitchActivateUsers
            // 
            this.bunifuSwitchActivateUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchActivateUsers.BorderRadius = 0;
            this.bunifuSwitchActivateUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchActivateUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchActivateUsers.Location = new System.Drawing.Point(26, 614);
            this.bunifuSwitchActivateUsers.Margin = new System.Windows.Forms.Padding(37, 34, 37, 34);
            this.bunifuSwitchActivateUsers.Name = "bunifuSwitchActivateUsers";
            this.bunifuSwitchActivateUsers.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchActivateUsers.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchActivateUsers.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchActivateUsers.TabIndex = 64;
            this.bunifuSwitchActivateUsers.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchActivateUsers.Value = false;
            this.bunifuSwitchActivateUsers.Click += new System.EventHandler(this.bunifuSwitchActivateUsers_Click);
            // 
            // bunifuSwitchbtnDeactivateUsers
            // 
            this.bunifuSwitchbtnDeactivateUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchbtnDeactivateUsers.BorderRadius = 0;
            this.bunifuSwitchbtnDeactivateUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchbtnDeactivateUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchbtnDeactivateUsers.Location = new System.Drawing.Point(978, 614);
            this.bunifuSwitchbtnDeactivateUsers.Margin = new System.Windows.Forms.Padding(22, 21, 22, 21);
            this.bunifuSwitchbtnDeactivateUsers.Name = "bunifuSwitchbtnDeactivateUsers";
            this.bunifuSwitchbtnDeactivateUsers.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchbtnDeactivateUsers.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchbtnDeactivateUsers.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchbtnDeactivateUsers.TabIndex = 62;
            this.bunifuSwitchbtnDeactivateUsers.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchbtnDeactivateUsers.Value = false;
            this.bunifuSwitchbtnDeactivateUsers.Click += new System.EventHandler(this.bunifuSwitchbtnDeactivateUsers_Click);
            // 
            // btnActivateUsers
            // 
            this.btnActivateUsers.Activecolor = System.Drawing.Color.Silver;
            this.btnActivateUsers.BackColor = System.Drawing.Color.Silver;
            this.btnActivateUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActivateUsers.BorderRadius = 0;
            this.btnActivateUsers.ButtonText = "Activate";
            this.btnActivateUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivateUsers.DisabledColor = System.Drawing.Color.Gray;
            this.btnActivateUsers.Enabled = false;
            this.btnActivateUsers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivateUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnActivateUsers.Iconimage = null;
            this.btnActivateUsers.Iconimage_right = null;
            this.btnActivateUsers.Iconimage_right_Selected = null;
            this.btnActivateUsers.Iconimage_Selected = null;
            this.btnActivateUsers.IconMarginLeft = 0;
            this.btnActivateUsers.IconMarginRight = 0;
            this.btnActivateUsers.IconRightVisible = false;
            this.btnActivateUsers.IconRightZoom = 0D;
            this.btnActivateUsers.IconVisible = false;
            this.btnActivateUsers.IconZoom = 90D;
            this.btnActivateUsers.IsTab = false;
            this.btnActivateUsers.Location = new System.Drawing.Point(26, 565);
            this.btnActivateUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnActivateUsers.Name = "btnActivateUsers";
            this.btnActivateUsers.Normalcolor = System.Drawing.Color.Silver;
            this.btnActivateUsers.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnActivateUsers.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnActivateUsers.selected = false;
            this.btnActivateUsers.Size = new System.Drawing.Size(487, 48);
            this.btnActivateUsers.TabIndex = 63;
            this.btnActivateUsers.Text = "Activate";
            this.btnActivateUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActivateUsers.Textcolor = System.Drawing.Color.Black;
            this.btnActivateUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnActivateUsers.Click += new System.EventHandler(this.btnActivateUsers_Click);
            // 
            // lblNumberOfUsersValue
            // 
            this.lblNumberOfUsersValue.AutoSize = true;
            this.lblNumberOfUsersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNumberOfUsersValue.Location = new System.Drawing.Point(177, 539);
            this.lblNumberOfUsersValue.Name = "lblNumberOfUsersValue";
            this.lblNumberOfUsersValue.Size = new System.Drawing.Size(23, 25);
            this.lblNumberOfUsersValue.TabIndex = 50;
            this.lblNumberOfUsersValue.Text = "0\r\n";
            // 
            // btnDeactivateUsers
            // 
            this.btnDeactivateUsers.Activecolor = System.Drawing.Color.Silver;
            this.btnDeactivateUsers.BackColor = System.Drawing.Color.Silver;
            this.btnDeactivateUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeactivateUsers.BorderRadius = 0;
            this.btnDeactivateUsers.ButtonText = "Deactivate";
            this.btnDeactivateUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeactivateUsers.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeactivateUsers.Enabled = false;
            this.btnDeactivateUsers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivateUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeactivateUsers.Iconimage = null;
            this.btnDeactivateUsers.Iconimage_right = null;
            this.btnDeactivateUsers.Iconimage_right_Selected = null;
            this.btnDeactivateUsers.Iconimage_Selected = null;
            this.btnDeactivateUsers.IconMarginLeft = 0;
            this.btnDeactivateUsers.IconMarginRight = 0;
            this.btnDeactivateUsers.IconRightVisible = false;
            this.btnDeactivateUsers.IconRightZoom = 0D;
            this.btnDeactivateUsers.IconVisible = false;
            this.btnDeactivateUsers.IconZoom = 90D;
            this.btnDeactivateUsers.IsTab = false;
            this.btnDeactivateUsers.Location = new System.Drawing.Point(542, 565);
            this.btnDeactivateUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeactivateUsers.Name = "btnDeactivateUsers";
            this.btnDeactivateUsers.Normalcolor = System.Drawing.Color.Silver;
            this.btnDeactivateUsers.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeactivateUsers.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDeactivateUsers.selected = false;
            this.btnDeactivateUsers.Size = new System.Drawing.Size(487, 48);
            this.btnDeactivateUsers.TabIndex = 61;
            this.btnDeactivateUsers.Text = "Deactivate";
            this.btnDeactivateUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeactivateUsers.Textcolor = System.Drawing.Color.Black;
            this.btnDeactivateUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnDeactivateUsers.Click += new System.EventHandler(this.btnDeactivateUsers_Click);
            // 
            // btnSearchByUsers
            // 
            this.btnSearchByUsers.AutoSize = true;
            this.btnSearchByUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnSearchByUsers.Location = new System.Drawing.Point(555, 20);
            this.btnSearchByUsers.Name = "btnSearchByUsers";
            this.btnSearchByUsers.Size = new System.Drawing.Size(107, 25);
            this.btnSearchByUsers.TabIndex = 43;
            this.btnSearchByUsers.Text = "Search by:";
            // 
            // lblNumberOfUsers
            // 
            this.lblNumberOfUsers.AutoSize = true;
            this.lblNumberOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNumberOfUsers.Location = new System.Drawing.Point(21, 538);
            this.lblNumberOfUsers.Name = "lblNumberOfUsers";
            this.lblNumberOfUsers.Size = new System.Drawing.Size(160, 25);
            this.lblNumberOfUsers.TabIndex = 49;
            this.lblNumberOfUsers.Text = "Number of Items:";
            // 
            // btnUpdateUsers
            // 
            this.btnUpdateUsers.Activecolor = System.Drawing.Color.Teal;
            this.btnUpdateUsers.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateUsers.BorderRadius = 0;
            this.btnUpdateUsers.ButtonText = "Update";
            this.btnUpdateUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateUsers.DisabledColor = System.Drawing.Color.Gray;
            this.btnUpdateUsers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUpdateUsers.Iconimage = null;
            this.btnUpdateUsers.Iconimage_right = null;
            this.btnUpdateUsers.Iconimage_right_Selected = null;
            this.btnUpdateUsers.Iconimage_Selected = null;
            this.btnUpdateUsers.IconMarginLeft = 0;
            this.btnUpdateUsers.IconMarginRight = 0;
            this.btnUpdateUsers.IconRightVisible = false;
            this.btnUpdateUsers.IconRightZoom = 0D;
            this.btnUpdateUsers.IconVisible = false;
            this.btnUpdateUsers.IconZoom = 90D;
            this.btnUpdateUsers.IsTab = false;
            this.btnUpdateUsers.Location = new System.Drawing.Point(26, 565);
            this.btnUpdateUsers.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUpdateUsers.Name = "btnUpdateUsers";
            this.btnUpdateUsers.Normalcolor = System.Drawing.Color.Teal;
            this.btnUpdateUsers.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnUpdateUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUpdateUsers.selected = false;
            this.btnUpdateUsers.Size = new System.Drawing.Size(487, 48);
            this.btnUpdateUsers.TabIndex = 42;
            this.btnUpdateUsers.Text = "Update";
            this.btnUpdateUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateUsers.Textcolor = System.Drawing.Color.White;
            this.btnUpdateUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUpdateUsers.Click += new System.EventHandler(this.btnUpdateUsers_Click);
            // 
            // comboBoxActiveOrNotUsers
            // 
            this.comboBoxActiveOrNotUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActiveOrNotUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxActiveOrNotUsers.FormattingEnabled = true;
            this.comboBoxActiveOrNotUsers.Items.AddRange(new object[] {
            "Active ",
            "Not Active "});
            this.comboBoxActiveOrNotUsers.Location = new System.Drawing.Point(560, 48);
            this.comboBoxActiveOrNotUsers.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxActiveOrNotUsers.Name = "comboBoxActiveOrNotUsers";
            this.comboBoxActiveOrNotUsers.Size = new System.Drawing.Size(469, 33);
            this.comboBoxActiveOrNotUsers.TabIndex = 15;
            this.comboBoxActiveOrNotUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxActiveOrNotUsers_SelectedIndexChanged);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderColorFocused = System.Drawing.Color.Black;
            this.txtSearchValue.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchValue.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtSearchValue.BorderThickness = 2;
            this.txtSearchValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtSearchValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchValue.isPassword = false;
            this.txtSearchValue.Location = new System.Drawing.Point(26, 47);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(469, 34);
            this.txtSearchValue.TabIndex = 33;
            this.txtSearchValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchValue.OnValueChanged += new System.EventHandler(this.txtSearchValue_OnValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSearch.Location = new System.Drawing.Point(21, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 25);
            this.lblSearch.TabIndex = 32;
            this.lblSearch.Text = "Search";
            // 
            // bunifuSwitch
            // 
            this.bunifuSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitch.BorderRadius = 0;
            this.bunifuSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch.Location = new System.Drawing.Point(978, 614);
            this.bunifuSwitch.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuSwitch.Name = "bunifuSwitch";
            this.bunifuSwitch.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitch.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitch.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitch.TabIndex = 4;
            this.bunifuSwitch.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch.Value = false;
            this.bunifuSwitch.Click += new System.EventHandler(this.bunifuSwitch_Click);
            // 
            // btnDeleteUsers
            // 
            this.btnDeleteUsers.Activecolor = System.Drawing.Color.Silver;
            this.btnDeleteUsers.BackColor = System.Drawing.Color.Silver;
            this.btnDeleteUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteUsers.BorderRadius = 0;
            this.btnDeleteUsers.ButtonText = "Delete";
            this.btnDeleteUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUsers.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeleteUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteUsers.Iconimage = null;
            this.btnDeleteUsers.Iconimage_right = null;
            this.btnDeleteUsers.Iconimage_right_Selected = null;
            this.btnDeleteUsers.Iconimage_Selected = null;
            this.btnDeleteUsers.IconMarginLeft = 0;
            this.btnDeleteUsers.IconMarginRight = 0;
            this.btnDeleteUsers.IconRightVisible = false;
            this.btnDeleteUsers.IconRightZoom = 0D;
            this.btnDeleteUsers.IconVisible = false;
            this.btnDeleteUsers.IconZoom = 90D;
            this.btnDeleteUsers.IsTab = false;
            this.btnDeleteUsers.Location = new System.Drawing.Point(542, 565);
            this.btnDeleteUsers.Margin = new System.Windows.Forms.Padding(8);
            this.btnDeleteUsers.Name = "btnDeleteUsers";
            this.btnDeleteUsers.Normalcolor = System.Drawing.Color.Silver;
            this.btnDeleteUsers.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteUsers.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDeleteUsers.selected = false;
            this.btnDeleteUsers.Size = new System.Drawing.Size(487, 48);
            this.btnDeleteUsers.TabIndex = 3;
            this.btnDeleteUsers.Text = "Delete";
            this.btnDeleteUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteUsers.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUsers.Click += new System.EventHandler(this.btnDeleteUsers_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewUsers.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewUsers.Location = new System.Drawing.Point(26, 100);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1003, 430);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUsers_ColumnHeaderMouseClick);
            this.dataGridViewUsers.DoubleClick += new System.EventHandler(this.dataGridViewUsers_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBoxUserType);
            this.tabPage2.Controls.Add(this.lblPasswordNotMatch);
            this.tabPage2.Controls.Add(this.lblPasswordConfirmError);
            this.tabPage2.Controls.Add(this.lblPasswordError);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.lblErrorUsername);
            this.tabPage2.Controls.Add(this.btnCreate);
            this.tabPage2.Controls.Add(this.btnBrowseImage);
            this.tabPage2.Controls.Add(this.pictureBoxUserPic);
            this.tabPage2.Controls.Add(this.txtConfirmPassword);
            this.tabPage2.Controls.Add(this.lblConfirmPassword);
            this.tabPage2.Controls.Add(this.lblPassword);
            this.tabPage2.Controls.Add(this.txtUsername);
            this.tabPage2.Controls.Add(this.lblUsername);
            this.tabPage2.Controls.Add(this.groupBoxPersonalInfo);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1056, 644);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Register New User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(183, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Account Type";
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "Employee",
            "Admin"});
            this.comboBoxUserType.Location = new System.Drawing.Point(187, 178);
            this.comboBoxUserType.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(848, 28);
            this.comboBoxUserType.TabIndex = 27;
            // 
            // lblPasswordNotMatch
            // 
            this.lblPasswordNotMatch.AutoSize = true;
            this.lblPasswordNotMatch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordNotMatch.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordNotMatch.Location = new System.Drawing.Point(976, 111);
            this.lblPasswordNotMatch.Name = "lblPasswordNotMatch";
            this.lblPasswordNotMatch.Size = new System.Drawing.Size(25, 19);
            this.lblPasswordNotMatch.TabIndex = 26;
            this.lblPasswordNotMatch.Text = "❌";
            // 
            // lblPasswordConfirmError
            // 
            this.lblPasswordConfirmError.AutoSize = true;
            this.lblPasswordConfirmError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordConfirmError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordConfirmError.Location = new System.Drawing.Point(1005, 111);
            this.lblPasswordConfirmError.Name = "lblPasswordConfirmError";
            this.lblPasswordConfirmError.Size = new System.Drawing.Size(25, 19);
            this.lblPasswordConfirmError.TabIndex = 25;
            this.lblPasswordConfirmError.Text = "❌";
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(545, 111);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(25, 19);
            this.lblPasswordError.TabIndex = 24;
            this.lblPasswordError.Text = "❌";
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.Silver;
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = null;
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = false;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = false;
            this.btnCancel.IconZoom = 90D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(549, 574);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(486, 48);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.Black;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblErrorUsername
            // 
            this.lblErrorUsername.AutoSize = true;
            this.lblErrorUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsername.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsername.Location = new System.Drawing.Point(1005, 47);
            this.lblErrorUsername.Name = "lblErrorUsername";
            this.lblErrorUsername.Size = new System.Drawing.Size(25, 19);
            this.lblErrorUsername.TabIndex = 23;
            this.lblErrorUsername.Text = "❌";
            // 
            // btnCreate
            // 
            this.btnCreate.Activecolor = System.Drawing.Color.Teal;
            this.btnCreate.BackColor = System.Drawing.Color.Teal;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.BorderRadius = 0;
            this.btnCreate.ButtonText = "Create User Account";
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.DisabledColor = System.Drawing.Color.Gray;
            this.btnCreate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCreate.Iconimage = null;
            this.btnCreate.Iconimage_right = null;
            this.btnCreate.Iconimage_right_Selected = null;
            this.btnCreate.Iconimage_Selected = null;
            this.btnCreate.IconMarginLeft = 0;
            this.btnCreate.IconMarginRight = 0;
            this.btnCreate.IconRightVisible = false;
            this.btnCreate.IconRightZoom = 0D;
            this.btnCreate.IconVisible = false;
            this.btnCreate.IconZoom = 90D;
            this.btnCreate.IsTab = false;
            this.btnCreate.Location = new System.Drawing.Point(19, 574);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Normalcolor = System.Drawing.Color.Teal;
            this.btnCreate.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnCreate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCreate.selected = false;
            this.btnCreate.Size = new System.Drawing.Size(486, 48);
            this.btnCreate.TabIndex = 25;
            this.btnCreate.Text = "Create User Account";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCreate.Textcolor = System.Drawing.Color.White;
            this.btnCreate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Activecolor = System.Drawing.Color.Teal;
            this.btnBrowseImage.BackColor = System.Drawing.Color.Teal;
            this.btnBrowseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseImage.BorderRadius = 7;
            this.btnBrowseImage.ButtonText = "Browse Image";
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.DisabledColor = System.Drawing.Color.Gray;
            this.btnBrowseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnBrowseImage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBrowseImage.Iconimage = null;
            this.btnBrowseImage.Iconimage_right = null;
            this.btnBrowseImage.Iconimage_right_Selected = null;
            this.btnBrowseImage.Iconimage_Selected = null;
            this.btnBrowseImage.IconMarginLeft = 0;
            this.btnBrowseImage.IconMarginRight = 0;
            this.btnBrowseImage.IconRightVisible = false;
            this.btnBrowseImage.IconRightZoom = 0D;
            this.btnBrowseImage.IconVisible = false;
            this.btnBrowseImage.IconZoom = 90D;
            this.btnBrowseImage.IsTab = false;
            this.btnBrowseImage.Location = new System.Drawing.Point(19, 148);
            this.btnBrowseImage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Normalcolor = System.Drawing.Color.Teal;
            this.btnBrowseImage.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnBrowseImage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBrowseImage.selected = false;
            this.btnBrowseImage.Size = new System.Drawing.Size(140, 38);
            this.btnBrowseImage.TabIndex = 22;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowseImage.Textcolor = System.Drawing.Color.White;
            this.btnBrowseImage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            // 
            // pictureBoxUserPic
            // 
            this.pictureBoxUserPic.Image = global::POSWithInventorySystem.Properties.Resources.round_person_black_48;
            this.pictureBoxUserPic.Location = new System.Drawing.Point(26, 15);
            this.pictureBoxUserPic.Name = "pictureBoxUserPic";
            this.pictureBoxUserPic.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxUserPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserPic.TabIndex = 21;
            this.pictureBoxUserPic.TabStop = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderColorFocused = System.Drawing.Color.Black;
            this.txtConfirmPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtConfirmPassword.BorderThickness = 2;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.isPassword = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(648, 105);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(387, 31);
            this.txtConfirmPassword.TabIndex = 18;
            this.txtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(643, 79);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(156, 22);
            this.lblConfirmPassword.TabIndex = 20;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblPassword.Location = new System.Drawing.Point(183, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 22);
            this.lblPassword.TabIndex = 19;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderColorFocused = System.Drawing.Color.Black;
            this.txtUsername.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.isPassword = false;
            this.txtUsername.Location = new System.Drawing.Point(187, 41);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(848, 31);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblUsername.Location = new System.Drawing.Point(183, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(92, 22);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "Username";
            // 
            // groupBoxPersonalInfo
            // 
            this.groupBoxPersonalInfo.BackColor = System.Drawing.Color.White;
            this.groupBoxPersonalInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxPersonalInfo.Controls.Add(this.groupBoxGender);
            this.groupBoxPersonalInfo.Controls.Add(this.lblBirthdayError);
            this.groupBoxPersonalInfo.Controls.Add(this.lblContactError);
            this.groupBoxPersonalInfo.Controls.Add(this.lblAddressError);
            this.groupBoxPersonalInfo.Controls.Add(this.lblLastNameError);
            this.groupBoxPersonalInfo.Controls.Add(this.lblFirstNameError);
            this.groupBoxPersonalInfo.Controls.Add(this.txtContact);
            this.groupBoxPersonalInfo.Controls.Add(this.lblContact);
            this.groupBoxPersonalInfo.Controls.Add(this.txtlAddress);
            this.groupBoxPersonalInfo.Controls.Add(this.DatepickerlBirthDay);
            this.groupBoxPersonalInfo.Controls.Add(this.txtMiddleName);
            this.groupBoxPersonalInfo.Controls.Add(this.lblAddress);
            this.groupBoxPersonalInfo.Controls.Add(this.txtAge);
            this.groupBoxPersonalInfo.Controls.Add(this.lblAge);
            this.groupBoxPersonalInfo.Controls.Add(this.txtFirstName);
            this.groupBoxPersonalInfo.Controls.Add(this.lblBirthDay);
            this.groupBoxPersonalInfo.Controls.Add(this.lblMiddlleName);
            this.groupBoxPersonalInfo.Controls.Add(this.txtLastName);
            this.groupBoxPersonalInfo.Controls.Add(this.lblLastName);
            this.groupBoxPersonalInfo.Controls.Add(this.lblFirstName);
            this.groupBoxPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxPersonalInfo.Location = new System.Drawing.Point(19, 214);
            this.groupBoxPersonalInfo.Name = "groupBoxPersonalInfo";
            this.groupBoxPersonalInfo.Size = new System.Drawing.Size(1016, 342);
            this.groupBoxPersonalInfo.TabIndex = 2;
            this.groupBoxPersonalInfo.TabStop = false;
            this.groupBoxPersonalInfo.Text = "Personal Information";
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Controls.Add(this.radioButtonMale);
            this.groupBoxGender.Controls.Add(this.radioButtonFemale);
            this.groupBoxGender.Location = new System.Drawing.Point(628, 124);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(238, 78);
            this.groupBoxGender.TabIndex = 34;
            this.groupBoxGender.TabStop = false;
            this.groupBoxGender.Text = "Gender";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.radioButtonMale.Location = new System.Drawing.Point(29, 29);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(66, 26);
            this.radioButtonMale.TabIndex = 14;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Checked = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.radioButtonFemale.Location = new System.Drawing.Point(113, 29);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(87, 26);
            this.radioButtonFemale.TabIndex = 15;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // lblBirthdayError
            // 
            this.lblBirthdayError.AutoSize = true;
            this.lblBirthdayError.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthdayError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdayError.ForeColor = System.Drawing.Color.Red;
            this.lblBirthdayError.Location = new System.Drawing.Point(708, 271);
            this.lblBirthdayError.Name = "lblBirthdayError";
            this.lblBirthdayError.Size = new System.Drawing.Size(25, 19);
            this.lblBirthdayError.TabIndex = 33;
            this.lblBirthdayError.Text = "❌";
            // 
            // lblContactError
            // 
            this.lblContactError.AutoSize = true;
            this.lblContactError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactError.ForeColor = System.Drawing.Color.Red;
            this.lblContactError.Location = new System.Drawing.Point(388, 270);
            this.lblContactError.Name = "lblContactError";
            this.lblContactError.Size = new System.Drawing.Size(25, 19);
            this.lblContactError.TabIndex = 32;
            this.lblContactError.Text = "❌";
            // 
            // lblAddressError
            // 
            this.lblAddressError.AutoSize = true;
            this.lblAddressError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressError.ForeColor = System.Drawing.Color.Red;
            this.lblAddressError.Location = new System.Drawing.Point(442, 163);
            this.lblAddressError.Name = "lblAddressError";
            this.lblAddressError.Size = new System.Drawing.Size(25, 19);
            this.lblAddressError.TabIndex = 31;
            this.lblAddressError.Text = "❌";
            // 
            // lblLastNameError
            // 
            this.lblLastNameError.AutoSize = true;
            this.lblLastNameError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameError.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameError.Location = new System.Drawing.Point(970, 69);
            this.lblLastNameError.Name = "lblLastNameError";
            this.lblLastNameError.Size = new System.Drawing.Size(25, 19);
            this.lblLastNameError.TabIndex = 29;
            this.lblLastNameError.Text = "❌";
            // 
            // lblFirstNameError
            // 
            this.lblFirstNameError.AutoSize = true;
            this.lblFirstNameError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameError.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameError.Location = new System.Drawing.Point(295, 69);
            this.lblFirstNameError.Name = "lblFirstNameError";
            this.lblFirstNameError.Size = new System.Drawing.Size(25, 19);
            this.lblFirstNameError.TabIndex = 28;
            this.lblFirstNameError.Text = "❌";
            // 
            // txtContact
            // 
            this.txtContact.BorderColorFocused = System.Drawing.Color.Black;
            this.txtContact.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContact.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtContact.BorderThickness = 2;
            this.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContact.isPassword = false;
            this.txtContact.Location = new System.Drawing.Point(20, 265);
            this.txtContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(397, 31);
            this.txtContact.TabIndex = 8;
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContact.Enter += new System.EventHandler(this.txtContact_Enter);
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblContact.Location = new System.Drawing.Point(16, 239);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(260, 22);
            this.lblContact.TabIndex = 22;
            this.lblContact.Text = "Contact Number/Email Address";
            // 
            // txtlAddress
            // 
            this.txtlAddress.BorderColorFocused = System.Drawing.Color.Black;
            this.txtlAddress.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtlAddress.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtlAddress.BorderThickness = 2;
            this.txtlAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtlAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtlAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtlAddress.isPassword = false;
            this.txtlAddress.Location = new System.Drawing.Point(20, 136);
            this.txtlAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtlAddress.Name = "txtlAddress";
            this.txtlAddress.Size = new System.Drawing.Size(452, 72);
            this.txtlAddress.TabIndex = 7;
            this.txtlAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtlAddress.Enter += new System.EventHandler(this.txtlAddress_Enter);
            // 
            // DatepickerlBirthDay
            // 
            this.DatepickerlBirthDay.BackColor = System.Drawing.Color.Silver;
            this.DatepickerlBirthDay.BorderRadius = 0;
            this.DatepickerlBirthDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.DatepickerlBirthDay.ForeColor = System.Drawing.Color.Black;
            this.DatepickerlBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatepickerlBirthDay.FormatCustom = "                                  MM-dd-yyyy";
            this.DatepickerlBirthDay.Location = new System.Drawing.Point(449, 266);
            this.DatepickerlBirthDay.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DatepickerlBirthDay.Name = "DatepickerlBirthDay";
            this.DatepickerlBirthDay.Size = new System.Drawing.Size(324, 31);
            this.DatepickerlBirthDay.TabIndex = 6;
            this.DatepickerlBirthDay.Value = new System.DateTime(2018, 8, 26, 15, 21, 14, 0);
            this.DatepickerlBirthDay.onValueChanged += new System.EventHandler(this.DatepickerlBirthDay_onValueChanged);
            this.DatepickerlBirthDay.Enter += new System.EventHandler(this.DatepickerlBirthDay_Enter);
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderColorFocused = System.Drawing.Color.Black;
            this.txtMiddleName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMiddleName.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtMiddleName.BorderThickness = 2;
            this.txtMiddleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMiddleName.isPassword = false;
            this.txtMiddleName.Location = new System.Drawing.Point(357, 63);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(306, 31);
            this.txtMiddleName.TabIndex = 5;
            this.txtMiddleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMiddleName_KeyPress);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblAddress.Location = new System.Drawing.Point(16, 110);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(76, 22);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Address";
            // 
            // txtAge
            // 
            this.txtAge.BorderColorFocused = System.Drawing.Color.Black;
            this.txtAge.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAge.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtAge.BorderThickness = 2;
            this.txtAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAge.isPassword = false;
            this.txtAge.Location = new System.Drawing.Point(803, 265);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(197, 31);
            this.txtAge.TabIndex = 17;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblAge.Location = new System.Drawing.Point(799, 239);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(47, 22);
            this.lblAge.TabIndex = 16;
            this.lblAge.Text = "Age:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderColorFocused = System.Drawing.Color.Black;
            this.txtFirstName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFirstName.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtFirstName.BorderThickness = 2;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFirstName.isPassword = false;
            this.txtFirstName.Location = new System.Drawing.Point(20, 63);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(306, 31);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFirstName.Enter += new System.EventHandler(this.txtFirstName_Enter);
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.AutoSize = true;
            this.lblBirthDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblBirthDay.Location = new System.Drawing.Point(445, 239);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(110, 22);
            this.lblBirthDay.TabIndex = 13;
            this.lblBirthDay.Text = "Date of Birth";
            // 
            // lblMiddlleName
            // 
            this.lblMiddlleName.AutoSize = true;
            this.lblMiddlleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblMiddlleName.Location = new System.Drawing.Point(353, 37);
            this.lblMiddlleName.Name = "lblMiddlleName";
            this.lblMiddlleName.Size = new System.Drawing.Size(114, 22);
            this.lblMiddlleName.TabIndex = 10;
            this.lblMiddlleName.Text = "Middle Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderColorFocused = System.Drawing.Color.Black;
            this.txtLastName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLastName.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtLastName.BorderThickness = 2;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLastName.isPassword = false;
            this.txtLastName.Location = new System.Drawing.Point(694, 63);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(306, 31);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLastName.Enter += new System.EventHandler(this.txtLastName_Enter);
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyPress);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblLastName.Location = new System.Drawing.Point(690, 37);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(96, 22);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblFirstName.Location = new System.Drawing.Point(16, 37);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(97, 22);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First Name";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColorFocused = System.Drawing.Color.Black;
            this.txtPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.isPassword = true;
            this.txtPassword.Location = new System.Drawing.Point(187, 105);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(387, 31);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 706);
            this.Controls.Add(this.tabControlRegister);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "POSForm";
            this.Text = "UsersForm";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.tabControlRegister.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotActiveUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPic)).EndInit();
            this.groupBoxPersonalInfo.ResumeLayout(false);
            this.groupBoxPersonalInfo.PerformLayout();
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabControlRegister;
        private System.Windows.Forms.GroupBox groupBoxPersonalInfo;
        private System.Windows.Forms.Label lblMiddlleName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.Label lblBirthDay;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblAddress;
        private Bunifu.Framework.UI.BunifuDatepicker DatepickerlBirthDay;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtMiddleName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtlAddress;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtContact;
        private System.Windows.Forms.Label lblContact;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnCreate;
        private System.Windows.Forms.Label lblAddressError;
        private System.Windows.Forms.Label lblLastNameError;
        private System.Windows.Forms.Label lblFirstNameError;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteUsers;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitch;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSearchValue;
        private System.Windows.Forms.Label lblSearch;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdateUsers;
        private System.Windows.Forms.Label btnSearchByUsers;
        private System.Windows.Forms.ComboBox comboBoxActiveOrNotUsers;
        private System.Windows.Forms.Label lblNumberOfUsersValue;
        private System.Windows.Forms.Label lblNumberOfUsers;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchbtnDeactivateUsers;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeactivateUsers;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchActivateUsers;
        private Bunifu.Framework.UI.BunifuFlatButton btnActivateUsers;
        private System.Windows.Forms.DataGridView dataGridViewNotActiveUsers;
        private System.Windows.Forms.Label lblContactError;
        private System.Windows.Forms.Label lblBirthdayError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.Label lblPasswordNotMatch;
        private System.Windows.Forms.Label lblPasswordConfirmError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblErrorUsername;
        private Bunifu.Framework.UI.BunifuFlatButton btnBrowseImage;
        private System.Windows.Forms.PictureBox pictureBoxUserPic;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox groupBoxGender;
    }
}