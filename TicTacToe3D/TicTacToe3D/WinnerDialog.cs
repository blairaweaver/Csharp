using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe3D
{
    public partial class WinnerDialog : Form
    {
        public WinnerDialog(bool humanWin)
        {
            InitializeComponent();
            SetMessage(humanWin);
        }

        private void SetMessage(bool humanWin)
        {
            //only need to change if Computer Wins
            //Since default Dialog is for a human win
            if(!humanWin)
            {
                this.Text = "Game Over";
                winnerTextBox.Text = "The Computer has won. Better luck next time!";
            }
        }

    }
}
