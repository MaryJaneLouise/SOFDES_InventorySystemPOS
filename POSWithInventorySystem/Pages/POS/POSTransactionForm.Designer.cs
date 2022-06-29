namespace POSWithInventorySystem
{
    partial class POSTransactionForm
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSTransactionForm));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTransactionInFo = new System.Windows.Forms.Panel();
            this.groupBoxTransactionInformation = new System.Windows.Forms.GroupBox();
            this.lblVatValue = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblChangeValue = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblAmountPaymentValue = new System.Windows.Forms.Label();
            this.lblAmountPayment = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnPayment = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnVoid = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNewTransaction = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCancelTransaction = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelNewTransaction = new System.Windows.Forms.Panel();
            this.lblNewTransaction = new System.Windows.Forms.Label();
            this.timerNewTransaction = new System.Windows.Forms.Timer(this.components);
            this.btnDiscount = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panelDiscount = new System.Windows.Forms.Panel();
            this.groupBoxDiscount = new System.Windows.Forms.GroupBox();
            this.comboBoxDiscount = new System.Windows.Forms.ComboBox();
            this.btnDiscountClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDiscountOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDiscountCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.btnAddQuantity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition3 = new BunifuAnimatorNS.BunifuTransition(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTransactionInFo.SuspendLayout();
            this.groupBoxTransactionInformation.SuspendLayout();
            this.panelNewTransaction.SuspendLayout();
            this.panelDiscount.SuspendLayout();
            this.groupBoxDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDiscountClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.bunifuTransition3.SetDecoration(this.txtSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.txtSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.txtSearch, BunifuAnimatorNS.DecorationType.None);
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearch.Location = new System.Drawing.Point(28, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1053, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.AllowUserToResizeColumns = false;
            this.dataGridViewItems.AllowUserToResizeRows = false;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.ProductName,
            this.Quantity,
            this.Price,
            this.Amount});
            this.bunifuTransition2.SetDecoration(this.dataGridViewItems, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.dataGridViewItems, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.dataGridViewItems, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewItems.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewItems.Location = new System.Drawing.Point(28, 61);
            this.dataGridViewItems.MultiSelect = false;
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewItems.RowHeadersVisible = false;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(739, 633);
            this.dataGridViewItems.TabIndex = 2;
            // 
            // Code
            // 
            this.Code.HeaderText = "      Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "         Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "      Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "    Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblSearch, BunifuAnimatorNS.DecorationType.None);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSearch.Location = new System.Drawing.Point(31, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(141, 21);
            this.lblSearch.TabIndex = 31;
            this.lblSearch.Text = "Search by Barcode:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.panelTransactionInFo);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(773, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 332);
            this.panel1.TabIndex = 32;
            // 
            // panelTransactionInFo
            // 
            this.panelTransactionInFo.BackColor = System.Drawing.Color.Teal;
            this.panelTransactionInFo.Controls.Add(this.groupBoxTransactionInformation);
            this.bunifuTransition1.SetDecoration(this.panelTransactionInFo, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panelTransactionInFo, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.panelTransactionInFo, BunifuAnimatorNS.DecorationType.None);
            this.panelTransactionInFo.Location = new System.Drawing.Point(0, 0);
            this.panelTransactionInFo.Name = "panelTransactionInFo";
            this.panelTransactionInFo.Size = new System.Drawing.Size(307, 329);
            this.panelTransactionInFo.TabIndex = 34;
            // 
            // groupBoxTransactionInformation
            // 
            this.groupBoxTransactionInformation.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTransactionInformation.Controls.Add(this.lblVatValue);
            this.groupBoxTransactionInformation.Controls.Add(this.lblVat);
            this.groupBoxTransactionInformation.Controls.Add(this.lblSubTotalValue);
            this.groupBoxTransactionInformation.Controls.Add(this.lblSubTotal);
            this.groupBoxTransactionInformation.Controls.Add(this.lblChangeValue);
            this.groupBoxTransactionInformation.Controls.Add(this.lblChange);
            this.groupBoxTransactionInformation.Controls.Add(this.lblAmountPaymentValue);
            this.groupBoxTransactionInformation.Controls.Add(this.lblAmountPayment);
            this.groupBoxTransactionInformation.Controls.Add(this.lblTotalAmountValue);
            this.groupBoxTransactionInformation.Controls.Add(this.lblTotalAmount);
            this.bunifuTransition1.SetDecoration(this.groupBoxTransactionInformation, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.groupBoxTransactionInformation, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.groupBoxTransactionInformation, BunifuAnimatorNS.DecorationType.None);
            this.groupBoxTransactionInformation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxTransactionInformation.ForeColor = System.Drawing.Color.White;
            this.groupBoxTransactionInformation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTransactionInformation.Name = "groupBoxTransactionInformation";
            this.groupBoxTransactionInformation.Size = new System.Drawing.Size(301, 323);
            this.groupBoxTransactionInformation.TabIndex = 34;
            this.groupBoxTransactionInformation.TabStop = false;
            this.groupBoxTransactionInformation.Text = "Transaction Information";
            // 
            // lblVatValue
            // 
            this.lblVatValue.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.lblVatValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblVatValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblVatValue, BunifuAnimatorNS.DecorationType.None);
            this.lblVatValue.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblVatValue.Location = new System.Drawing.Point(7, 42);
            this.lblVatValue.Name = "lblVatValue";
            this.lblVatValue.Size = new System.Drawing.Size(288, 27);
            this.lblVatValue.TabIndex = 17;
            this.lblVatValue.Text = "0";
            this.lblVatValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblVat, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblVat, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblVat, BunifuAnimatorNS.DecorationType.None);
            this.lblVat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVat.Location = new System.Drawing.Point(6, 21);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(141, 21);
            this.lblVat.TabIndex = 16;
            this.lblVat.Text = "Value Added Tax:";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.lblSubTotalValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblSubTotalValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblSubTotalValue, BunifuAnimatorNS.DecorationType.None);
            this.lblSubTotalValue.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblSubTotalValue.Location = new System.Drawing.Point(6, 100);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(288, 27);
            this.lblSubTotalValue.TabIndex = 15;
            this.lblSubTotalValue.Text = "0";
            this.lblSubTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblSubTotal, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblSubTotal, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblSubTotal, BunifuAnimatorNS.DecorationType.None);
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.Location = new System.Drawing.Point(4, 75);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(79, 21);
            this.lblSubTotal.TabIndex = 14;
            this.lblSubTotal.Text = "Subtotal:";
            // 
            // lblChangeValue
            // 
            this.lblChangeValue.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.lblChangeValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblChangeValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblChangeValue, BunifuAnimatorNS.DecorationType.None);
            this.lblChangeValue.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblChangeValue.Location = new System.Drawing.Point(5, 283);
            this.lblChangeValue.Name = "lblChangeValue";
            this.lblChangeValue.Size = new System.Drawing.Size(290, 33);
            this.lblChangeValue.TabIndex = 10;
            this.lblChangeValue.Text = "0";
            this.lblChangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblChange, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblChange, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblChange, BunifuAnimatorNS.DecorationType.None);
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(3, 258);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(81, 25);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "Change:";
            // 
            // lblAmountPaymentValue
            // 
            this.lblAmountPaymentValue.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.lblAmountPaymentValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblAmountPaymentValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblAmountPaymentValue, BunifuAnimatorNS.DecorationType.None);
            this.lblAmountPaymentValue.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblAmountPaymentValue.Location = new System.Drawing.Point(7, 218);
            this.lblAmountPaymentValue.Name = "lblAmountPaymentValue";
            this.lblAmountPaymentValue.Size = new System.Drawing.Size(288, 33);
            this.lblAmountPaymentValue.TabIndex = 8;
            this.lblAmountPaymentValue.Text = "0";
            this.lblAmountPaymentValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmountPayment
            // 
            this.lblAmountPayment.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblAmountPayment, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblAmountPayment, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblAmountPayment, BunifuAnimatorNS.DecorationType.None);
            this.lblAmountPayment.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAmountPayment.Location = new System.Drawing.Point(4, 193);
            this.lblAmountPayment.Name = "lblAmountPayment";
            this.lblAmountPayment.Size = new System.Drawing.Size(86, 25);
            this.lblAmountPayment.TabIndex = 7;
            this.lblAmountPayment.Text = "Amount:";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.lblTotalAmountValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblTotalAmountValue, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblTotalAmountValue, BunifuAnimatorNS.DecorationType.None);
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblTotalAmountValue.Location = new System.Drawing.Point(7, 155);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(288, 33);
            this.lblTotalAmountValue.TabIndex = 6;
            this.lblTotalAmountValue.Text = "0";
            this.lblTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblTotalAmount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblTotalAmount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblTotalAmount, BunifuAnimatorNS.DecorationType.None);
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(2, 130);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(133, 25);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // btnPayment
            // 
            this.btnPayment.Activecolor = System.Drawing.Color.Teal;
            this.btnPayment.BackColor = System.Drawing.Color.Teal;
            this.btnPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPayment.BorderRadius = 5;
            this.btnPayment.ButtonText = "Payment [F5]";
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnPayment, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnPayment, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnPayment, BunifuAnimatorNS.DecorationType.None);
            this.btnPayment.DisabledColor = System.Drawing.Color.DimGray;
            this.btnPayment.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPayment.Iconimage = null;
            this.btnPayment.Iconimage_right = null;
            this.btnPayment.Iconimage_right_Selected = null;
            this.btnPayment.Iconimage_Selected = null;
            this.btnPayment.IconMarginLeft = 0;
            this.btnPayment.IconMarginRight = 0;
            this.btnPayment.IconRightVisible = false;
            this.btnPayment.IconRightZoom = 0D;
            this.btnPayment.IconVisible = false;
            this.btnPayment.IconZoom = 90D;
            this.btnPayment.IsTab = false;
            this.btnPayment.Location = new System.Drawing.Point(773, 409);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Normalcolor = System.Drawing.Color.Teal;
            this.btnPayment.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnPayment.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPayment.selected = false;
            this.btnPayment.Size = new System.Drawing.Size(307, 51);
            this.btnPayment.TabIndex = 33;
            this.btnPayment.Text = "Payment [F5]";
            this.btnPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPayment.Textcolor = System.Drawing.Color.White;
            this.btnPayment.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.Activecolor = System.Drawing.Color.Teal;
            this.btnVoid.BackColor = System.Drawing.Color.Teal;
            this.btnVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoid.BorderRadius = 5;
            this.btnVoid.ButtonText = "Void Item [F10]";
            this.btnVoid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnVoid, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnVoid, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnVoid, BunifuAnimatorNS.DecorationType.None);
            this.btnVoid.DisabledColor = System.Drawing.Color.DimGray;
            this.btnVoid.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVoid.Iconimage = null;
            this.btnVoid.Iconimage_right = null;
            this.btnVoid.Iconimage_right_Selected = null;
            this.btnVoid.Iconimage_Selected = null;
            this.btnVoid.IconMarginLeft = 0;
            this.btnVoid.IconMarginRight = 0;
            this.btnVoid.IconRightVisible = false;
            this.btnVoid.IconRightZoom = 0D;
            this.btnVoid.IconVisible = false;
            this.btnVoid.IconZoom = 90D;
            this.btnVoid.IsTab = false;
            this.btnVoid.Location = new System.Drawing.Point(773, 578);
            this.btnVoid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Normalcolor = System.Drawing.Color.Teal;
            this.btnVoid.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnVoid.OnHoverTextColor = System.Drawing.Color.White;
            this.btnVoid.selected = false;
            this.btnVoid.Size = new System.Drawing.Size(308, 50);
            this.btnVoid.TabIndex = 35;
            this.btnVoid.Text = "Void Item [F10]";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVoid.Textcolor = System.Drawing.Color.White;
            this.btnVoid.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.Activecolor = System.Drawing.Color.Silver;
            this.btnNewTransaction.BackColor = System.Drawing.Color.Silver;
            this.btnNewTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewTransaction.BorderRadius = 5;
            this.btnNewTransaction.ButtonText = "New Transaction [Esc]";
            this.btnNewTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.btnNewTransaction.DisabledColor = System.Drawing.Color.Gray;
            this.btnNewTransaction.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransaction.ForeColor = System.Drawing.Color.Black;
            this.btnNewTransaction.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNewTransaction.Iconimage = null;
            this.btnNewTransaction.Iconimage_right = null;
            this.btnNewTransaction.Iconimage_right_Selected = null;
            this.btnNewTransaction.Iconimage_Selected = null;
            this.btnNewTransaction.IconMarginLeft = 0;
            this.btnNewTransaction.IconMarginRight = 0;
            this.btnNewTransaction.IconRightVisible = false;
            this.btnNewTransaction.IconRightZoom = 0D;
            this.btnNewTransaction.IconVisible = false;
            this.btnNewTransaction.IconZoom = 90D;
            this.btnNewTransaction.IsTab = false;
            this.btnNewTransaction.Location = new System.Drawing.Point(773, 639);
            this.btnNewTransaction.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Normalcolor = System.Drawing.Color.Silver;
            this.btnNewTransaction.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNewTransaction.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnNewTransaction.selected = false;
            this.btnNewTransaction.Size = new System.Drawing.Size(151, 55);
            this.btnNewTransaction.TabIndex = 36;
            this.btnNewTransaction.Text = "New Transaction [Esc]";
            this.btnNewTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewTransaction.Textcolor = System.Drawing.Color.Black;
            this.btnNewTransaction.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // btnCancelTransaction
            // 
            this.btnCancelTransaction.Activecolor = System.Drawing.Color.Silver;
            this.btnCancelTransaction.BackColor = System.Drawing.Color.Silver;
            this.btnCancelTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelTransaction.BorderRadius = 5;
            this.btnCancelTransaction.ButtonText = "Cancel Transaction [F12]";
            this.btnCancelTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnCancelTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnCancelTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnCancelTransaction, BunifuAnimatorNS.DecorationType.None);
            this.btnCancelTransaction.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancelTransaction.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTransaction.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancelTransaction.Iconimage = null;
            this.btnCancelTransaction.Iconimage_right = null;
            this.btnCancelTransaction.Iconimage_right_Selected = null;
            this.btnCancelTransaction.Iconimage_Selected = null;
            this.btnCancelTransaction.IconMarginLeft = 0;
            this.btnCancelTransaction.IconMarginRight = 0;
            this.btnCancelTransaction.IconRightVisible = false;
            this.btnCancelTransaction.IconRightZoom = 0D;
            this.btnCancelTransaction.IconVisible = false;
            this.btnCancelTransaction.IconZoom = 90D;
            this.btnCancelTransaction.IsTab = false;
            this.btnCancelTransaction.Location = new System.Drawing.Point(930, 639);
            this.btnCancelTransaction.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancelTransaction.Name = "btnCancelTransaction";
            this.btnCancelTransaction.Normalcolor = System.Drawing.Color.Silver;
            this.btnCancelTransaction.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancelTransaction.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnCancelTransaction.selected = false;
            this.btnCancelTransaction.Size = new System.Drawing.Size(150, 55);
            this.btnCancelTransaction.TabIndex = 37;
            this.btnCancelTransaction.Text = "Cancel Transaction [F12]";
            this.btnCancelTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelTransaction.Textcolor = System.Drawing.Color.Black;
            this.btnCancelTransaction.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.btnCancelTransaction.Click += new System.EventHandler(this.btnCancelTransaction_Click);
            // 
            // panelNewTransaction
            // 
            this.panelNewTransaction.BackColor = System.Drawing.Color.Teal;
            this.panelNewTransaction.Controls.Add(this.lblNewTransaction);
            this.bunifuTransition1.SetDecoration(this.panelNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panelNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.panelNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.panelNewTransaction.ForeColor = System.Drawing.Color.White;
            this.panelNewTransaction.Location = new System.Drawing.Point(28, 314);
            this.panelNewTransaction.Name = "panelNewTransaction";
            this.panelNewTransaction.Size = new System.Drawing.Size(739, 85);
            this.panelNewTransaction.TabIndex = 38;
            // 
            // lblNewTransaction
            // 
            this.lblNewTransaction.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblNewTransaction, BunifuAnimatorNS.DecorationType.None);
            this.lblNewTransaction.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lblNewTransaction.Location = new System.Drawing.Point(187, 24);
            this.lblNewTransaction.Name = "lblNewTransaction";
            this.lblNewTransaction.Size = new System.Drawing.Size(368, 37);
            this.lblNewTransaction.TabIndex = 0;
            this.lblNewTransaction.Text = "Press Esc For New Transaction";
            // 
            // timerNewTransaction
            // 
            this.timerNewTransaction.Interval = 500;
            this.timerNewTransaction.Tick += new System.EventHandler(this.timerNewTransaction_Tick);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Activecolor = System.Drawing.Color.Teal;
            this.btnDiscount.BackColor = System.Drawing.Color.Teal;
            this.btnDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscount.BorderRadius = 5;
            this.btnDiscount.ButtonText = "Discount [F8]";
            this.btnDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnDiscount, BunifuAnimatorNS.DecorationType.None);
            this.btnDiscount.DisabledColor = System.Drawing.Color.DimGray;
            this.btnDiscount.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDiscount.Iconimage = null;
            this.btnDiscount.Iconimage_right = null;
            this.btnDiscount.Iconimage_right_Selected = null;
            this.btnDiscount.Iconimage_Selected = null;
            this.btnDiscount.IconMarginLeft = 0;
            this.btnDiscount.IconMarginRight = 0;
            this.btnDiscount.IconRightVisible = false;
            this.btnDiscount.IconRightZoom = 0D;
            this.btnDiscount.IconVisible = false;
            this.btnDiscount.IconZoom = 90D;
            this.btnDiscount.IsTab = false;
            this.btnDiscount.Location = new System.Drawing.Point(773, 467);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Normalcolor = System.Drawing.Color.Teal;
            this.btnDiscount.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnDiscount.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDiscount.selected = false;
            this.btnDiscount.Size = new System.Drawing.Size(307, 48);
            this.btnDiscount.TabIndex = 39;
            this.btnDiscount.Text = "Discount [F8]";
            this.btnDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDiscount.Textcolor = System.Drawing.Color.White;
            this.btnDiscount.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(30);
            animation2.RotateCoeff = 0.5F;
            animation2.RotateLimit = 0.2F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            // 
            // panelDiscount
            // 
            this.panelDiscount.BackColor = System.Drawing.Color.Teal;
            this.panelDiscount.BackgroundImage = global::POSWithInventorySystem.Properties.Resources.finalpic;
            this.panelDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDiscount.Controls.Add(this.groupBoxDiscount);
            this.bunifuTransition1.SetDecoration(this.panelDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panelDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.panelDiscount, BunifuAnimatorNS.DecorationType.None);
            this.panelDiscount.Location = new System.Drawing.Point(431, 391);
            this.panelDiscount.Name = "panelDiscount";
            this.panelDiscount.Size = new System.Drawing.Size(333, 176);
            this.panelDiscount.TabIndex = 40;
            // 
            // groupBoxDiscount
            // 
            this.groupBoxDiscount.BackColor = System.Drawing.Color.Teal;
            this.groupBoxDiscount.Controls.Add(this.comboBoxDiscount);
            this.groupBoxDiscount.Controls.Add(this.btnDiscountClose);
            this.groupBoxDiscount.Controls.Add(this.btnDiscountOk);
            this.groupBoxDiscount.Controls.Add(this.btnDiscountCancel);
            this.groupBoxDiscount.Controls.Add(this.lblDiscount);
            this.bunifuTransition1.SetDecoration(this.groupBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.groupBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.groupBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.groupBoxDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxDiscount.ForeColor = System.Drawing.Color.White;
            this.groupBoxDiscount.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDiscount.Name = "groupBoxDiscount";
            this.groupBoxDiscount.Size = new System.Drawing.Size(314, 176);
            this.groupBoxDiscount.TabIndex = 0;
            this.groupBoxDiscount.TabStop = false;
            this.groupBoxDiscount.Text = "Insert Discount";
            // 
            // comboBoxDiscount
            // 
            this.bunifuTransition2.SetDecoration(this.comboBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.comboBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.comboBoxDiscount, BunifuAnimatorNS.DecorationType.None);
            this.comboBoxDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.comboBoxDiscount.FormattingEnabled = true;
            this.comboBoxDiscount.Items.AddRange(new object[] {
            "20 %",
            "30 % ",
            "40 %",
            "50 %"});
            this.comboBoxDiscount.Location = new System.Drawing.Point(23, 63);
            this.comboBoxDiscount.Name = "comboBoxDiscount";
            this.comboBoxDiscount.Size = new System.Drawing.Size(263, 33);
            this.comboBoxDiscount.TabIndex = 59;
            // 
            // btnDiscountClose
            // 
            this.btnDiscountClose.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.btnDiscountClose, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnDiscountClose, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.btnDiscountClose, BunifuAnimatorNS.DecorationType.None);
            this.btnDiscountClose.Image = global::POSWithInventorySystem.Properties.Resources.round_close_white_48;
            this.btnDiscountClose.ImageActive = null;
            this.btnDiscountClose.Location = new System.Drawing.Point(271, 12);
            this.btnDiscountClose.Name = "btnDiscountClose";
            this.btnDiscountClose.Size = new System.Drawing.Size(30, 30);
            this.btnDiscountClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDiscountClose.TabIndex = 47;
            this.btnDiscountClose.TabStop = false;
            this.btnDiscountClose.Zoom = 10;
            this.btnDiscountClose.Click += new System.EventHandler(this.btnDiscountClose_Click);
            // 
            // btnDiscountOk
            // 
            this.btnDiscountOk.Activecolor = System.Drawing.Color.White;
            this.btnDiscountOk.BackColor = System.Drawing.Color.White;
            this.btnDiscountOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscountOk.BorderRadius = 5;
            this.btnDiscountOk.ButtonText = "Insert Discount";
            this.btnDiscountOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnDiscountOk, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnDiscountOk, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnDiscountOk, BunifuAnimatorNS.DecorationType.None);
            this.btnDiscountOk.DisabledColor = System.Drawing.Color.Gray;
            this.btnDiscountOk.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscountOk.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDiscountOk.Iconimage = null;
            this.btnDiscountOk.Iconimage_right = null;
            this.btnDiscountOk.Iconimage_right_Selected = null;
            this.btnDiscountOk.Iconimage_Selected = null;
            this.btnDiscountOk.IconMarginLeft = 0;
            this.btnDiscountOk.IconMarginRight = 0;
            this.btnDiscountOk.IconRightVisible = true;
            this.btnDiscountOk.IconRightZoom = 0D;
            this.btnDiscountOk.IconVisible = true;
            this.btnDiscountOk.IconZoom = 90D;
            this.btnDiscountOk.IsTab = false;
            this.btnDiscountOk.Location = new System.Drawing.Point(23, 121);
            this.btnDiscountOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDiscountOk.Name = "btnDiscountOk";
            this.btnDiscountOk.Normalcolor = System.Drawing.Color.White;
            this.btnDiscountOk.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnDiscountOk.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDiscountOk.selected = false;
            this.btnDiscountOk.Size = new System.Drawing.Size(118, 31);
            this.btnDiscountOk.TabIndex = 46;
            this.btnDiscountOk.Text = "Insert Discount";
            this.btnDiscountOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDiscountOk.Textcolor = System.Drawing.Color.Black;
            this.btnDiscountOk.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscountOk.Click += new System.EventHandler(this.btnDiscountOk_Click);
            // 
            // btnDiscountCancel
            // 
            this.btnDiscountCancel.Activecolor = System.Drawing.Color.Gray;
            this.btnDiscountCancel.BackColor = System.Drawing.Color.Silver;
            this.btnDiscountCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscountCancel.BorderRadius = 5;
            this.btnDiscountCancel.ButtonText = "Cancel";
            this.btnDiscountCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnDiscountCancel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnDiscountCancel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnDiscountCancel, BunifuAnimatorNS.DecorationType.None);
            this.btnDiscountCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnDiscountCancel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscountCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDiscountCancel.Iconimage = null;
            this.btnDiscountCancel.Iconimage_right = null;
            this.btnDiscountCancel.Iconimage_right_Selected = null;
            this.btnDiscountCancel.Iconimage_Selected = null;
            this.btnDiscountCancel.IconMarginLeft = 0;
            this.btnDiscountCancel.IconMarginRight = 0;
            this.btnDiscountCancel.IconRightVisible = true;
            this.btnDiscountCancel.IconRightZoom = 0D;
            this.btnDiscountCancel.IconVisible = true;
            this.btnDiscountCancel.IconZoom = 90D;
            this.btnDiscountCancel.IsTab = false;
            this.btnDiscountCancel.Location = new System.Drawing.Point(165, 121);
            this.btnDiscountCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDiscountCancel.Name = "btnDiscountCancel";
            this.btnDiscountCancel.Normalcolor = System.Drawing.Color.Silver;
            this.btnDiscountCancel.OnHovercolor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDiscountCancel.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDiscountCancel.selected = false;
            this.btnDiscountCancel.Size = new System.Drawing.Size(121, 31);
            this.btnDiscountCancel.TabIndex = 45;
            this.btnDiscountCancel.Text = "Cancel";
            this.btnDiscountCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDiscountCancel.Textcolor = System.Drawing.Color.Black;
            this.btnDiscountCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscountCancel.Click += new System.EventHandler(this.btnDiscountCancel_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.bunifuTransition3.SetDecoration(this.lblDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.lblDiscount, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.lblDiscount, BunifuAnimatorNS.DecorationType.None);
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.White;
            this.lblDiscount.Location = new System.Drawing.Point(18, 35);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(116, 25);
            this.lblDiscount.TabIndex = 41;
            this.lblDiscount.Text = "Percentage:";
            // 
            // btnAddQuantity
            // 
            this.btnAddQuantity.Activecolor = System.Drawing.Color.Teal;
            this.btnAddQuantity.BackColor = System.Drawing.Color.Teal;
            this.btnAddQuantity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddQuantity.BorderRadius = 5;
            this.btnAddQuantity.ButtonText = "Add Quantity [F9]";
            this.btnAddQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.btnAddQuantity, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.btnAddQuantity, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.btnAddQuantity, BunifuAnimatorNS.DecorationType.None);
            this.btnAddQuantity.DisabledColor = System.Drawing.Color.DimGray;
            this.btnAddQuantity.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuantity.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddQuantity.Iconimage = null;
            this.btnAddQuantity.Iconimage_right = null;
            this.btnAddQuantity.Iconimage_right_Selected = null;
            this.btnAddQuantity.Iconimage_Selected = null;
            this.btnAddQuantity.IconMarginLeft = 0;
            this.btnAddQuantity.IconMarginRight = 0;
            this.btnAddQuantity.IconRightVisible = false;
            this.btnAddQuantity.IconRightZoom = 0D;
            this.btnAddQuantity.IconVisible = false;
            this.btnAddQuantity.IconZoom = 90D;
            this.btnAddQuantity.IsTab = false;
            this.btnAddQuantity.Location = new System.Drawing.Point(773, 521);
            this.btnAddQuantity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAddQuantity.Name = "btnAddQuantity";
            this.btnAddQuantity.Normalcolor = System.Drawing.Color.Teal;
            this.btnAddQuantity.OnHovercolor = System.Drawing.Color.DarkCyan;
            this.btnAddQuantity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddQuantity.selected = false;
            this.btnAddQuantity.Size = new System.Drawing.Size(308, 52);
            this.btnAddQuantity.TabIndex = 41;
            this.btnAddQuantity.Text = "Add Quantity [F9]";
            this.btnAddQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddQuantity.Textcolor = System.Drawing.Color.White;
            this.btnAddQuantity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuantity.Click += new System.EventHandler(this.btnAddQuantity_Click);
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Rotate;
            this.bunifuTransition2.Cursor = null;
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
            this.bunifuTransition2.DefaultAnimation = animation3;
            // 
            // bunifuTransition3
            // 
            this.bunifuTransition3.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.bunifuTransition3.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 1F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuTransition3.DefaultAnimation = animation1;
            this.bunifuTransition3.TimeStep = 0.03F;
            // 
            // POSTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 706);
            this.Controls.Add(this.btnAddQuantity);
            this.Controls.Add(this.panelDiscount);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.panelNewTransaction);
            this.Controls.Add(this.btnCancelTransaction);
            this.Controls.Add(this.btnNewTransaction);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.txtSearch);
            this.bunifuTransition3.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "POSTransactionForm";
            this.Text = "POSTransactionForm";
            this.Load += new System.EventHandler(this.POSTransactionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.POSTransactionForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelTransactionInFo.ResumeLayout(false);
            this.groupBoxTransactionInformation.ResumeLayout(false);
            this.groupBoxTransactionInformation.PerformLayout();
            this.panelNewTransaction.ResumeLayout(false);
            this.panelNewTransaction.PerformLayout();
            this.panelDiscount.ResumeLayout(false);
            this.groupBoxDiscount.ResumeLayout(false);
            this.groupBoxDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDiscountClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnPayment;
        private Bunifu.Framework.UI.BunifuFlatButton btnVoid;
        private System.Windows.Forms.Panel panelTransactionInFo;
        private System.Windows.Forms.GroupBox groupBoxTransactionInformation;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblTotalAmount;
        private Bunifu.Framework.UI.BunifuFlatButton btnNewTransaction;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancelTransaction;
        private System.Windows.Forms.Label lblChangeValue;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblAmountPayment;
        private System.Windows.Forms.Label lblVatValue;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Panel panelNewTransaction;
        private System.Windows.Forms.Label lblNewTransaction;
        private System.Windows.Forms.Timer timerNewTransaction;
        public System.Windows.Forms.Label lblAmountPaymentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private Bunifu.Framework.UI.BunifuFlatButton btnDiscount;
        private System.Windows.Forms.Panel panelDiscount;
        private System.Windows.Forms.GroupBox groupBoxDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private Bunifu.Framework.UI.BunifuFlatButton btnDiscountOk;
        private Bunifu.Framework.UI.BunifuFlatButton btnDiscountCancel;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private Bunifu.Framework.UI.BunifuImageButton btnDiscountClose;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition3;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddQuantity;
        private System.Windows.Forms.ComboBox comboBoxDiscount;
    }
}