using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Assignment_One
{
    public partial class NumberConversion : Form
    {
        private Handler handler;
        public NumberConversion()
        {
            InitializeComponent();
            handler = new Handler(this);
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DecimalTextbox.Text))
            {
                handler.DecimalCoversion(DecimalTextbox.Text);
            }
            else if (!String.IsNullOrEmpty(HexTextbox.Text))
            {
                handler.HexadecimalCoversion(HexTextbox.Text);
            }
            else if (!String.IsNullOrEmpty(BinaryTextbox.Text))
            {
                handler.BinaryCoversion(BinaryTextbox.Text);
            }
            else
            {
                ErrorMessage("Please enter a number into one of the textboxes", "Error Dectected in Input");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            DecimalTextbox.Clear();
            HexTextbox.Clear();
            BinaryTextbox.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        public void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }

        public void UpdateTextbox(string output, string box)
        {
            switch(box)
            {
                case "Hexadecimal":
                    HexTextbox.AppendText(output);
                    break;
                case "Decimal":
                    DecimalTextbox.AppendText(output);
                    break;
                case "Binary":
                    BinaryTextbox.AppendText(output);
                    break;
            }
        }
        void Toolbox_KeyPressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Convert_Click(this, null);
            }
        }

    }
}
