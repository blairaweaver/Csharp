using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPv4_validator
{
    public partial class IPv4Validator : Form
    {
        private Handler handler;
        public IPv4Validator()
        {
            InitializeComponent();
            handler = new Handler(this);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            HexOutputLabel.Hide();
            HexOutputTextBox.Hide();
            HexOutputTextBox.Clear();
            if(IPv4Masked.MaskCompleted)
            {
                handler.DecimalCoversion(IPv4Masked.Text);
            }
            else
            {
                ErrorMessage("Missing inputs. Please put numbers at the beginning", "Invalid Input");
            }
        }
        
        private void IPv4Input_Click(object sender, EventArgs e)
        {
            IPv4Masked.Focus();
            IPv4Masked.Select(0, 0);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        public void UpdateTextbox(string output)
        {
            HexOutputTextBox.Clear();
            HexOutputTextBox.AppendText(output);
            HexOutputLabel.Visible = true;
            HexOutputTextBox.Visible = true;
        }

        public void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }

        void IPv4Masked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //Learned this from https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.maskedtextbox?view=netframework-4.8
            if (IPv4Masked.MaskFull)
            {
                ErrorToolTip.ToolTipTitle = "Input Rejected - Too Much Data";
                ErrorToolTip.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.", IPv4Masked, 0, 20, 5000);
            }
            else if (e.Position == IPv4Masked.Mask.Length)
            {
                ErrorToolTip.ToolTipTitle = "Input Rejected - End of Field";
                ErrorToolTip.Show("You cannot add extra characters to the end of this date field.", IPv4Masked, 0, 20, 5000);
            }
            else
            {
                ErrorToolTip.ToolTipTitle = "Input Rejected";
                ErrorToolTip.Show("You can only add numeric characters (0-9) into this date field.", IPv4Masked, 0, 20, 5000);
            }
            
        }

        void IPv4Masked_KeyPressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidateButton_Click(this, null);
            }
        }
    }
}
