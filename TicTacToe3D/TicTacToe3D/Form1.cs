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

        //variables used
        String[,] gameBoard;
        const String playerOneMark = "X";
        const String playerTwoMark = "O";
        bool humanPlayerOne = true; //uesd to keep track of who is player 1

        public tictactoeForm()
        {
            CreateGameArray();
            NewGame ngdigl = new NewGame(this);
            ngdigl.ShowDialog();
            InitializeComponent();
        }

        //this will create the 2D array to store the board. 
        //This is what the internal methods will use (determine winner, what move to take, etc)
        //Obstacles will have null in their position
        private void CreateGameArray()
        {
            //creates a 2D array to hold the game board.
            //The row signifies the board and column = square
            /*
             * This is a board
             * 0 1 2
             * 3 4 5
             * 6 7 8
             */
            gameBoard = new string[3, 9];

            //loop through the entire array and add a blank string
            for(int i = 0; i < gameBoard.Length; i++)
            {
                //use div and mod to get position in array
                int row = i / 9;
                int column = i % 9;
                gameBoard[row, column] = "";
            }

            //add the obstacles
            gameBoard[0, 0] = null;
            gameBoard[0, 3] = null;
            gameBoard[1, 1] = null;
            gameBoard[1, 6] = null;
            gameBoard[2, 0] = null;
            gameBoard[2, 5] = null;
            gameBoard[2, 8] = null;
        }

        //this will be called by the new game form to set the player One 
        //and  reset the board
        public void newGame(bool playerOne)
        {
            humanPlayerOne = playerOne;

            //reset all the text boxes and the array
            CreateGameArray();
            foreach (Control control in this.Controls)
            {
                if(control is Button)
                {
                    Button button = (Button)control;
                    button.Text = "";
                }
            }
        }

        //this will return the players mark. Just to keep my code cleaner
        //since this will be used a lot
        private string GetPlayerMark()
        {
            if(humanPlayerOne)
            {
                return playerOneMark;
            }
            else
            {
                return playerTwoMark;
            }
        }

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

            if(workingButton.Text == "")
            {
                workingButton.Text = GetPlayerMark();
                gameBoard[(workingNum / 9), (workingNum % 9)] = GetPlayerMark();
            }

        }

        //This will bring up the new game dialog
        private void NewGame_Click(object sender, EventArgs e)
        {
            NewGame ngdigl = new NewGame(this);
            ngdigl.ShowDialog();
        }
        //This will bring up the Help dialog which will explain the game
        private void Help_Click(object sender, EventArgs e)
        {

        }
    }
}
