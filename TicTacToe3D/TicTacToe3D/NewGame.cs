using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe3D
{
    public partial class NewGame : Form
    {
        //variables
        tictactoeForm tictactoeForm;
        public NewGame(tictactoeForm form)
        {
            //get the parent form so that we can pass the variable back
            tictactoeForm = form;
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(humanRadioButton.Checked == true)
            {
                tictactoeForm.newGame(true);
            }
            else
            {
                tictactoeForm.newGame(false);
            }
            this.Close();
        }
    }
}
