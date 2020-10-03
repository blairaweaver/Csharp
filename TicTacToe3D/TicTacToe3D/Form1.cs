using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe3D
{
    public partial class tictactoeForm : Form
    {
        //The board squares are numbered so that the %9 gives the location in a board
        // and /9 gives the board. Can use string substring to get the number from the name
        // substring
        public tictactoeForm()
        {
            InitializeComponent();

        }

        //this will create the 2D array to store the board. This is what the 

        //This is called when any of the buttons is selected.
        //NEED TO HAVE A WAY TO TELL WHO'S TURN IT IS
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            //cast the sender object, which is the button, to a button object so that I have access to
            //properties of the button such as text
            Button workingButton = (Button)sender;
            //gets the button number and converts to an int
            String test = workingButton.Name.Substring(11);
            int workingNum = Int16.Parse(test);

            #region
            //THIS SECTION IS JUST FOR TESTING
            Form dlg1 = new Form();

            TextBox board = new TextBox();
            board.Text = "Board " + (workingNum / 9).ToString() + " Box " + (workingNum % 9).ToString();

            dlg1.Controls.Add(board);


            dlg1.ShowDialog();

            #endregion
        }

        //This will bring up the new game dialog
        private void NewGame_Click(object sender, EventArgs e)
        {

        }
        //This will bring up the Help dialog which will explain the game
        private void Help_Click(object sender, EventArgs e)
        {

        }
    }
}
