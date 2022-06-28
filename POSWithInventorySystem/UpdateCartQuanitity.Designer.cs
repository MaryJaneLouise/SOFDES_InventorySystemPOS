namespace POSWithInventorySystem
{
    partial class UpdateCartQuanitity
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
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtNewQuantityValue = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblNewQuantity = new System.Windows.Forms.Label();
            this.lblBarcodeValue = new System.Windows.Forms.Label();
            this.lblProductNameValue = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnDecreaseAll = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblQuantityError = new System.Windows.Forms.Label();
            this.lblCurrentQuantityValue = new System.Windows.Forms.Label();
            this.lblCurrentQuantity = new System.Windows.Forms.Label();
            this.pictureBoxProductPicVoid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPicVoid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.Gray;
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
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
            this.btnCancel.Location = new System.Drawing.Point(12, 281);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Gray;
            this.btnCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(217, 48);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.Black;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Activecolor = System.Drawing.Color.Orange;
            this.btnOk.BackColor = System.Drawing.Color.Orange;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.BorderRadius = 0;
            this.btnOk.ButtonText = "Deduct Quantity";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DisabledColor = System.Drawing.Color.Gray;
            this.btnOk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOk.Iconimage = null;
            this.btnOk.Iconimage_right = null;
            this.btnOk.Iconimage_right_Selected = null;
            this.btnOk.Iconimage_Selected = null;
            this.btnOk.IconMarginLeft = 0;
            this.btnOk.IconMarginRight = 0;
            this.btnOk.IconRightVisible = false;
            this.btnOk.IconRightZoom = 0D;
            this.btnOk.IconVisible = false;
            this.btnOk.IconZoom = 90D;
            this.btnOk.IsTab = false;
            this.btnOk.Location = new System.Drawing.Point(260, 281);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Normalcolor = System.Drawing.Color.Orange;
            this.btnOk.OnHovercolor = System.Drawing.Color.Gold;
            this.btnOk.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnOk.selected = false;
            this.btnOk.Size = new System.Drawing.Size(217, 48);
            this.btnOk.TabIndex = 43;
            this.btnOk.Text = "Deduct Quantity";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Textcolor = System.Drawing.Color.Black;
            this.btnOk.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNewQuantityValue
            // 
            this.txtNewQuantityValue.BorderColorFocused = System.Drawing.Color.Black;
            this.txtNewQuantityValue.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewQuantityValue.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtNewQuantityValue.BorderThickness = 2;
            this.txtNewQuantityValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewQuantityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtNewQuantityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewQuantityValue.isPassword = false;
            this.txtNewQuantityValue.Location = new System.Drawing.Point(275, 214);
            this.txtNewQuantityValue.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNewQuantityValue.Name = "txtNewQuantityValue";
            this.txtNewQuantityValue.Size = new System.Drawing.Size(100, 37);
            this.txtNewQuantityValue.TabIndex = 42;
            this.txtNewQuantityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewQuantityValue.OnValueChanged += new System.EventHandler(this.txtQuantityValue_OnValueChanged);
            this.txtNewQuantityValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantityValue_KeyPress);
            // 
            // lblNewQuantity
            // 
            this.lblNewQuantity.AutoSize = true;
            this.lblNewQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNewQuantity.Location = new System.Drawing.Point(8, 219);
            this.lblNewQuantity.Name = "lblNewQuantity";
            this.lblNewQuantity.Size = new System.Drawing.Size(266, 25);
            this.lblNewQuantity.TabIndex = 41;
            this.lblNewQuantity.Text = "Number of quantity to deduct:";
            // 
            // lblBarcodeValue
            // 
            this.lblBarcodeValue.AutoSize = true;
            this.lblBarcodeValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblBarcodeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblBarcodeValue.Location = new System.Drawing.Point(151, 12);
            this.lblBarcodeValue.Name = "lblBarcodeValue";
            this.lblBarcodeValue.Size = new System.Drawing.Size(177, 25);
            this.lblBarcodeValue.TabIndex = 47;
            this.lblBarcodeValue.Text = "labelBarcodeValue";
            // 
            // lblProductNameValue
            // 
            this.lblProductNameValue.AutoSize = true;
            this.lblProductNameValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblProductNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblProductNameValue.Location = new System.Drawing.Point(151, 48);
            this.lblProductNameValue.Name = "lblProductNameValue";
            this.lblProductNameValue.Size = new System.Drawing.Size(223, 25);
            this.lblProductNameValue.TabIndex = 48;
            this.lblProductNameValue.Text = "labelProductNameValue";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPriceValue.Location = new System.Drawing.Point(171, 94);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(23, 25);
            this.lblPriceValue.TabIndex = 50;
            this.lblPriceValue.Text = "0";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPrice.Location = new System.Drawing.Point(151, 93);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(25, 25);
            this.lblPrice.TabIndex = 49;
            this.lblPrice.Text = "₱";
            // 
            // btnDecreaseAll
            // 
            this.btnDecreaseAll.Activecolor = System.Drawing.Color.Orange;
            this.btnDecreaseAll.BackColor = System.Drawing.Color.Orange;
            this.btnDecreaseAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecreaseAll.BorderRadius = 0;
            this.btnDecreaseAll.ButtonText = "Decrease All";
            this.btnDecreaseAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecreaseAll.DisabledColor = System.Drawing.Color.Gray;
            this.btnDecreaseAll.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseAll.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDecreaseAll.Iconimage = null;
            this.btnDecreaseAll.Iconimage_right = null;
            this.btnDecreaseAll.Iconimage_right_Selected = null;
            this.btnDecreaseAll.Iconimage_Selected = null;
            this.btnDecreaseAll.IconMarginLeft = 0;
            this.btnDecreaseAll.IconMarginRight = 0;
            this.btnDecreaseAll.IconRightVisible = false;
            this.btnDecreaseAll.IconRightZoom = 0D;
            this.btnDecreaseAll.IconVisible = false;
            this.btnDecreaseAll.IconZoom = 90D;
            this.btnDecreaseAll.IsTab = false;
            this.btnDecreaseAll.Location = new System.Drawing.Point(384, 206);
            this.btnDecreaseAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDecreaseAll.Name = "btnDecreaseAll";
            this.btnDecreaseAll.Normalcolor = System.Drawing.Color.Orange;
            this.btnDecreaseAll.OnHovercolor = System.Drawing.Color.Gold;
            this.btnDecreaseAll.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDecreaseAll.selected = false;
            this.btnDecreaseAll.Size = new System.Drawing.Size(93, 55);
            this.btnDecreaseAll.TabIndex = 53;
            this.btnDecreaseAll.Text = "Decrease All";
            this.btnDecreaseAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDecreaseAll.Textcolor = System.Drawing.Color.Black;
            this.btnDecreaseAll.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDecreaseAll.Click += new System.EventHandler(this.btnDecreaseAll_Click);
            // 
            // lblQuantityError
            // 
            this.lblQuantityError.AutoSize = true;
            this.lblQuantityError.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityError.ForeColor = System.Drawing.Color.Red;
            this.lblQuantityError.Location = new System.Drawing.Point(347, 224);
            this.lblQuantityError.Name = "lblQuantityError";
            this.lblQuantityError.Size = new System.Drawing.Size(23, 17);
            this.lblQuantityError.TabIndex = 54;
            this.lblQuantityError.Text = "❌";
            // 
            // lblCurrentQuantityValue
            // 
            this.lblCurrentQuantityValue.AutoSize = true;
            this.lblCurrentQuantityValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentQuantityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCurrentQuantityValue.Location = new System.Drawing.Point(171, 162);
            this.lblCurrentQuantityValue.Name = "lblCurrentQuantityValue";
            this.lblCurrentQuantityValue.Size = new System.Drawing.Size(23, 25);
            this.lblCurrentQuantityValue.TabIndex = 56;
            this.lblCurrentQuantityValue.Text = "0";
            // 
            // lblCurrentQuantity
            // 
            this.lblCurrentQuantity.AutoSize = true;
            this.lblCurrentQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCurrentQuantity.Location = new System.Drawing.Point(8, 160);
            this.lblCurrentQuantity.Name = "lblCurrentQuantity";
            this.lblCurrentQuantity.Size = new System.Drawing.Size(161, 25);
            this.lblCurrentQuantity.TabIndex = 55;
            this.lblCurrentQuantity.Text = "Current Quantity:";
            // 
            // pictureBoxProductPicVoid
            // 
            this.pictureBoxProductPicVoid.Image = global::POSWithInventorySystem.Properties.Resources.placeholder;
            this.pictureBoxProductPicVoid.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxProductPicVoid.Name = "pictureBoxProductPicVoid";
            this.pictureBoxProductPicVoid.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxProductPicVoid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProductPicVoid.TabIndex = 78;
            this.pictureBoxProductPicVoid.TabStop = false;
            // 
            // UpdateCartQuanitity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 346);
            this.Controls.Add(this.pictureBoxProductPicVoid);
            this.Controls.Add(this.lblCurrentQuantityValue);
            this.Controls.Add(this.lblCurrentQuantity);
            this.Controls.Add(this.lblQuantityError);
            this.Controls.Add(this.btnDecreaseAll);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblProductNameValue);
            this.Controls.Add(this.lblBarcodeValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNewQuantityValue);
            this.Controls.Add(this.lblNewQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCartQuanitity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deduct Item Quantity";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateCartQuanitity_FormClosed);
            this.Load += new System.EventHandler(this.UpdateCartQuanitity_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateCartQuanitity_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPicVoid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnOk;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNewQuantityValue;
        private System.Windows.Forms.Label lblNewQuantity;
        private System.Windows.Forms.Label lblBarcodeValue;
        private System.Windows.Forms.Label lblProductNameValue;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblPrice;
        private Bunifu.Framework.UI.BunifuFlatButton btnDecreaseAll;
        private System.Windows.Forms.Label lblQuantityError;
        private System.Windows.Forms.Label lblCurrentQuantityValue;
        private System.Windows.Forms.Label lblCurrentQuantity;
        private System.Windows.Forms.PictureBox pictureBoxProductPicVoid;
    }
}