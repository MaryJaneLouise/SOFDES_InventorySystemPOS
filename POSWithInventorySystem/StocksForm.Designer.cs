namespace POSWithInventorySystem
{
    partial class StocksForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlProducts = new System.Windows.Forms.TabControl();
            this.tabPage1Products = new System.Windows.Forms.TabPage();
            this.btnPrint = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSwitchbtnDeleteProductInDB = new Bunifu.Framework.UI.BunifuSwitch();
            this.comboBoxProductStatusActiveOrNot = new System.Windows.Forms.ComboBox();
            this.lblStatusForProductActiveOrNot = new System.Windows.Forms.Label();
            this.lblNumberOfItemsValue = new System.Windows.Forms.Label();
            this.lblNumberOfItems = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.bunifuSwitch = new Bunifu.Framework.UI.BunifuSwitch();
            this.txtSearchValue = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDeleteProductInDB = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tabPage2Stocks = new System.Windows.Forms.TabPage();
            this.btnPrintStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSwitchDeleteTotalStocks = new Bunifu.Framework.UI.BunifuSwitch();
            this.lblNumberOfProductsValue = new System.Windows.Forms.Label();
            this.btnDeleteTotalStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblNumberOfProducts = new System.Windows.Forms.Label();
            this.comboBoxStocks = new System.Windows.Forms.ComboBox();
            this.lblStocks = new System.Windows.Forms.Label();
            this.lblTotalNumberOfStocksValue = new System.Windows.Forms.Label();
            this.lblTotalNumberOFStocks = new System.Windows.Forms.Label();
            this.bunifuSwitchStocks = new Bunifu.Framework.UI.BunifuSwitch();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBoxStocksStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelIndividualStocks = new System.Windows.Forms.Panel();
            this.lblIndividualExpiredValue = new System.Windows.Forms.Label();
            this.lblIndividualNearlyExpiredValue = new System.Windows.Forms.Label();
            this.lblIndividualExpired = new System.Windows.Forms.Label();
            this.lblIndividualNearlyExpired = new System.Windows.Forms.Label();
            this.lblIndividualNearlyExpiredColor = new System.Windows.Forms.Label();
            this.lblIndividualExpiredColor = new System.Windows.Forms.Label();
            this.panelTotalStocks = new System.Windows.Forms.Panel();
            this.lblTotalOutOfStocksValue = new System.Windows.Forms.Label();
            this.lblTotalLowinStocksValue = new System.Windows.Forms.Label();
            this.lblLowinStocks = new System.Windows.Forms.Label();
            this.lblTotalColorOutofStocks = new System.Windows.Forms.Label();
            this.lblTotalOutOfStocks = new System.Windows.Forms.Label();
            this.lblTotalColorLowinStocks = new System.Windows.Forms.Label();
            this.lblSearchTab2 = new System.Windows.Forms.Label();
            this.txtSearchTab2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnAddStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDeleteStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridViewStocksTab2 = new System.Windows.Forms.DataGridView();
            this.btnUpdateStocks = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tabControlProducts.SuspendLayout();
            this.tabPage1Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.tabPage2Stocks.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelIndividualStocks.SuspendLayout();
            this.panelTotalStocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocksTab2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlProducts
            // 
            this.tabControlProducts.Controls.Add(this.tabPage1Products);
            this.tabControlProducts.Controls.Add(this.tabPage2Stocks);
            this.tabControlProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tabControlProducts.Location = new System.Drawing.Point(12, 12);
            this.tabControlProducts.Name = "tabControlProducts";
            this.tabControlProducts.SelectedIndex = 0;
            this.tabControlProducts.Size = new System.Drawing.Size(1084, 746);
            this.tabControlProducts.TabIndex = 46;
            // 
            // tabPage1Products
            // 
            this.tabPage1Products.BackColor = System.Drawing.Color.White;
            this.tabPage1Products.Controls.Add(this.btnPrint);
            this.tabPage1Products.Controls.Add(this.bunifuSwitchbtnDeleteProductInDB);
            this.tabPage1Products.Controls.Add(this.comboBoxProductStatusActiveOrNot);
            this.tabPage1Products.Controls.Add(this.lblStatusForProductActiveOrNot);
            this.tabPage1Products.Controls.Add(this.lblNumberOfItemsValue);
            this.tabPage1Products.Controls.Add(this.lblNumberOfItems);
            this.tabPage1Products.Controls.Add(this.lblSearch);
            this.tabPage1Products.Controls.Add(this.bunifuSwitch);
            this.tabPage1Products.Controls.Add(this.txtSearchValue);
            this.tabPage1Products.Controls.Add(this.btnDelete);
            this.tabPage1Products.Controls.Add(this.dataGridViewProducts);
            this.tabPage1Products.Controls.Add(this.btnUpdate);
            this.tabPage1Products.Controls.Add(this.btnAdd);
            this.tabPage1Products.Controls.Add(this.btnDeleteProductInDB);
            this.tabPage1Products.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tabPage1Products.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1Products.Location = new System.Drawing.Point(4, 34);
            this.tabPage1Products.Name = "tabPage1Products";
            this.tabPage1Products.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1Products.Size = new System.Drawing.Size(1076, 708);
            this.tabPage1Products.TabIndex = 0;
            this.tabPage1Products.Text = "Products";
            // 
            // btnPrint
            // 
            this.btnPrint.Activecolor = System.Drawing.Color.Orange;
            this.btnPrint.BackColor = System.Drawing.Color.Orange;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.BorderRadius = 0;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DisabledColor = System.Drawing.Color.Gray;
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPrint.Iconimage = null;
            this.btnPrint.Iconimage_right = null;
            this.btnPrint.Iconimage_right_Selected = null;
            this.btnPrint.Iconimage_Selected = null;
            this.btnPrint.IconMarginLeft = 0;
            this.btnPrint.IconMarginRight = 0;
            this.btnPrint.IconRightVisible = false;
            this.btnPrint.IconRightZoom = 0D;
            this.btnPrint.IconVisible = false;
            this.btnPrint.IconZoom = 90D;
            this.btnPrint.IsTab = false;
            this.btnPrint.Location = new System.Drawing.Point(960, 570);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Normalcolor = System.Drawing.Color.Orange;
            this.btnPrint.OnHovercolor = System.Drawing.Color.Gold;
            this.btnPrint.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnPrint.selected = false;
            this.btnPrint.Size = new System.Drawing.Size(77, 27);
            this.btnPrint.TabIndex = 62;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Textcolor = System.Drawing.Color.Black;
            this.btnPrint.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // bunifuSwitchbtnDeleteProductInDB
            // 
            this.bunifuSwitchbtnDeleteProductInDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchbtnDeleteProductInDB.BorderRadius = 0;
            this.bunifuSwitchbtnDeleteProductInDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchbtnDeleteProductInDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchbtnDeleteProductInDB.Location = new System.Drawing.Point(672, 673);
            this.bunifuSwitchbtnDeleteProductInDB.Margin = new System.Windows.Forms.Padding(13);
            this.bunifuSwitchbtnDeleteProductInDB.Name = "bunifuSwitchbtnDeleteProductInDB";
            this.bunifuSwitchbtnDeleteProductInDB.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchbtnDeleteProductInDB.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchbtnDeleteProductInDB.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchbtnDeleteProductInDB.TabIndex = 60;
            this.bunifuSwitchbtnDeleteProductInDB.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchbtnDeleteProductInDB.Value = false;
            this.bunifuSwitchbtnDeleteProductInDB.Click += new System.EventHandler(this.bunifuSwitchbtnDeleteProductInDB_Click);
            // 
            // comboBoxProductStatusActiveOrNot
            // 
            this.comboBoxProductStatusActiveOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductStatusActiveOrNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxProductStatusActiveOrNot.FormattingEnabled = true;
            this.comboBoxProductStatusActiveOrNot.Items.AddRange(new object[] {
            "Active",
            "Not Active"});
            this.comboBoxProductStatusActiveOrNot.Location = new System.Drawing.Point(568, 48);
            this.comboBoxProductStatusActiveOrNot.Name = "comboBoxProductStatusActiveOrNot";
            this.comboBoxProductStatusActiveOrNot.Size = new System.Drawing.Size(469, 33);
            this.comboBoxProductStatusActiveOrNot.TabIndex = 58;
            this.comboBoxProductStatusActiveOrNot.SelectedIndexChanged += new System.EventHandler(this.comboBoxProductStatusActiveOrNot_SelectedIndexChanged);
            // 
            // lblStatusForProductActiveOrNot
            // 
            this.lblStatusForProductActiveOrNot.AutoSize = true;
            this.lblStatusForProductActiveOrNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblStatusForProductActiveOrNot.Location = new System.Drawing.Point(563, 20);
            this.lblStatusForProductActiveOrNot.Name = "lblStatusForProductActiveOrNot";
            this.lblStatusForProductActiveOrNot.Size = new System.Drawing.Size(74, 25);
            this.lblStatusForProductActiveOrNot.TabIndex = 49;
            this.lblStatusForProductActiveOrNot.Text = "Status:";
            // 
            // lblNumberOfItemsValue
            // 
            this.lblNumberOfItemsValue.AutoSize = true;
            this.lblNumberOfItemsValue.Location = new System.Drawing.Point(186, 570);
            this.lblNumberOfItemsValue.Name = "lblNumberOfItemsValue";
            this.lblNumberOfItemsValue.Size = new System.Drawing.Size(23, 25);
            this.lblNumberOfItemsValue.TabIndex = 48;
            this.lblNumberOfItemsValue.Text = "0\r\n";
            // 
            // lblNumberOfItems
            // 
            this.lblNumberOfItems.AutoSize = true;
            this.lblNumberOfItems.Location = new System.Drawing.Point(29, 570);
            this.lblNumberOfItems.Name = "lblNumberOfItems";
            this.lblNumberOfItems.Size = new System.Drawing.Size(160, 25);
            this.lblNumberOfItems.TabIndex = 47;
            this.lblNumberOfItems.Text = "Number of Items:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSearch.Location = new System.Drawing.Point(29, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(81, 25);
            this.lblSearch.TabIndex = 44;
            this.lblSearch.Text = "Search:";
            // 
            // bunifuSwitch
            // 
            this.bunifuSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitch.BorderRadius = 0;
            this.bunifuSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch.Location = new System.Drawing.Point(717, 673);
            this.bunifuSwitch.Margin = new System.Windows.Forms.Padding(8);
            this.bunifuSwitch.Name = "bunifuSwitch";
            this.bunifuSwitch.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitch.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitch.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitch.TabIndex = 43;
            this.bunifuSwitch.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch.Value = false;
            this.bunifuSwitch.Click += new System.EventHandler(this.bunifuSwitch_Click);
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
            this.txtSearchValue.Location = new System.Drawing.Point(34, 47);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(469, 34);
            this.txtSearchValue.TabIndex = 45;
            this.txtSearchValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchValue.OnValueChanged += new System.EventHandler(this.txtSearchValue_OnValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Activecolor = System.Drawing.Color.Gray;
            this.btnDelete.BackColor = System.Drawing.Color.Gray;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.ButtonText = "Deactivate";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = null;
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconMarginLeft = 0;
            this.btnDelete.IconMarginRight = 0;
            this.btnDelete.IconRightVisible = false;
            this.btnDelete.IconRightZoom = 0D;
            this.btnDelete.IconVisible = false;
            this.btnDelete.IconZoom = 90D;
            this.btnDelete.IsTab = false;
            this.btnDelete.Location = new System.Drawing.Point(739, 624);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.Gray;
            this.btnDelete.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(298, 48);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.Text = "Deactivate";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Textcolor = System.Drawing.Color.Black;
            this.btnDelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProducts.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewProducts.Location = new System.Drawing.Point(34, 106);
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1003, 445);
            this.dataGridViewProducts.TabIndex = 39;
            this.dataGridViewProducts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProducts_ColumnHeaderMouseClick);
            this.dataGridViewProducts.DoubleClick += new System.EventHandler(this.dataGridViewProducts_DoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Activecolor = System.Drawing.Color.Orange;
            this.btnUpdate.BackColor = System.Drawing.Color.Orange;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.BorderRadius = 0;
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DisabledColor = System.Drawing.Color.Gray;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUpdate.Iconimage = null;
            this.btnUpdate.Iconimage_right = null;
            this.btnUpdate.Iconimage_right_Selected = null;
            this.btnUpdate.Iconimage_Selected = null;
            this.btnUpdate.IconMarginLeft = 0;
            this.btnUpdate.IconMarginRight = 0;
            this.btnUpdate.IconRightVisible = false;
            this.btnUpdate.IconRightZoom = 0D;
            this.btnUpdate.IconVisible = false;
            this.btnUpdate.IconZoom = 90D;
            this.btnUpdate.IsTab = false;
            this.btnUpdate.Location = new System.Drawing.Point(387, 624);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Normalcolor = System.Drawing.Color.Orange;
            this.btnUpdate.OnHovercolor = System.Drawing.Color.Gold;
            this.btnUpdate.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnUpdate.selected = false;
            this.btnUpdate.Size = new System.Drawing.Size(298, 48);
            this.btnUpdate.TabIndex = 41;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Textcolor = System.Drawing.Color.Black;
            this.btnUpdate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.Orange;
            this.btnAdd.BackColor = System.Drawing.Color.Orange;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Add";
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
            this.btnAdd.IconRightVisible = false;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = false;
            this.btnAdd.IconZoom = 90D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(34, 624);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.Orange;
            this.btnAdd.OnHovercolor = System.Drawing.Color.Gold;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(298, 48);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Textcolor = System.Drawing.Color.Black;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteProductInDB
            // 
            this.btnDeleteProductInDB.Activecolor = System.Drawing.Color.Gray;
            this.btnDeleteProductInDB.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteProductInDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteProductInDB.BorderRadius = 0;
            this.btnDeleteProductInDB.ButtonText = "Delete";
            this.btnDeleteProductInDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProductInDB.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeleteProductInDB.Enabled = false;
            this.btnDeleteProductInDB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProductInDB.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteProductInDB.Iconimage = null;
            this.btnDeleteProductInDB.Iconimage_right = null;
            this.btnDeleteProductInDB.Iconimage_right_Selected = null;
            this.btnDeleteProductInDB.Iconimage_Selected = null;
            this.btnDeleteProductInDB.IconMarginLeft = 0;
            this.btnDeleteProductInDB.IconMarginRight = 0;
            this.btnDeleteProductInDB.IconRightVisible = false;
            this.btnDeleteProductInDB.IconRightZoom = 0D;
            this.btnDeleteProductInDB.IconVisible = false;
            this.btnDeleteProductInDB.IconZoom = 90D;
            this.btnDeleteProductInDB.IsTab = false;
            this.btnDeleteProductInDB.Location = new System.Drawing.Point(571, 624);
            this.btnDeleteProductInDB.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteProductInDB.Name = "btnDeleteProductInDB";
            this.btnDeleteProductInDB.Normalcolor = System.Drawing.Color.Gray;
            this.btnDeleteProductInDB.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteProductInDB.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDeleteProductInDB.selected = false;
            this.btnDeleteProductInDB.Size = new System.Drawing.Size(469, 48);
            this.btnDeleteProductInDB.TabIndex = 59;
            this.btnDeleteProductInDB.Text = "Delete";
            this.btnDeleteProductInDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteProductInDB.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteProductInDB.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProductInDB.Click += new System.EventHandler(this.btnDeleteProductInDB_Click);
            // 
            // tabPage2Stocks
            // 
            this.tabPage2Stocks.BackColor = System.Drawing.Color.White;
            this.tabPage2Stocks.Controls.Add(this.btnPrintStocks);
            this.tabPage2Stocks.Controls.Add(this.bunifuSwitchDeleteTotalStocks);
            this.tabPage2Stocks.Controls.Add(this.lblNumberOfProductsValue);
            this.tabPage2Stocks.Controls.Add(this.lblNumberOfProducts);
            this.tabPage2Stocks.Controls.Add(this.comboBoxStocks);
            this.tabPage2Stocks.Controls.Add(this.lblStocks);
            this.tabPage2Stocks.Controls.Add(this.lblTotalNumberOfStocksValue);
            this.tabPage2Stocks.Controls.Add(this.lblTotalNumberOFStocks);
            this.tabPage2Stocks.Controls.Add(this.bunifuSwitchStocks);
            this.tabPage2Stocks.Controls.Add(this.lblStatus);
            this.tabPage2Stocks.Controls.Add(this.comboBoxStocksStatus);
            this.tabPage2Stocks.Controls.Add(this.groupBox1);
            this.tabPage2Stocks.Controls.Add(this.lblSearchTab2);
            this.tabPage2Stocks.Controls.Add(this.txtSearchTab2);
            this.tabPage2Stocks.Controls.Add(this.btnAddStocks);
            this.tabPage2Stocks.Controls.Add(this.btnDeleteStocks);
            this.tabPage2Stocks.Controls.Add(this.dataGridViewStocksTab2);
            this.tabPage2Stocks.Controls.Add(this.btnUpdateStocks);
            this.tabPage2Stocks.Controls.Add(this.btnDeleteTotalStocks);
            this.tabPage2Stocks.Location = new System.Drawing.Point(4, 34);
            this.tabPage2Stocks.Name = "tabPage2Stocks";
            this.tabPage2Stocks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2Stocks.Size = new System.Drawing.Size(1076, 708);
            this.tabPage2Stocks.TabIndex = 1;
            this.tabPage2Stocks.Text = "Stocks";
            // 
            // btnPrintStocks
            // 
            this.btnPrintStocks.Activecolor = System.Drawing.Color.Orange;
            this.btnPrintStocks.BackColor = System.Drawing.Color.Orange;
            this.btnPrintStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintStocks.BorderRadius = 0;
            this.btnPrintStocks.ButtonText = "Print";
            this.btnPrintStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintStocks.DisabledColor = System.Drawing.Color.Gray;
            this.btnPrintStocks.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPrintStocks.Iconimage = null;
            this.btnPrintStocks.Iconimage_right = null;
            this.btnPrintStocks.Iconimage_right_Selected = null;
            this.btnPrintStocks.Iconimage_Selected = null;
            this.btnPrintStocks.IconMarginLeft = 0;
            this.btnPrintStocks.IconMarginRight = 0;
            this.btnPrintStocks.IconRightVisible = false;
            this.btnPrintStocks.IconRightZoom = 0D;
            this.btnPrintStocks.IconVisible = false;
            this.btnPrintStocks.IconZoom = 90D;
            this.btnPrintStocks.IsTab = false;
            this.btnPrintStocks.Location = new System.Drawing.Point(975, 654);
            this.btnPrintStocks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrintStocks.Name = "btnPrintStocks";
            this.btnPrintStocks.Normalcolor = System.Drawing.Color.Orange;
            this.btnPrintStocks.OnHovercolor = System.Drawing.Color.Gold;
            this.btnPrintStocks.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnPrintStocks.selected = false;
            this.btnPrintStocks.Size = new System.Drawing.Size(77, 27);
            this.btnPrintStocks.TabIndex = 63;
            this.btnPrintStocks.Text = "Print";
            this.btnPrintStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrintStocks.Textcolor = System.Drawing.Color.Black;
            this.btnPrintStocks.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStocks.Click += new System.EventHandler(this.btnPrintStocks_Click);
            // 
            // bunifuSwitchDeleteTotalStocks
            // 
            this.bunifuSwitchDeleteTotalStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchDeleteTotalStocks.BorderRadius = 0;
            this.bunifuSwitchDeleteTotalStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchDeleteTotalStocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchDeleteTotalStocks.Location = new System.Drawing.Point(910, 639);
            this.bunifuSwitchDeleteTotalStocks.Margin = new System.Windows.Forms.Padding(17);
            this.bunifuSwitchDeleteTotalStocks.Name = "bunifuSwitchDeleteTotalStocks";
            this.bunifuSwitchDeleteTotalStocks.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchDeleteTotalStocks.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchDeleteTotalStocks.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchDeleteTotalStocks.TabIndex = 48;
            this.bunifuSwitchDeleteTotalStocks.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchDeleteTotalStocks.Value = false;
            this.bunifuSwitchDeleteTotalStocks.Click += new System.EventHandler(this.bunifuSwitchDeleteTotalStocks_Click);
            // 
            // lblNumberOfProductsValue
            // 
            this.lblNumberOfProductsValue.AutoSize = true;
            this.lblNumberOfProductsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNumberOfProductsValue.Location = new System.Drawing.Point(205, 655);
            this.lblNumberOfProductsValue.Name = "lblNumberOfProductsValue";
            this.lblNumberOfProductsValue.Size = new System.Drawing.Size(23, 25);
            this.lblNumberOfProductsValue.TabIndex = 59;
            this.lblNumberOfProductsValue.Text = "0\r\n";
            // 
            // btnDeleteTotalStocks
            // 
            this.btnDeleteTotalStocks.Activecolor = System.Drawing.Color.Gray;
            this.btnDeleteTotalStocks.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteTotalStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteTotalStocks.BorderRadius = 0;
            this.btnDeleteTotalStocks.ButtonText = "Delete";
            this.btnDeleteTotalStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTotalStocks.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeleteTotalStocks.Enabled = false;
            this.btnDeleteTotalStocks.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTotalStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteTotalStocks.Iconimage = null;
            this.btnDeleteTotalStocks.Iconimage_right = null;
            this.btnDeleteTotalStocks.Iconimage_right_Selected = null;
            this.btnDeleteTotalStocks.Iconimage_Selected = null;
            this.btnDeleteTotalStocks.IconMarginLeft = 0;
            this.btnDeleteTotalStocks.IconMarginRight = 0;
            this.btnDeleteTotalStocks.IconRightVisible = false;
            this.btnDeleteTotalStocks.IconRightZoom = 0D;
            this.btnDeleteTotalStocks.IconVisible = false;
            this.btnDeleteTotalStocks.IconZoom = 90D;
            this.btnDeleteTotalStocks.IsTab = false;
            this.btnDeleteTotalStocks.Location = new System.Drawing.Point(754, 166);
            this.btnDeleteTotalStocks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteTotalStocks.Name = "btnDeleteTotalStocks";
            this.btnDeleteTotalStocks.Normalcolor = System.Drawing.Color.Gray;
            this.btnDeleteTotalStocks.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteTotalStocks.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDeleteTotalStocks.selected = false;
            this.btnDeleteTotalStocks.Size = new System.Drawing.Size(298, 89);
            this.btnDeleteTotalStocks.TabIndex = 47;
            this.btnDeleteTotalStocks.Text = "Delete";
            this.btnDeleteTotalStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteTotalStocks.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteTotalStocks.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTotalStocks.Click += new System.EventHandler(this.btnDeleteTotalStocks_Click);
            // 
            // lblNumberOfProducts
            // 
            this.lblNumberOfProducts.AutoSize = true;
            this.lblNumberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNumberOfProducts.Location = new System.Drawing.Point(23, 654);
            this.lblNumberOfProducts.Name = "lblNumberOfProducts";
            this.lblNumberOfProducts.Size = new System.Drawing.Size(190, 25);
            this.lblNumberOfProducts.TabIndex = 58;
            this.lblNumberOfProducts.Text = "Number of Products:";
            // 
            // comboBoxStocks
            // 
            this.comboBoxStocks.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxStocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxStocks.FormattingEnabled = true;
            this.comboBoxStocks.Items.AddRange(new object[] {
            "Total Stocks Per Products",
            "Individual Stocks Per Products"});
            this.comboBoxStocks.Location = new System.Drawing.Point(754, 46);
            this.comboBoxStocks.Name = "comboBoxStocks";
            this.comboBoxStocks.Size = new System.Drawing.Size(298, 33);
            this.comboBoxStocks.TabIndex = 57;
            this.comboBoxStocks.SelectedIndexChanged += new System.EventHandler(this.comboBoxStocks_SelectedIndexChanged);
            // 
            // lblStocks
            // 
            this.lblStocks.AutoSize = true;
            this.lblStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblStocks.Location = new System.Drawing.Point(749, 16);
            this.lblStocks.Name = "lblStocks";
            this.lblStocks.Size = new System.Drawing.Size(78, 25);
            this.lblStocks.TabIndex = 56;
            this.lblStocks.Text = "Stocks:";
            // 
            // lblTotalNumberOfStocksValue
            // 
            this.lblTotalNumberOfStocksValue.AutoSize = true;
            this.lblTotalNumberOfStocksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalNumberOfStocksValue.Location = new System.Drawing.Point(192, 654);
            this.lblTotalNumberOfStocksValue.Name = "lblTotalNumberOfStocksValue";
            this.lblTotalNumberOfStocksValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalNumberOfStocksValue.TabIndex = 54;
            this.lblTotalNumberOfStocksValue.Text = "0\r\n";
            // 
            // lblTotalNumberOFStocks
            // 
            this.lblTotalNumberOFStocks.AutoSize = true;
            this.lblTotalNumberOFStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalNumberOFStocks.Location = new System.Drawing.Point(26, 654);
            this.lblTotalNumberOFStocks.Name = "lblTotalNumberOFStocks";
            this.lblTotalNumberOFStocks.Size = new System.Drawing.Size(173, 25);
            this.lblTotalNumberOFStocks.TabIndex = 53;
            this.lblTotalNumberOFStocks.Text = "Number of Stocks:";
            // 
            // bunifuSwitchStocks
            // 
            this.bunifuSwitchStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchStocks.BorderRadius = 0;
            this.bunifuSwitchStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchStocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchStocks.Location = new System.Drawing.Point(910, 662);
            this.bunifuSwitchStocks.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.bunifuSwitchStocks.Name = "bunifuSwitchStocks";
            this.bunifuSwitchStocks.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchStocks.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchStocks.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchStocks.TabIndex = 47;
            this.bunifuSwitchStocks.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchStocks.Value = false;
            this.bunifuSwitchStocks.Click += new System.EventHandler(this.bunifuSwitchStocks_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblStatus.Location = new System.Drawing.Point(749, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 25);
            this.lblStatus.TabIndex = 52;
            this.lblStatus.Text = "Status:";
            // 
            // comboBoxStocksStatus
            // 
            this.comboBoxStocksStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStocksStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxStocksStatus.FormattingEnabled = true;
            this.comboBoxStocksStatus.Items.AddRange(new object[] {
            "Select",
            "All",
            "Good",
            "Expired"});
            this.comboBoxStocksStatus.Location = new System.Drawing.Point(754, 125);
            this.comboBoxStocksStatus.Name = "comboBoxStocksStatus";
            this.comboBoxStocksStatus.Size = new System.Drawing.Size(298, 33);
            this.comboBoxStocksStatus.TabIndex = 51;
            this.comboBoxStocksStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStocksStatus_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelTotalStocks);
            this.groupBox1.Controls.Add(this.panelIndividualStocks);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.groupBox1.Location = new System.Drawing.Point(720, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 200);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // panelIndividualStocks
            // 
            this.panelIndividualStocks.Controls.Add(this.lblIndividualExpiredValue);
            this.panelIndividualStocks.Controls.Add(this.lblIndividualNearlyExpiredValue);
            this.panelIndividualStocks.Controls.Add(this.lblIndividualExpired);
            this.panelIndividualStocks.Controls.Add(this.lblIndividualNearlyExpired);
            this.panelIndividualStocks.Controls.Add(this.lblIndividualNearlyExpiredColor);
            this.panelIndividualStocks.Controls.Add(this.lblIndividualExpiredColor);
            this.panelIndividualStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIndividualStocks.Location = new System.Drawing.Point(3, 26);
            this.panelIndividualStocks.Name = "panelIndividualStocks";
            this.panelIndividualStocks.Size = new System.Drawing.Size(331, 171);
            this.panelIndividualStocks.TabIndex = 58;
            // 
            // lblIndividualExpiredValue
            // 
            this.lblIndividualExpiredValue.AutoSize = true;
            this.lblIndividualExpiredValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblIndividualExpiredValue.Location = new System.Drawing.Point(57, 124);
            this.lblIndividualExpiredValue.Name = "lblIndividualExpiredValue";
            this.lblIndividualExpiredValue.Size = new System.Drawing.Size(23, 25);
            this.lblIndividualExpiredValue.TabIndex = 62;
            this.lblIndividualExpiredValue.Text = "0";
            // 
            // lblIndividualNearlyExpiredValue
            // 
            this.lblIndividualNearlyExpiredValue.AutoSize = true;
            this.lblIndividualNearlyExpiredValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblIndividualNearlyExpiredValue.Location = new System.Drawing.Point(57, 42);
            this.lblIndividualNearlyExpiredValue.Name = "lblIndividualNearlyExpiredValue";
            this.lblIndividualNearlyExpiredValue.Size = new System.Drawing.Size(23, 25);
            this.lblIndividualNearlyExpiredValue.TabIndex = 61;
            this.lblIndividualNearlyExpiredValue.Text = "0";
            // 
            // lblIndividualExpired
            // 
            this.lblIndividualExpired.AutoSize = true;
            this.lblIndividualExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblIndividualExpired.Location = new System.Drawing.Point(57, 96);
            this.lblIndividualExpired.Name = "lblIndividualExpired";
            this.lblIndividualExpired.Size = new System.Drawing.Size(156, 25);
            this.lblIndividualExpired.TabIndex = 60;
            this.lblIndividualExpired.Text = "Expired Product:";
            // 
            // lblIndividualNearlyExpired
            // 
            this.lblIndividualNearlyExpired.AutoSize = true;
            this.lblIndividualNearlyExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblIndividualNearlyExpired.Location = new System.Drawing.Point(57, 15);
            this.lblIndividualNearlyExpired.Name = "lblIndividualNearlyExpired";
            this.lblIndividualNearlyExpired.Size = new System.Drawing.Size(217, 25);
            this.lblIndividualNearlyExpired.TabIndex = 59;
            this.lblIndividualNearlyExpired.Text = "Nearly Expired Product:";
            // 
            // lblIndividualNearlyExpiredColor
            // 
            this.lblIndividualNearlyExpiredColor.BackColor = System.Drawing.Color.Gold;
            this.lblIndividualNearlyExpiredColor.Location = new System.Drawing.Point(23, 13);
            this.lblIndividualNearlyExpiredColor.Name = "lblIndividualNearlyExpiredColor";
            this.lblIndividualNearlyExpiredColor.Size = new System.Drawing.Size(25, 22);
            this.lblIndividualNearlyExpiredColor.TabIndex = 1;
            // 
            // lblIndividualExpiredColor
            // 
            this.lblIndividualExpiredColor.BackColor = System.Drawing.Color.Red;
            this.lblIndividualExpiredColor.Location = new System.Drawing.Point(23, 96);
            this.lblIndividualExpiredColor.Name = "lblIndividualExpiredColor";
            this.lblIndividualExpiredColor.Size = new System.Drawing.Size(25, 22);
            this.lblIndividualExpiredColor.TabIndex = 0;
            // 
            // panelTotalStocks
            // 
            this.panelTotalStocks.Controls.Add(this.lblTotalOutOfStocksValue);
            this.panelTotalStocks.Controls.Add(this.lblTotalLowinStocksValue);
            this.panelTotalStocks.Controls.Add(this.lblLowinStocks);
            this.panelTotalStocks.Controls.Add(this.lblTotalColorOutofStocks);
            this.panelTotalStocks.Controls.Add(this.lblTotalOutOfStocks);
            this.panelTotalStocks.Controls.Add(this.lblTotalColorLowinStocks);
            this.panelTotalStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalStocks.Location = new System.Drawing.Point(3, 26);
            this.panelTotalStocks.Name = "panelTotalStocks";
            this.panelTotalStocks.Size = new System.Drawing.Size(331, 171);
            this.panelTotalStocks.TabIndex = 0;
            // 
            // lblTotalOutOfStocksValue
            // 
            this.lblTotalOutOfStocksValue.AutoSize = true;
            this.lblTotalOutOfStocksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalOutOfStocksValue.Location = new System.Drawing.Point(57, 124);
            this.lblTotalOutOfStocksValue.Name = "lblTotalOutOfStocksValue";
            this.lblTotalOutOfStocksValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalOutOfStocksValue.TabIndex = 63;
            this.lblTotalOutOfStocksValue.Text = "0";
            // 
            // lblTotalLowinStocksValue
            // 
            this.lblTotalLowinStocksValue.AutoSize = true;
            this.lblTotalLowinStocksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalLowinStocksValue.Location = new System.Drawing.Point(57, 42);
            this.lblTotalLowinStocksValue.Name = "lblTotalLowinStocksValue";
            this.lblTotalLowinStocksValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalLowinStocksValue.TabIndex = 63;
            this.lblTotalLowinStocksValue.Text = "0";
            // 
            // lblLowinStocks
            // 
            this.lblLowinStocks.AutoSize = true;
            this.lblLowinStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblLowinStocks.Location = new System.Drawing.Point(57, 15);
            this.lblLowinStocks.Name = "lblLowinStocks";
            this.lblLowinStocks.Size = new System.Drawing.Size(139, 25);
            this.lblLowinStocks.TabIndex = 65;
            this.lblLowinStocks.Text = "Low in Stocks:";
            // 
            // lblTotalColorOutofStocks
            // 
            this.lblTotalColorOutofStocks.BackColor = System.Drawing.Color.Red;
            this.lblTotalColorOutofStocks.Location = new System.Drawing.Point(23, 96);
            this.lblTotalColorOutofStocks.Name = "lblTotalColorOutofStocks";
            this.lblTotalColorOutofStocks.Size = new System.Drawing.Size(25, 22);
            this.lblTotalColorOutofStocks.TabIndex = 63;
            // 
            // lblTotalOutOfStocks
            // 
            this.lblTotalOutOfStocks.AutoSize = true;
            this.lblTotalOutOfStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalOutOfStocks.Location = new System.Drawing.Point(57, 96);
            this.lblTotalOutOfStocks.Name = "lblTotalOutOfStocks";
            this.lblTotalOutOfStocks.Size = new System.Drawing.Size(136, 25);
            this.lblTotalOutOfStocks.TabIndex = 66;
            this.lblTotalOutOfStocks.Text = "Out of Stocks:";
            // 
            // lblTotalColorLowinStocks
            // 
            this.lblTotalColorLowinStocks.BackColor = System.Drawing.Color.Gold;
            this.lblTotalColorLowinStocks.Location = new System.Drawing.Point(23, 14);
            this.lblTotalColorLowinStocks.Name = "lblTotalColorLowinStocks";
            this.lblTotalColorLowinStocks.Size = new System.Drawing.Size(25, 22);
            this.lblTotalColorLowinStocks.TabIndex = 64;
            // 
            // lblSearchTab2
            // 
            this.lblSearchTab2.AutoSize = true;
            this.lblSearchTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSearchTab2.Location = new System.Drawing.Point(16, 16);
            this.lblSearchTab2.Name = "lblSearchTab2";
            this.lblSearchTab2.Size = new System.Drawing.Size(81, 25);
            this.lblSearchTab2.TabIndex = 47;
            this.lblSearchTab2.Text = "Search:";
            // 
            // txtSearchTab2
            // 
            this.txtSearchTab2.BorderColorFocused = System.Drawing.Color.Black;
            this.txtSearchTab2.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchTab2.BorderColorMouseHover = System.Drawing.Color.Black;
            this.txtSearchTab2.BorderThickness = 2;
            this.txtSearchTab2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtSearchTab2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchTab2.isPassword = false;
            this.txtSearchTab2.Location = new System.Drawing.Point(21, 45);
            this.txtSearchTab2.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchTab2.Name = "txtSearchTab2";
            this.txtSearchTab2.Size = new System.Drawing.Size(693, 34);
            this.txtSearchTab2.TabIndex = 48;
            this.txtSearchTab2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchTab2.OnValueChanged += new System.EventHandler(this.txtSearchTab2_OnValueChanged);
            // 
            // btnAddStocks
            // 
            this.btnAddStocks.Activecolor = System.Drawing.Color.Orange;
            this.btnAddStocks.BackColor = System.Drawing.Color.Orange;
            this.btnAddStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddStocks.BorderRadius = 0;
            this.btnAddStocks.ButtonText = "Add Stocks";
            this.btnAddStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStocks.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddStocks.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddStocks.Iconimage = null;
            this.btnAddStocks.Iconimage_right = null;
            this.btnAddStocks.Iconimage_right_Selected = null;
            this.btnAddStocks.Iconimage_Selected = null;
            this.btnAddStocks.IconMarginLeft = 0;
            this.btnAddStocks.IconMarginRight = 0;
            this.btnAddStocks.IconRightVisible = false;
            this.btnAddStocks.IconRightZoom = 0D;
            this.btnAddStocks.IconVisible = false;
            this.btnAddStocks.IconZoom = 90D;
            this.btnAddStocks.IsTab = false;
            this.btnAddStocks.Location = new System.Drawing.Point(754, 185);
            this.btnAddStocks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAddStocks.Name = "btnAddStocks";
            this.btnAddStocks.Normalcolor = System.Drawing.Color.Orange;
            this.btnAddStocks.OnHovercolor = System.Drawing.Color.Gold;
            this.btnAddStocks.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnAddStocks.selected = false;
            this.btnAddStocks.Size = new System.Drawing.Size(298, 48);
            this.btnAddStocks.TabIndex = 49;
            this.btnAddStocks.Text = "Add Stocks";
            this.btnAddStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddStocks.Textcolor = System.Drawing.Color.Black;
            this.btnAddStocks.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStocks.Click += new System.EventHandler(this.btnAddStocks_Click);
            // 
            // btnDeleteStocks
            // 
            this.btnDeleteStocks.Activecolor = System.Drawing.Color.Gray;
            this.btnDeleteStocks.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteStocks.BorderRadius = 0;
            this.btnDeleteStocks.ButtonText = "Delete";
            this.btnDeleteStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteStocks.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeleteStocks.Enabled = false;
            this.btnDeleteStocks.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteStocks.Iconimage = null;
            this.btnDeleteStocks.Iconimage_right = null;
            this.btnDeleteStocks.Iconimage_right_Selected = null;
            this.btnDeleteStocks.Iconimage_Selected = null;
            this.btnDeleteStocks.IconMarginLeft = 0;
            this.btnDeleteStocks.IconMarginRight = 0;
            this.btnDeleteStocks.IconRightVisible = false;
            this.btnDeleteStocks.IconRightZoom = 0D;
            this.btnDeleteStocks.IconVisible = false;
            this.btnDeleteStocks.IconZoom = 90D;
            this.btnDeleteStocks.IsTab = false;
            this.btnDeleteStocks.Location = new System.Drawing.Point(754, 301);
            this.btnDeleteStocks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteStocks.Name = "btnDeleteStocks";
            this.btnDeleteStocks.Normalcolor = System.Drawing.Color.Gray;
            this.btnDeleteStocks.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteStocks.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDeleteStocks.selected = false;
            this.btnDeleteStocks.Size = new System.Drawing.Size(298, 48);
            this.btnDeleteStocks.TabIndex = 48;
            this.btnDeleteStocks.Text = "Delete";
            this.btnDeleteStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteStocks.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteStocks.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStocks.Click += new System.EventHandler(this.btnDeleteStocks_Click);
            // 
            // dataGridViewStocksTab2
            // 
            this.dataGridViewStocksTab2.AllowUserToAddRows = false;
            this.dataGridViewStocksTab2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewStocksTab2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStocksTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStocksTab2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStocksTab2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewStocksTab2.Location = new System.Drawing.Point(21, 97);
            this.dataGridViewStocksTab2.MultiSelect = false;
            this.dataGridViewStocksTab2.Name = "dataGridViewStocksTab2";
            this.dataGridViewStocksTab2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStocksTab2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewStocksTab2.RowHeadersVisible = false;
            this.dataGridViewStocksTab2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewStocksTab2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStocksTab2.Size = new System.Drawing.Size(693, 538);
            this.dataGridViewStocksTab2.TabIndex = 48;
            this.dataGridViewStocksTab2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewStocksTab2_ColumnHeaderMouseClick);
            // 
            // btnUpdateStocks
            // 
            this.btnUpdateStocks.Activecolor = System.Drawing.Color.Orange;
            this.btnUpdateStocks.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateStocks.BorderRadius = 0;
            this.btnUpdateStocks.ButtonText = "Update Stocks";
            this.btnUpdateStocks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStocks.DisabledColor = System.Drawing.Color.Gray;
            this.btnUpdateStocks.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStocks.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUpdateStocks.Iconimage = null;
            this.btnUpdateStocks.Iconimage_right = null;
            this.btnUpdateStocks.Iconimage_right_Selected = null;
            this.btnUpdateStocks.Iconimage_Selected = null;
            this.btnUpdateStocks.IconMarginLeft = 0;
            this.btnUpdateStocks.IconMarginRight = 0;
            this.btnUpdateStocks.IconRightVisible = false;
            this.btnUpdateStocks.IconRightZoom = 0D;
            this.btnUpdateStocks.IconVisible = false;
            this.btnUpdateStocks.IconZoom = 90D;
            this.btnUpdateStocks.IsTab = false;
            this.btnUpdateStocks.Location = new System.Drawing.Point(754, 243);
            this.btnUpdateStocks.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUpdateStocks.Name = "btnUpdateStocks";
            this.btnUpdateStocks.Normalcolor = System.Drawing.Color.Orange;
            this.btnUpdateStocks.OnHovercolor = System.Drawing.Color.Gold;
            this.btnUpdateStocks.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnUpdateStocks.selected = false;
            this.btnUpdateStocks.Size = new System.Drawing.Size(298, 48);
            this.btnUpdateStocks.TabIndex = 47;
            this.btnUpdateStocks.Text = "Update Stocks";
            this.btnUpdateStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateStocks.Textcolor = System.Drawing.Color.Black;
            this.btnUpdateStocks.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStocks.Click += new System.EventHandler(this.btnUpdateStocks_Click);
            // 
            // StocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 770);
            this.Controls.Add(this.tabControlProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StocksForm";
            this.Text = "StocksForm";
            this.Load += new System.EventHandler(this.StocksForm_Load);
            this.tabControlProducts.ResumeLayout(false);
            this.tabPage1Products.ResumeLayout(false);
            this.tabPage1Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.tabPage2Stocks.ResumeLayout(false);
            this.tabPage2Stocks.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelIndividualStocks.ResumeLayout(false);
            this.panelIndividualStocks.PerformLayout();
            this.panelTotalStocks.ResumeLayout(false);
            this.panelTotalStocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocksTab2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControlProducts;
        private System.Windows.Forms.TabPage tabPage1Products;
        private System.Windows.Forms.Label lblSearch;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSearchValue;
        private Bunifu.Framework.UI.BunifuFlatButton btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdate;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private System.Windows.Forms.TabPage tabPage2Stocks;
        private System.Windows.Forms.Label lblNumberOfItemsValue;
        private System.Windows.Forms.Label lblNumberOfItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSearchTab2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSearchTab2;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddStocks;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteStocks;
        private System.Windows.Forms.DataGridView dataGridViewStocksTab2;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdateStocks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboBoxStocksStatus;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchStocks;
        private System.Windows.Forms.Label lblTotalNumberOfStocksValue;
        private System.Windows.Forms.Label lblTotalNumberOFStocks;
        private System.Windows.Forms.Label lblStocks;
        private System.Windows.Forms.ComboBox comboBoxStocks;
        private System.Windows.Forms.Panel panelIndividualStocks;
        private System.Windows.Forms.Label lblIndividualExpiredValue;
        private System.Windows.Forms.Label lblIndividualNearlyExpiredValue;
        private System.Windows.Forms.Label lblIndividualExpired;
        private System.Windows.Forms.Label lblIndividualNearlyExpired;
        private System.Windows.Forms.Label lblIndividualNearlyExpiredColor;
        private System.Windows.Forms.Label lblIndividualExpiredColor;
        private System.Windows.Forms.Panel panelTotalStocks;
        private System.Windows.Forms.Label lblTotalOutOfStocksValue;
        private System.Windows.Forms.Label lblTotalLowinStocksValue;
        private System.Windows.Forms.Label lblLowinStocks;
        private System.Windows.Forms.Label lblTotalColorOutofStocks;
        private System.Windows.Forms.Label lblTotalOutOfStocks;
        private System.Windows.Forms.Label lblTotalColorLowinStocks;
        private System.Windows.Forms.Label lblNumberOfProductsValue;
        private System.Windows.Forms.Label lblNumberOfProducts;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchDeleteTotalStocks;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteTotalStocks;
        private System.Windows.Forms.Label lblStatusForProductActiveOrNot;
        private System.Windows.Forms.ComboBox comboBoxProductStatusActiveOrNot;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchbtnDeleteProductInDB;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteProductInDB;
        private Bunifu.Framework.UI.BunifuFlatButton btnPrint;
        private Bunifu.Framework.UI.BunifuFlatButton btnPrintStocks;
    }
}