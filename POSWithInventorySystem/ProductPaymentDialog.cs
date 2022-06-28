using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    public partial class ProductPaymentDialog : Form
    {
        public ProductPaymentDialog()
        {
            InitializeComponent();
        }

        public ProductPaymentDialog(double totalAmount)
        {
            InitializeComponent();
            this.TotalAmount = totalAmount;
        }

        POSTransactionForm pOS;
        double TotalAmount;

        private void ProductPaymentDialog_Load(object sender, EventArgs e)
        {
            lblErrorAmount.Text = "";
            pOS = (POSTransactionForm)this.Owner;
        }

        private void ProductPaymentDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Payment();
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtAmount.Text = "0";
                pOS.validateAmount = true;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Payment();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetMaximumLengthAndDisabledShortCutKeys(txtAmount, 18);

            if (e.KeyChar == '0' && txtAmount.Text.Length == 0)
            {
                e.Handled = true;
            }

            //e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (txtAmount.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }


            // Allow only two decimal places
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtAmount);
            if ((convertedTextBox.Text.IndexOf('.')) > 0 &&
                (convertedTextBox.Text.Length - convertedTextBox.Text.IndexOf('.')) > 2 &&
                (convertedTextBox.SelectionStart == convertedTextBox.Text.Length) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete)
                )
            {
                e.Handled = true;
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtAmount);
            int i = convertedTextBox.SelectionStart;

            if (i > 0)
            {
                if(e.KeyData == Keys.Back)
                {
                    if(convertedTextBox.Text[i-1] == ',')
                    {
                        convertedTextBox.SelectionStart -= 1;
                    }
                }
            }
            
            if (i < (convertedTextBox.Text.Length))
            {
                if (e.KeyData == Keys.Delete)
                {
                    if(convertedTextBox.Text[i] == ',')
                    {
                        convertedTextBox.SelectionStart += 1;
                    }
                }
            }

            e.Handled = false;
        }

        private void txtAmount_OnValueChanged(object sender, EventArgs e)
        {
            string txtAmountDummy = txtAmount.Text;

            try
            {
                TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtAmount);
                int selectionStart = convertedTextBox.SelectionStart - 1;
                
                for (int i = selectionStart; i > 0; i--)
                {
                    if (txtAmount.Text[i] == ',')
                    {
                        selectionStart -= 1;
                    }
                }

                txtAmountDummy = String.Format("{0:n}", Convert.ToDouble(txtAmountDummy.Replace(",", "")));

                for (int i = 0; i <= selectionStart; i++)
                {
                    if (txtAmountDummy[i] == ',')
                    {
                        selectionStart += 1;
                    }
                }

                convertedTextBox.Text = txtAmountDummy;
                convertedTextBox.SelectionStart = selectionStart + 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong in payment. Please try again." + ex , "Payment error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            pOS.lblAmountPaymentValue.Text = txtAmount.Text;
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            lblErrorAmount.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "0";
            pOS.validateAmount = true;
            this.Close();
        }

        private void Payment()
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                lblErrorAmount.Text = "❌";
            }
            else
            {   if (Convert.ToDouble(txtAmount.Text.Trim()) < TotalAmount)
                {
                    MessageBox.Show("The payment is not enough to pay the product/s. Please try again.", "Not enough balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    pOS.AmountTendered = Convert.ToDouble(txtAmount.Text.Trim());
                    pOS.validateAmount = false;
                    this.Close();
                }
            }
        }

        private void SetMaximumLengthAndDisabledShortCutKeys(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                    txt.ShortcutsEnabled = false;
                }
            }
        }

        private TextBox getConvertedTextBoxBunifuToWindowsControl(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox)
        {
            TextBox txtBox = new TextBox();

            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    txtBox = (TextBox)ctl;
                    
                }
            }

            return txtBox;
        }

       
    }
}
