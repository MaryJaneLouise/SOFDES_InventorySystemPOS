namespace POSWithInventorySystem
{
    partial class SalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNumberOfProductsTransactions = new System.Windows.Forms.Label();
            this.lblNumberOfProductsTransactionsValue = new System.Windows.Forms.Label();
            this.dvgProductsTransaction = new System.Windows.Forms.DataGridView();
            this.lblTotalDiscountValue = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.btnPrint = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalProfitSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalProfitSales = new System.Windows.Forms.Label();
            this.comboBoxTransactionOrProducts = new System.Windows.Forms.ComboBox();
            this.lblNumberOfTransaction = new System.Windows.Forms.Label();
            this.txtSearchBy = new System.Windows.Forms.Label();
            this.dvgTransactions = new System.Windows.Forms.DataGridView();
            this.lblNumberOFTransactionValue = new System.Windows.Forms.Label();
            this.groupBoxSelectDate = new System.Windows.Forms.GroupBox();
            this.bunifuDatepickerToSales2 = new Bunifu.Framework.UI.BunifuDatepicker();
            this.bunifuDatepickerFromSales1 = new Bunifu.Framework.UI.BunifuDatepicker();
            this.bunifuSwitchToDatepicker = new Bunifu.Framework.UI.BunifuSwitch();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnDailySales = new System.Windows.Forms.Button();
            this.btnWeeklySales = new System.Windows.Forms.Button();
            this.btnMonthlySales = new System.Windows.Forms.Button();
            this.btnAnuallySales = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductsTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransactions)).BeginInit();
            this.groupBoxSelectDate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumberOfProductsTransactions
            // 
            this.lblNumberOfProductsTransactions.AutoSize = true;
            this.lblNumberOfProductsTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblNumberOfProductsTransactions.Location = new System.Drawing.Point(12, 650);
            this.lblNumberOfProductsTransactions.Name = "lblNumberOfProductsTransactions";
            this.lblNumberOfProductsTransactions.Size = new System.Drawing.Size(174, 22);
            this.lblNumberOfProductsTransactions.TabIndex = 83;
            this.lblNumberOfProductsTransactions.Text = "Number of Products:";
            // 
            // lblNumberOfProductsTransactionsValue
            // 
            this.lblNumberOfProductsTransactionsValue.AutoSize = true;
            this.lblNumberOfProductsTransactionsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblNumberOfProductsTransactionsValue.Location = new System.Drawing.Point(190, 650);
            this.lblNumberOfProductsTransactionsValue.Name = "lblNumberOfProductsTransactionsValue";
            this.lblNumberOfProductsTransactionsValue.Size = new System.Drawing.Size(20, 22);
            this.lblNumberOfProductsTransactionsValue.TabIndex = 84;
            this.lblNumberOfProductsTransactionsValue.Text = "0";
            // 
            // dvgProductsTransaction
            // 
            this.dvgProductsTransaction.AllowUserToAddRows = false;
            this.dvgProductsTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dvgProductsTransaction.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgProductsTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgProductsTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgProductsTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgProductsTransaction.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dvgProductsTransaction.Location = new System.Drawing.Point(12, 12);
            this.dvgProductsTransaction.MultiSelect = false;
            this.dvgProductsTransaction.Name = "dvgProductsTransaction";
            this.dvgProductsTransaction.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgProductsTransaction.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgProductsTransaction.RowHeadersVisible = false;
            this.dvgProductsTransaction.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvgProductsTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProductsTransaction.Size = new System.Drawing.Size(803, 621);
            this.dvgProductsTransaction.TabIndex = 82;
            // 
            // lblTotalDiscountValue
            // 
            this.lblTotalDiscountValue.AutoSize = true;
            this.lblTotalDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalDiscountValue.Location = new System.Drawing.Point(22, 105);
            this.lblTotalDiscountValue.Name = "lblTotalDiscountValue";
            this.lblTotalDiscountValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalDiscountValue.TabIndex = 83;
            this.lblTotalDiscountValue.Text = "0";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTotalDiscount.Location = new System.Drawing.Point(18, 83);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(131, 22);
            this.lblTotalDiscount.TabIndex = 82;
            this.lblTotalDiscount.Text = "Total Discount:";
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
            this.btnPrint.Location = new System.Drawing.Point(170, 156);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Normalcolor = System.Drawing.Color.Orange;
            this.btnPrint.OnHovercolor = System.Drawing.Color.Gold;
            this.btnPrint.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnPrint.selected = false;
            this.btnPrint.Size = new System.Drawing.Size(77, 27);
            this.btnPrint.TabIndex = 61;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Textcolor = System.Drawing.Color.Black;
            this.btnPrint.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.AutoSize = true;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalSalesValue.Location = new System.Drawing.Point(22, 51);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalSalesValue.TabIndex = 80;
            this.lblTotalSalesValue.Text = "0";
            // 
            // lblTotalProfitSalesValue
            // 
            this.lblTotalProfitSalesValue.AutoSize = true;
            this.lblTotalProfitSalesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTotalProfitSalesValue.Location = new System.Drawing.Point(22, 158);
            this.lblTotalProfitSalesValue.Name = "lblTotalProfitSalesValue";
            this.lblTotalProfitSalesValue.Size = new System.Drawing.Size(23, 25);
            this.lblTotalProfitSalesValue.TabIndex = 79;
            this.lblTotalProfitSalesValue.Text = "0";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTotalSales.Location = new System.Drawing.Point(17, 27);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(106, 22);
            this.lblTotalSales.TabIndex = 76;
            this.lblTotalSales.Text = "Total Sales:";
            // 
            // lblTotalProfitSales
            // 
            this.lblTotalProfitSales.AutoSize = true;
            this.lblTotalProfitSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTotalProfitSales.Location = new System.Drawing.Point(18, 136);
            this.lblTotalProfitSales.Name = "lblTotalProfitSales";
            this.lblTotalProfitSales.Size = new System.Drawing.Size(153, 22);
            this.lblTotalProfitSales.TabIndex = 72;
            this.lblTotalProfitSales.Text = "Total Profit Sales:";
            // 
            // comboBoxTransactionOrProducts
            // 
            this.comboBoxTransactionOrProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransactionOrProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBoxTransactionOrProducts.FormattingEnabled = true;
            this.comboBoxTransactionOrProducts.Items.AddRange(new object[] {
            "Transactions Sales",
            "Product Sales"});
            this.comboBoxTransactionOrProducts.Location = new System.Drawing.Point(839, 32);
            this.comboBoxTransactionOrProducts.Name = "comboBoxTransactionOrProducts";
            this.comboBoxTransactionOrProducts.Size = new System.Drawing.Size(254, 33);
            this.comboBoxTransactionOrProducts.TabIndex = 60;
            this.comboBoxTransactionOrProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransactionOrProducts_SelectedIndexChanged);
            // 
            // lblNumberOfTransaction
            // 
            this.lblNumberOfTransaction.AutoSize = true;
            this.lblNumberOfTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblNumberOfTransaction.Location = new System.Drawing.Point(12, 650);
            this.lblNumberOfTransaction.Name = "lblNumberOfTransaction";
            this.lblNumberOfTransaction.Size = new System.Drawing.Size(198, 22);
            this.lblNumberOfTransaction.TabIndex = 74;
            this.lblNumberOfTransaction.Text = "Number of Transaction:";
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.AutoSize = true;
            this.txtSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchBy.Location = new System.Drawing.Point(835, 9);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(84, 20);
            this.txtSearchBy.TabIndex = 59;
            this.txtSearchBy.Text = "Search by:";
            this.txtSearchBy.Click += new System.EventHandler(this.txtSearchBy_Click);
            // 
            // dvgTransactions
            // 
            this.dvgTransactions.AllowUserToAddRows = false;
            this.dvgTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dvgTransactions.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgTransactions.DefaultCellStyle = dataGridViewCellStyle5;
            this.dvgTransactions.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dvgTransactions.Location = new System.Drawing.Point(12, 12);
            this.dvgTransactions.MultiSelect = false;
            this.dvgTransactions.Name = "dvgTransactions";
            this.dvgTransactions.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dvgTransactions.RowHeadersVisible = false;
            this.dvgTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvgTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgTransactions.Size = new System.Drawing.Size(803, 621);
            this.dvgTransactions.TabIndex = 71;
            // 
            // lblNumberOFTransactionValue
            // 
            this.lblNumberOFTransactionValue.AutoSize = true;
            this.lblNumberOFTransactionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblNumberOFTransactionValue.Location = new System.Drawing.Point(207, 650);
            this.lblNumberOFTransactionValue.Name = "lblNumberOFTransactionValue";
            this.lblNumberOFTransactionValue.Size = new System.Drawing.Size(30, 22);
            this.lblNumberOFTransactionValue.TabIndex = 75;
            this.lblNumberOFTransactionValue.Text = "56";
            // 
            // groupBoxSelectDate
            // 
            this.groupBoxSelectDate.Controls.Add(this.bunifuDatepickerToSales2);
            this.groupBoxSelectDate.Controls.Add(this.bunifuDatepickerFromSales1);
            this.groupBoxSelectDate.Controls.Add(this.bunifuSwitchToDatepicker);
            this.groupBoxSelectDate.Controls.Add(this.lblTo);
            this.groupBoxSelectDate.Controls.Add(this.lblFrom);
            this.groupBoxSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxSelectDate.Location = new System.Drawing.Point(839, 309);
            this.groupBoxSelectDate.Name = "groupBoxSelectDate";
            this.groupBoxSelectDate.Size = new System.Drawing.Size(254, 188);
            this.groupBoxSelectDate.TabIndex = 76;
            this.groupBoxSelectDate.TabStop = false;
            this.groupBoxSelectDate.Text = "Custom Date Selection";
            // 
            // bunifuDatepickerToSales2
            // 
            this.bunifuDatepickerToSales2.BackColor = System.Drawing.Color.Silver;
            this.bunifuDatepickerToSales2.BorderRadius = 0;
            this.bunifuDatepickerToSales2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuDatepickerToSales2.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatepickerToSales2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatepickerToSales2.FormatCustom = "                     MM-dd-yyyy";
            this.bunifuDatepickerToSales2.Location = new System.Drawing.Point(18, 139);
            this.bunifuDatepickerToSales2.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuDatepickerToSales2.Name = "bunifuDatepickerToSales2";
            this.bunifuDatepickerToSales2.Size = new System.Drawing.Size(219, 36);
            this.bunifuDatepickerToSales2.TabIndex = 68;
            this.bunifuDatepickerToSales2.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.bunifuDatepickerToSales2.onValueChanged += new System.EventHandler(this.bunifuDatepickerToSales2_onValueChanged);
            // 
            // bunifuDatepickerFromSales1
            // 
            this.bunifuDatepickerFromSales1.BackColor = System.Drawing.Color.Silver;
            this.bunifuDatepickerFromSales1.BorderRadius = 0;
            this.bunifuDatepickerFromSales1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuDatepickerFromSales1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatepickerFromSales1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatepickerFromSales1.FormatCustom = "                     MM-dd-yyyy";
            this.bunifuDatepickerFromSales1.Location = new System.Drawing.Point(18, 59);
            this.bunifuDatepickerFromSales1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuDatepickerFromSales1.Name = "bunifuDatepickerFromSales1";
            this.bunifuDatepickerFromSales1.Size = new System.Drawing.Size(219, 36);
            this.bunifuDatepickerFromSales1.TabIndex = 67;
            this.bunifuDatepickerFromSales1.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.bunifuDatepickerFromSales1.onValueChanged += new System.EventHandler(this.bunifuDatepickerFromSales1_onValueChanged);
            // 
            // bunifuSwitchToDatepicker
            // 
            this.bunifuSwitchToDatepicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitchToDatepicker.BorderRadius = 0;
            this.bunifuSwitchToDatepicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchToDatepicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchToDatepicker.Location = new System.Drawing.Point(186, 27);
            this.bunifuSwitchToDatepicker.Margin = new System.Windows.Forms.Padding(8);
            this.bunifuSwitchToDatepicker.Name = "bunifuSwitchToDatepicker";
            this.bunifuSwitchToDatepicker.Oncolor = System.Drawing.Color.Orange;
            this.bunifuSwitchToDatepicker.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitchToDatepicker.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitchToDatepicker.TabIndex = 66;
            this.bunifuSwitchToDatepicker.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitchToDatepicker.Value = true;
            this.bunifuSwitchToDatepicker.Click += new System.EventHandler(this.bunifuSwitchToDatepicker_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTo.Location = new System.Drawing.Point(13, 112);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(32, 22);
            this.lblTo.TabIndex = 63;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblFrom.Location = new System.Drawing.Point(14, 32);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(51, 22);
            this.lblFrom.TabIndex = 61;
            this.lblFrom.Text = "From";
            // 
            // btnDailySales
            // 
            this.btnDailySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnDailySales.Location = new System.Drawing.Point(839, 78);
            this.btnDailySales.Name = "btnDailySales";
            this.btnDailySales.Size = new System.Drawing.Size(254, 49);
            this.btnDailySales.TabIndex = 85;
            this.btnDailySales.Text = "Daily Sales";
            this.btnDailySales.UseVisualStyleBackColor = true;
            this.btnDailySales.Click += new System.EventHandler(this.btnDailySales_Click);
            // 
            // btnWeeklySales
            // 
            this.btnWeeklySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnWeeklySales.Location = new System.Drawing.Point(839, 133);
            this.btnWeeklySales.Name = "btnWeeklySales";
            this.btnWeeklySales.Size = new System.Drawing.Size(254, 49);
            this.btnWeeklySales.TabIndex = 86;
            this.btnWeeklySales.Text = "Weekly Sales";
            this.btnWeeklySales.UseVisualStyleBackColor = true;
            this.btnWeeklySales.Click += new System.EventHandler(this.btnWeeklySales_Click);
            // 
            // btnMonthlySales
            // 
            this.btnMonthlySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnMonthlySales.Location = new System.Drawing.Point(839, 188);
            this.btnMonthlySales.Name = "btnMonthlySales";
            this.btnMonthlySales.Size = new System.Drawing.Size(254, 49);
            this.btnMonthlySales.TabIndex = 87;
            this.btnMonthlySales.Text = "Monthly Sales";
            this.btnMonthlySales.UseVisualStyleBackColor = true;
            this.btnMonthlySales.Click += new System.EventHandler(this.btnMonthlySales_Click);
            // 
            // btnAnuallySales
            // 
            this.btnAnuallySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAnuallySales.Location = new System.Drawing.Point(839, 243);
            this.btnAnuallySales.Name = "btnAnuallySales";
            this.btnAnuallySales.Size = new System.Drawing.Size(254, 49);
            this.btnAnuallySales.TabIndex = 88;
            this.btnAnuallySales.Text = "Annual Sales";
            this.btnAnuallySales.UseVisualStyleBackColor = true;
            this.btnAnuallySales.Click += new System.EventHandler(this.btnAnuallySales_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalSales);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.lblTotalDiscountValue);
            this.groupBox1.Controls.Add(this.lblTotalProfitSales);
            this.groupBox1.Controls.Add(this.lblTotalProfitSalesValue);
            this.groupBox1.Controls.Add(this.lblTotalSalesValue);
            this.groupBox1.Controls.Add(this.lblTotalDiscount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(839, 503);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 191);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Information";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 706);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnuallySales);
            this.Controls.Add(this.btnMonthlySales);
            this.Controls.Add(this.btnWeeklySales);
            this.Controls.Add(this.btnDailySales);
            this.Controls.Add(this.lblNumberOfProductsTransactions);
            this.Controls.Add(this.lblNumberOfProductsTransactionsValue);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.comboBoxTransactionOrProducts);
            this.Controls.Add(this.lblNumberOfTransaction);
            this.Controls.Add(this.groupBoxSelectDate);
            this.Controls.Add(this.dvgTransactions);
            this.Controls.Add(this.lblNumberOFTransactionValue);
            this.Controls.Add(this.dvgProductsTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "SalesForm";
            this.Text = "SalesForm";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductsTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransactions)).EndInit();
            this.groupBoxSelectDate.ResumeLayout(false);
            this.groupBoxSelectDate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalProfitSales;
        private System.Windows.Forms.ComboBox comboBoxTransactionOrProducts;
        private System.Windows.Forms.Label txtSearchBy;
        private System.Windows.Forms.Label lblNumberOfTransaction;
        private System.Windows.Forms.DataGridView dvgTransactions;
        private System.Windows.Forms.GroupBox groupBoxSelectDate;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitchToDatepicker;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTotalProfitSalesValue;
        private System.Windows.Forms.Label lblNumberOFTransactionValue;
        private Bunifu.Framework.UI.BunifuDatepicker bunifuDatepickerToSales2;
        private Bunifu.Framework.UI.BunifuDatepicker bunifuDatepickerFromSales1;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.DataGridView dvgProductsTransaction;
        private System.Windows.Forms.Label lblNumberOfProductsTransactions;
        private System.Windows.Forms.Label lblNumberOfProductsTransactionsValue;
        private Bunifu.Framework.UI.BunifuFlatButton btnPrint;
        private System.Windows.Forms.Label lblTotalDiscountValue;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Button btnDailySales;
        private System.Windows.Forms.Button btnWeeklySales;
        private System.Windows.Forms.Button btnMonthlySales;
        private System.Windows.Forms.Button btnAnuallySales;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}