namespace POSWithInventorySystem
{
    partial class AddStocksDialog
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
            this.groupBoxAddProductForm = new System.Windows.Forms.GroupBox();
            this.lblExpirationDateError = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblProductNameValue = new System.Windows.Forms.Label();
            this.lblPrductIDValue = new System.Windows.Forms.Label();
            this.lblQuantityStocksError = new System.Windows.Forms.Label();
            this.txtQuantity = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pictureBoxProductPic = new System.Windows.Forms.PictureBox();
            this.bunifuDatepickerExpiration = new Bunifu.Framework.UI.BunifuDatepicker();
            this.comboBox1ProductID = new System.Windows.Forms.ComboBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.lblProductNameCmb = new System.Windows.Forms.Label();
            this.lblProductIDcmb = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxAddProductForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAddProductForm
            // 
            this.groupBoxAddProductForm.Controls.Add(this.lblExpirationDateError);
            this.groupBoxAddProductForm.Controls.Add(this.lblExpirationDate);
            this.groupBoxAddProductForm.Controls.Add(this.lblProductNameValue);
            this.groupBoxAddProductForm.Controls.Add(this.lblPrductIDValue);
            this.groupBoxAddProductForm.Controls.Add(this.lblQuantityStocksError);
            this.groupBoxAddProductForm.Controls.Add(this.txtQuantity);
            this.groupBoxAddProductForm.Controls.Add(this.lblQuantity);
            this.groupBoxAddProductForm.Controls.Add(this.pictureBoxProductPic);
            this.groupBoxAddProductForm.Controls.Add(this.bunifuDatepickerExpiration);
            this.groupBoxAddProductForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBoxAddProductForm.Location = new System.Drawing.Point(12, 121);
            this.groupBoxAddProductForm.Name = "groupBoxAddProductForm";
            this.groupBoxAddProductForm.Size = new System.Drawing.Size(454, 355);
            this.groupBoxAddProductForm.TabIndex = 7;
            this.groupBoxAddProductForm.TabStop = false;
            this.groupBoxAddProductForm.Text = "Product Information";
            // 
            // lblExpirationDateError
            // 
            this.lblExpirationDateError.AutoSize = true;
            this.lblExpirationDateError.BackColor = System.Drawing.Color.Transparent;
            this.lblExpirationDateError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDateError.ForeColor = System.Drawing.Color.Red;
            this.lblExpirationDateError.Location = new System.Drawing.Point(373, 296);
            this.lblExpirationDateError.Name = "lblExpirationDateError";
            this.lblExpirationDateError.Size = new System.Drawing.Size(25, 19);
            this.lblExpirationDateError.TabIndex = 51;
            this.lblExpirationDateError.Text = "❌";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblExpirationDate.Location = new System.Drawing.Point(13, 259);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(137, 24);
            this.lblExpirationDate.TabIndex = 47;
            this.lblExpirationDate.Text = "Expiration Date";
            // 
            // lblProductNameValue
            // 
            this.lblProductNameValue.AutoSize = true;
            this.lblProductNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblProductNameValue.Location = new System.Drawing.Point(148, 112);
            this.lblProductNameValue.Name = "lblProductNameValue";
            this.lblProductNameValue.Size = new System.Drawing.Size(150, 24);
            this.lblProductNameValue.TabIndex = 42;
            this.lblProductNameValue.Text = "labelValueName";
            // 
            // lblPrductIDValue
            // 
            this.lblPrductIDValue.AutoSize = true;
            this.lblPrductIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPrductIDValue.Location = new System.Drawing.Point(148, 64);
            this.lblPrductIDValue.Name = "lblPrductIDValue";
            this.lblPrductIDValue.Size = new System.Drawing.Size(116, 24);
            this.lblPrductIDValue.TabIndex = 41;
            this.lblPrductIDValue.Text = "labelValueID";
            // 
            // lblQuantityStocksError
            // 
            this.lblQuantityStocksError.AutoSize = true;
            this.lblQuantityStocksError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityStocksError.ForeColor = System.Drawing.Color.Red;
            this.lblQuantityStocksError.Location = new System.Drawing.Point(404, 208);
            this.lblQuantityStocksError.Name = "lblQuantityStocksError";
            this.lblQuantityStocksError.Size = new System.Drawing.Size(25, 19);
            this.lblQuantityStocksError.TabIndex = 39;
            this.lblQuantityStocksError.Text = "❌";
            this.lblQuantityStocksError.Click += new System.EventHandler(this.lblQuantityStocksError_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderColorFocused = System.Drawing.Color.Black;
            this.txtQuantity.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtQuantity.BorderThickness = 2;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.isPassword = false;
            this.txtQuantity.Location = new System.Drawing.Point(17, 201);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(417, 33);
            this.txtQuantity.TabIndex = 19;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtQuantity.Enter += new System.EventHandler(this.txtQuantity_Enter);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblQuantity.Location = new System.Drawing.Point(13, 173);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(145, 24);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "Current Quantity";
            // 
            // pictureBoxProductPic
            // 
            this.pictureBoxProductPic.Image = global::POSWithInventorySystem.Properties.Resources.placeholder;
            this.pictureBoxProductPic.Location = new System.Drawing.Point(17, 34);
            this.pictureBoxProductPic.Name = "pictureBoxProductPic";
            this.pictureBoxProductPic.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxProductPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProductPic.TabIndex = 6;
            this.pictureBoxProductPic.TabStop = false;
            // 
            // bunifuDatepickerExpiration
            // 
            this.bunifuDatepickerExpiration.BackColor = System.Drawing.Color.Silver;
            this.bunifuDatepickerExpiration.BorderRadius = 0;
            this.bunifuDatepickerExpiration.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatepickerExpiration.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatepickerExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatepickerExpiration.FormatCustom = "MM-dd-yyyy";
            this.bunifuDatepickerExpiration.Location = new System.Drawing.Point(17, 288);
            this.bunifuDatepickerExpiration.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuDatepickerExpiration.Name = "bunifuDatepickerExpiration";
            this.bunifuDatepickerExpiration.Size = new System.Drawing.Size(417, 36);
            this.bunifuDatepickerExpiration.TabIndex = 52;
            this.bunifuDatepickerExpiration.Value = new System.DateTime(2018, 8, 4, 20, 34, 1, 107);
            this.bunifuDatepickerExpiration.onValueChanged += new System.EventHandler(this.bunifuDatepickerExpiration_onValueChanged);
            this.bunifuDatepickerExpiration.Enter += new System.EventHandler(this.bunifuDatepickerExpiration_Enter_1);
            // 
            // comboBox1ProductID
            // 
            this.comboBox1ProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1ProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1ProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBox1ProductID.FormattingEnabled = true;
            this.comboBox1ProductID.Location = new System.Drawing.Point(17, 49);
            this.comboBox1ProductID.Name = "comboBox1ProductID";
            this.comboBox1ProductID.Size = new System.Drawing.Size(148, 32);
            this.comboBox1ProductID.TabIndex = 50;
            this.comboBox1ProductID.SelectedIndexChanged += new System.EventHandler(this.comboBox1ProductID_SelectedIndexChanged);
            this.comboBox1ProductID.Enter += new System.EventHandler(this.comboBox1ProductID_Enter);
            this.comboBox1ProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1ProductID_KeyPress);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(141, 22);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(106, 63);
            this.bunifuSeparator1.TabIndex = 49;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(225, 49);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(214, 32);
            this.comboBoxProductName.TabIndex = 46;
            this.comboBoxProductName.SelectedIndexChanged += new System.EventHandler(this.comboBoxProductName_SelectedIndexChanged);
            this.comboBoxProductName.Enter += new System.EventHandler(this.comboBoxProductName_Enter);
            this.comboBoxProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxProductName_KeyPress);
            // 
            // lblProductNameCmb
            // 
            this.lblProductNameCmb.AutoSize = true;
            this.lblProductNameCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblProductNameCmb.Location = new System.Drawing.Point(221, 22);
            this.lblProductNameCmb.Name = "lblProductNameCmb";
            this.lblProductNameCmb.Size = new System.Drawing.Size(136, 24);
            this.lblProductNameCmb.TabIndex = 45;
            this.lblProductNameCmb.Text = "Product Name:";
            // 
            // lblProductIDcmb
            // 
            this.lblProductIDcmb.AutoSize = true;
            this.lblProductIDcmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblProductIDcmb.Location = new System.Drawing.Point(13, 22);
            this.lblProductIDcmb.Name = "lblProductIDcmb";
            this.lblProductIDcmb.Size = new System.Drawing.Size(102, 24);
            this.lblProductIDcmb.TabIndex = 44;
            this.lblProductIDcmb.Text = "Product ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.Gray;
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
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 90D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(261, 498);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(205, 61);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.Black;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.Orange;
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Add Stock";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = null;
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 0;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = false;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = false;
            this.btnAdd.IconZoom = 90D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(12, 498);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.Teal;
            this.btnAdd.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(205, 61);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add Stock";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProductIDcmb);
            this.groupBox1.Controls.Add(this.comboBox1ProductID);
            this.groupBox1.Controls.Add(this.lblProductNameCmb);
            this.groupBox1.Controls.Add(this.comboBoxProductName);
            this.groupBox1.Controls.Add(this.bunifuSeparator1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 100);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // AddStocksDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 581);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAddProductForm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStocksDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Stock to Selected Item";
            this.Load += new System.EventHandler(this.AddStocksDialog_Load);
            this.groupBoxAddProductForm.ResumeLayout(false);
            this.groupBoxAddProductForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxAddProductForm;
        private System.Windows.Forms.Label lblProductNameValue;
        private System.Windows.Forms.Label lblPrductIDValue;
        private System.Windows.Forms.Label lblQuantityStocksError;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.PictureBox pictureBoxProductPic;
        private System.Windows.Forms.ComboBox comboBoxProductName;
        private System.Windows.Forms.Label lblProductNameCmb;
        private System.Windows.Forms.Label lblProductIDcmb;
        private System.Windows.Forms.Label lblExpirationDate;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.ComboBox comboBox1ProductID;
        private System.Windows.Forms.Label lblExpirationDateError;
        private Bunifu.Framework.UI.BunifuDatepicker bunifuDatepickerExpiration;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}