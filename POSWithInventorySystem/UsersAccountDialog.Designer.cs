namespace POSWithInventorySystem
{
    partial class UsersAccountDialog
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
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersAccountDialog));
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            this.txtUsername = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblUserTypeValue = new System.Windows.Forms.Label();
            this.lblPasswordNotMatch = new System.Windows.Forms.Label();
            this.lblNewPasswordError = new System.Windows.Forms.Label();
            this.lblOldPasswordError = new System.Windows.Forms.Label();
            this.lblErrorUsername = new System.Windows.Forms.Label();
            this.lblUserIDValue = new System.Windows.Forms.Label();
            this.pictureBoxUserPic = new System.Windows.Forms.PictureBox();
            this.txtNewPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnUpdateAccount = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.btnPasswordSettings = new System.Windows.Forms.Button();
            this.btnUsernameSettings = new System.Windows.Forms.Button();
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BorderColorFocused = System.Drawing.Color.Black;
            this.txtUsername.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtUsername, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.txtUsername, BunifuAnimatorNS.DecorationType.None);
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.isPassword = false;
            this.txtUsername.Location = new System.Drawing.Point(211, 36);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(234, 37);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            // 
            // lblConfirmPasswordError
            // 
            this.lblConfirmPasswordError.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblConfirmPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblConfirmPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.lblConfirmPasswordError.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordError.Location = new System.Drawing.Point(422, 294);
            this.lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            this.lblConfirmPasswordError.Size = new System.Drawing.Size(19, 15);
            this.lblConfirmPasswordError.TabIndex = 24;
            this.lblConfirmPasswordError.Text = "❌";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderColorFocused = System.Drawing.Color.Black;
            this.txtConfirmPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtConfirmPassword.BorderThickness = 2;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtConfirmPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.txtConfirmPassword, BunifuAnimatorNS.DecorationType.None);
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassword.isPassword = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(211, 284);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(234, 37);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblConfirmPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblConfirmPassword, BunifuAnimatorNS.DecorationType.None);
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(207, 260);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(172, 20);
            this.lblConfirmPassword.TabIndex = 22;
            this.lblConfirmPassword.Text = "Confirm New Password";
            // 
            // lblUserTypeValue
            // 
            this.lblUserTypeValue.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblUserTypeValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblUserTypeValue, BunifuAnimatorNS.DecorationType.None);
            this.lblUserTypeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserTypeValue.Location = new System.Drawing.Point(12, 200);
            this.lblUserTypeValue.Name = "lblUserTypeValue";
            this.lblUserTypeValue.Size = new System.Drawing.Size(151, 20);
            this.lblUserTypeValue.TabIndex = 21;
            this.lblUserTypeValue.Text = "labelUserTypeValue";
            // 
            // lblPasswordNotMatch
            // 
            this.lblPasswordNotMatch.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblPasswordNotMatch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblPasswordNotMatch, BunifuAnimatorNS.DecorationType.None);
            this.lblPasswordNotMatch.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordNotMatch.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordNotMatch.Location = new System.Drawing.Point(423, 295);
            this.lblPasswordNotMatch.Name = "lblPasswordNotMatch";
            this.lblPasswordNotMatch.Size = new System.Drawing.Size(19, 15);
            this.lblPasswordNotMatch.TabIndex = 11;
            this.lblPasswordNotMatch.Text = "❌";
            // 
            // lblNewPasswordError
            // 
            this.lblNewPasswordError.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblNewPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblNewPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.lblNewPasswordError.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblNewPasswordError.Location = new System.Drawing.Point(422, 211);
            this.lblNewPasswordError.Name = "lblNewPasswordError";
            this.lblNewPasswordError.Size = new System.Drawing.Size(19, 15);
            this.lblNewPasswordError.TabIndex = 10;
            this.lblNewPasswordError.Text = "❌";
            // 
            // lblOldPasswordError
            // 
            this.lblOldPasswordError.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblOldPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblOldPasswordError, BunifuAnimatorNS.DecorationType.None);
            this.lblOldPasswordError.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblOldPasswordError.Location = new System.Drawing.Point(421, 128);
            this.lblOldPasswordError.Name = "lblOldPasswordError";
            this.lblOldPasswordError.Size = new System.Drawing.Size(19, 15);
            this.lblOldPasswordError.TabIndex = 9;
            this.lblOldPasswordError.Text = "❌";
            // 
            // lblErrorUsername
            // 
            this.lblErrorUsername.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblErrorUsername, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblErrorUsername, BunifuAnimatorNS.DecorationType.None);
            this.lblErrorUsername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsername.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsername.Location = new System.Drawing.Point(422, 46);
            this.lblErrorUsername.Name = "lblErrorUsername";
            this.lblErrorUsername.Size = new System.Drawing.Size(19, 15);
            this.lblErrorUsername.TabIndex = 8;
            this.lblErrorUsername.Text = "❌";
            // 
            // lblUserIDValue
            // 
            this.lblUserIDValue.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblUserIDValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblUserIDValue, BunifuAnimatorNS.DecorationType.None);
            this.lblUserIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDValue.Location = new System.Drawing.Point(12, 177);
            this.lblUserIDValue.Name = "lblUserIDValue";
            this.lblUserIDValue.Size = new System.Drawing.Size(134, 20);
            this.lblUserIDValue.TabIndex = 17;
            this.lblUserIDValue.Text = "labelUserIDValue";
            // 
            // pictureBoxUserPic
            // 
            this.bunifuTransition1.SetDecoration(this.pictureBoxUserPic, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBoxUserPic, BunifuAnimatorNS.DecorationType.None);
            this.pictureBoxUserPic.Image = global::POSWithInventorySystem.Properties.Resources.placeholder;
            this.pictureBoxUserPic.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxUserPic.Name = "pictureBoxUserPic";
            this.pictureBoxUserPic.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxUserPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserPic.TabIndex = 6;
            this.pictureBoxUserPic.TabStop = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderColorFocused = System.Drawing.Color.Black;
            this.txtNewPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtNewPassword.BorderThickness = 2;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtNewPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.txtNewPassword, BunifuAnimatorNS.DecorationType.None);
            this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.isPassword = true;
            this.txtNewPassword.Location = new System.Drawing.Point(211, 201);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(234, 37);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblNewPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblNewPassword, BunifuAnimatorNS.DecorationType.None);
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNewPassword.Location = new System.Drawing.Point(207, 177);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(113, 20);
            this.lblNewPassword.TabIndex = 4;
            this.lblNewPassword.Text = "New Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BorderColorFocused = System.Drawing.Color.Black;
            this.txtOldPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOldPassword.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtOldPassword.BorderThickness = 2;
            this.txtOldPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtOldPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.txtOldPassword, BunifuAnimatorNS.DecorationType.None);
            this.txtOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOldPassword.isPassword = true;
            this.txtOldPassword.Location = new System.Drawing.Point(211, 118);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(234, 37);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOldPassword.Enter += new System.EventHandler(this.txtOldPassword_Enter);
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblOldPassword, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblOldPassword, BunifuAnimatorNS.DecorationType.None);
            this.lblOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblOldPassword.Location = new System.Drawing.Point(207, 94);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(106, 20);
            this.lblOldPassword.TabIndex = 2;
            this.lblOldPassword.Text = "Old Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lblUsername, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblUsername, BunifuAnimatorNS.DecorationType.None);
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUsername.Location = new System.Drawing.Point(207, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Activecolor = System.Drawing.Color.Teal;
            this.btnUpdateAccount.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateAccount.BorderRadius = 0;
            this.btnUpdateAccount.ButtonText = "Update Account";
            this.btnUpdateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.btnUpdateAccount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnUpdateAccount, BunifuAnimatorNS.DecorationType.None);
            this.btnUpdateAccount.DisabledColor = System.Drawing.Color.DimGray;
            this.btnUpdateAccount.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAccount.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUpdateAccount.Iconimage = null;
            this.btnUpdateAccount.Iconimage_right = null;
            this.btnUpdateAccount.Iconimage_right_Selected = null;
            this.btnUpdateAccount.Iconimage_Selected = null;
            this.btnUpdateAccount.IconMarginLeft = 0;
            this.btnUpdateAccount.IconMarginRight = 0;
            this.btnUpdateAccount.IconRightVisible = true;
            this.btnUpdateAccount.IconRightZoom = 0D;
            this.btnUpdateAccount.IconVisible = true;
            this.btnUpdateAccount.IconZoom = 90D;
            this.btnUpdateAccount.IsTab = false;
            this.btnUpdateAccount.Location = new System.Drawing.Point(16, 346);
            this.btnUpdateAccount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Normalcolor = System.Drawing.Color.Teal;
            this.btnUpdateAccount.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnUpdateAccount.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnUpdateAccount.selected = false;
            this.btnUpdateAccount.Size = new System.Drawing.Size(193, 59);
            this.btnUpdateAccount.TabIndex = 32;
            this.btnUpdateAccount.Text = "Update Account";
            this.btnUpdateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateAccount.Textcolor = System.Drawing.Color.White;
            this.btnUpdateAccount.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.Gray;
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.btnCancel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnCancel, BunifuAnimatorNS.DecorationType.None);
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = null;
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 90D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(252, 346);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(193, 59);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.Black;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Rotate;
            this.bunifuTransition1.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(50);
            animation3.RotateCoeff = 1F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 1F;
            this.bunifuTransition1.DefaultAnimation = animation3;
            // 
            // btnPasswordSettings
            // 
            this.bunifuTransition1.SetDecoration(this.btnPasswordSettings, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnPasswordSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnPasswordSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPasswordSettings.Location = new System.Drawing.Point(202, 132);
            this.btnPasswordSettings.Name = "btnPasswordSettings";
            this.btnPasswordSettings.Size = new System.Drawing.Size(225, 88);
            this.btnPasswordSettings.TabIndex = 37;
            this.btnPasswordSettings.Text = "Change Password";
            this.btnPasswordSettings.UseVisualStyleBackColor = true;
            this.btnPasswordSettings.Click += new System.EventHandler(this.btnChangePasswordSettings_Click);
            // 
            // btnUsernameSettings
            // 
            this.bunifuTransition1.SetDecoration(this.btnUsernameSettings, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnUsernameSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnUsernameSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUsernameSettings.Location = new System.Drawing.Point(202, 12);
            this.btnUsernameSettings.Name = "btnUsernameSettings";
            this.btnUsernameSettings.Size = new System.Drawing.Size(225, 88);
            this.btnUsernameSettings.TabIndex = 38;
            this.btnUsernameSettings.Text = "Change Username";
            this.btnUsernameSettings.UseVisualStyleBackColor = true;
            this.btnUsernameSettings.Click += new System.EventHandler(this.btnUsernameSettings_Click);
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.bunifuTransition2.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 1F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.bunifuTransition2.DefaultAnimation = animation4;
            // 
            // UsersAccountDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(465, 426);
            this.Controls.Add(this.btnUsernameSettings);
            this.Controls.Add(this.btnPasswordSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.pictureBoxUserPic);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblConfirmPasswordError);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblUserTypeValue);
            this.Controls.Add(this.lblPasswordNotMatch);
            this.Controls.Add(this.lblUserIDValue);
            this.Controls.Add(this.lblNewPasswordError);
            this.Controls.Add(this.lblErrorUsername);
            this.Controls.Add(this.lblOldPasswordError);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.txtNewPassword);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersAccountDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsersAccountDialog_FormClosed);
            this.Load += new System.EventHandler(this.UsersAccountDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPasswordNotMatch;
        private System.Windows.Forms.Label lblNewPasswordError;
        private System.Windows.Forms.Label lblOldPasswordError;
        private System.Windows.Forms.Label lblErrorUsername;
        private Bunifu.Framework.UI.BunifuFlatButton btnBrowseImage;
        private System.Windows.Forms.PictureBox pictureBoxUserPic;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserTypeValue;
        private System.Windows.Forms.Label lblUserIDValue;
        private System.Windows.Forms.Label lblConfirmPasswordError;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdateAccount;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtUsername;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private System.Windows.Forms.Button btnPasswordSettings;
        private System.Windows.Forms.Button btnUsernameSettings;
    }
}