namespace POSWithInventorySystem
{
    partial class AddProductsDialog
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
            this.lblSellingPriceError = new System.Windows.Forms.Label();
            this.txtSellingPrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.lblDescriptionError = new System.Windows.Forms.Label();
            this.txtDescription = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPurchasePriceError = new System.Windows.Forms.Label();
            this.lblProductNameError = new System.Windows.Forms.Label();
            this.lblBarcodeError = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtPurchasePrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.btnBrowseImage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBoxProductPic = new System.Windows.Forms.PictureBox();
            this.txtProductName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtBarcode = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblBarcode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSellingPriceError
            // 
            this.lblSellingPriceError.AutoSize = true;
            this.lblSellingPriceError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellingPriceError.ForeColor = System.Drawing.Color.Red;
            this.lblSellingPriceError.Location = new System.Drawing.Point(895, 234);
            this.lblSellingPriceError.Name = "lblSellingPriceError";
            this.lblSellingPriceError.Size = new System.Drawing.Size(25, 19);
            this.lblSellingPriceError.TabIndex = 45;
            this.lblSellingPriceError.Text = "❌";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderColorFocused = System.Drawing.Color.Black;
            this.txtSellingPrice.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSellingPrice.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtSellingPrice.BorderThickness = 2;
            this.txtSellingPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSellingPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSellingPrice.isPassword = false;
            this.txtSellingPrice.Location = new System.Drawing.Point(616, 225);
            this.txtSellingPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(309, 37);
            this.txtSellingPrice.TabIndex = 5;
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSellingPrice.OnValueChanged += new System.EventHandler(this.txtSellingPrice_OnValueChanged);
            this.txtSellingPrice.Enter += new System.EventHandler(this.txtSellingPrice_Enter);
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            this.txtSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingPrice_KeyPress);
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSellingPrice.Location = new System.Drawing.Point(612, 201);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(164, 20);
            this.lblSellingPrice.TabIndex = 44;
            this.lblSellingPrice.Text = "Product Selling Price *";
            // 
            // lblDescriptionError
            // 
            this.lblDescriptionError.AutoSize = true;
            this.lblDescriptionError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblDescriptionError.Location = new System.Drawing.Point(895, 351);
            this.lblDescriptionError.Name = "lblDescriptionError";
            this.lblDescriptionError.Size = new System.Drawing.Size(25, 19);
            this.lblDescriptionError.TabIndex = 42;
            this.lblDescriptionError.Text = "❌";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColorFocused = System.Drawing.Color.Black;
            this.txtDescription.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescription.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtDescription.BorderThickness = 2;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescription.isPassword = false;
            this.txtDescription.Location = new System.Drawing.Point(16, 311);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(909, 97);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDescription.Location = new System.Drawing.Point(12, 287);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(158, 20);
            this.lblDescription.TabIndex = 40;
            this.lblDescription.Text = "Product Description *";
            // 
            // lblPurchasePriceError
            // 
            this.lblPurchasePriceError.AutoSize = true;
            this.lblPurchasePriceError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchasePriceError.ForeColor = System.Drawing.Color.Red;
            this.lblPurchasePriceError.Location = new System.Drawing.Point(512, 234);
            this.lblPurchasePriceError.Name = "lblPurchasePriceError";
            this.lblPurchasePriceError.Size = new System.Drawing.Size(25, 19);
            this.lblPurchasePriceError.TabIndex = 39;
            this.lblPurchasePriceError.Text = "❌";
            // 
            // lblProductNameError
            // 
            this.lblProductNameError.AutoSize = true;
            this.lblProductNameError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductNameError.ForeColor = System.Drawing.Color.Red;
            this.lblProductNameError.Location = new System.Drawing.Point(895, 138);
            this.lblProductNameError.Name = "lblProductNameError";
            this.lblProductNameError.Size = new System.Drawing.Size(25, 19);
            this.lblProductNameError.TabIndex = 37;
            this.lblProductNameError.Text = "❌";
            // 
            // lblBarcodeError
            // 
            this.lblBarcodeError.AutoSize = true;
            this.lblBarcodeError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcodeError.ForeColor = System.Drawing.Color.Red;
            this.lblBarcodeError.Location = new System.Drawing.Point(895, 46);
            this.lblBarcodeError.Name = "lblBarcodeError";
            this.lblBarcodeError.Size = new System.Drawing.Size(25, 19);
            this.lblBarcodeError.TabIndex = 36;
            this.lblBarcodeError.Text = "❌";
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.Silver;
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Silver;
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
            this.btnCancel.Location = new System.Drawing.Point(478, 449);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(447, 58);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.Black;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.Teal;
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Add Product";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = null;
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 0;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = true;
            this.btnAdd.IconZoom = 90D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(16, 449);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.Teal;
            this.btnAdd.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(447, 58);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.BorderColorFocused = System.Drawing.Color.Black;
            this.txtPurchasePrice.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPurchasePrice.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtPurchasePrice.BorderThickness = 2;
            this.txtPurchasePrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPurchasePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPurchasePrice.isPassword = false;
            this.txtPurchasePrice.Location = new System.Drawing.Point(233, 225);
            this.txtPurchasePrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(309, 37);
            this.txtPurchasePrice.TabIndex = 4;
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPurchasePrice.OnValueChanged += new System.EventHandler(this.txtPurchasePrice_OnValueChanged);
            this.txtPurchasePrice.Enter += new System.EventHandler(this.txtPurchasePrice_Enter);
            this.txtPurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchasePrice_KeyDown);
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchasePrice_KeyPress);
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPurchasePrice.Location = new System.Drawing.Point(229, 201);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(184, 20);
            this.lblPurchasePrice.TabIndex = 18;
            this.lblPurchasePrice.Text = "Product Purchase Price *";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Activecolor = System.Drawing.Color.Teal;
            this.btnBrowseImage.BackColor = System.Drawing.Color.Teal;
            this.btnBrowseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseImage.BorderRadius = 0;
            this.btnBrowseImage.ButtonText = "Browse Image";
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.DisabledColor = System.Drawing.Color.Gray;
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
            this.btnBrowseImage.Location = new System.Drawing.Point(12, 218);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Normalcolor = System.Drawing.Color.Teal;
            this.btnBrowseImage.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnBrowseImage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBrowseImage.selected = false;
            this.btnBrowseImage.Size = new System.Drawing.Size(200, 46);
            this.btnBrowseImage.TabIndex = 5;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowseImage.Textcolor = System.Drawing.Color.White;
            this.btnBrowseImage.TextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // pictureBoxProductPic
            // 
            this.pictureBoxProductPic.Image = global::POSWithInventorySystem.Properties.Resources.placeholder;
            this.pictureBoxProductPic.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxProductPic.Name = "pictureBoxProductPic";
            this.pictureBoxProductPic.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxProductPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProductPic.TabIndex = 6;
            this.pictureBoxProductPic.TabStop = false;
            // 
            // txtProductName
            // 
            this.txtProductName.BorderColorFocused = System.Drawing.Color.Black;
            this.txtProductName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProductName.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtProductName.BorderThickness = 2;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProductName.isPassword = false;
            this.txtProductName.Location = new System.Drawing.Point(233, 130);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(692, 37);
            this.txtProductName.TabIndex = 2;
            this.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProductName.Location = new System.Drawing.Point(229, 106);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(120, 20);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name *";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderColorFocused = System.Drawing.Color.Black;
            this.txtBarcode.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBarcode.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtBarcode.BorderThickness = 2;
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBarcode.isPassword = false;
            this.txtBarcode.Location = new System.Drawing.Point(233, 37);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(692, 39);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBarcode.Location = new System.Drawing.Point(229, 12);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(138, 20);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Product Barcode *";
            // 
            // AddProductsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 530);
            this.Controls.Add(this.lblSellingPriceError);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.lblDescriptionError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPurchasePriceError);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductNameError);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblBarcodeError);
            this.Controls.Add(this.pictureBoxProductPic);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Product";
            this.Load += new System.EventHandler(this.AddProductsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton btnBrowseImage;
        private System.Windows.Forms.PictureBox pictureBoxProductPic;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private System.Windows.Forms.Label lblPurchasePriceError;
        private System.Windows.Forms.Label lblProductNameError;
        private System.Windows.Forms.Label lblBarcodeError;
        private System.Windows.Forms.Label lblDescriptionError;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSellingPriceError;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSellingPrice;
        private System.Windows.Forms.Label lblSellingPrice;
    }
}