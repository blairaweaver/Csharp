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
        //The board squares are numbered so that the /9 gives the board 
        // and /9 followed by /3 and %3 can give the row and column respectfully. 
        //Can use string substring to get the number from the name substring

        //variables used
        String[,,] gameBoard;
        const String playerOneMark = "X";
        const String playerTwoMark = "O";
        bool humanPlayerOne; //uesd to keep track of who is player 1
        bool humanTurn; //will be used to check whose turn it is

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
             * This is a boards
             * 0 1 2    9  10 11    18 19 20
             * 3 4 5    12 13 14    21 22 23
             * 6 7 8    15 16 17    24 25 26
             */
            gameBoard = new string[3, 3, 3];

            //loop through the entire array and add a blank string
            for(int i = 0; i < gameBoard.Length; i++)
            {
                //use div and mod to get position in array
                int board = i / 9;
                int intermediate = i % 9;
                int row = intermediate / 3;
                int column = intermediate % 3;
                gameBoard[board, row, column] = "";
            }

            //add the obstacles
            gameBoard[0, 0, 0] = null;
            gameBoard[0, 1, 0] = null;
            gameBoard[1, 0, 1] = null;
            gameBoard[1, 2, 0] = null;
            gameBoard[2, 0, 0] = null;
            gameBoard[2, 1, 2] = null;
            gameBoard[2, 2, 2] = null;
        }

        //this will be called by the new game form to set the player One 
        //and  reset the board
        public void newGame(bool playerOne)
        {
            //set either computer or human as player one
            humanPlayerOne = playerOne;
            humanTurn = playerOne;

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

        //This will check to see if there is a winner
        //since this is run after every turn, only have to check those around that spot
        //All check methods are at the end of this file
        private bool CheckForWinner(int board, int row, int column)
        {
            String mark = gameBoard[board, row, column];
            //check the row for 3 in a row
            if(1 + CheckRow(board, row, column - 1, -1, mark) + CheckRow(board, row, column + 1, 1, mark) == 3)
            {
                return true;
            }
            //check the column
            if (1 + CheckColumn(board, row - 1, column, -1, mark) + CheckColumn(board, row + 1, column, 1, mark) == 3)
            {
                return true;
            }
            //check the top left to bottom right diagnoal (called left diagonal)
            if (1 + CheckLeftDiagonal(board, row - 1, column - 1, -1, mark) + CheckLeftDiagonal(board, row + 1, column + 1, 1, mark) == 3)
            {
                return true;
            }
            //check the bottom left to top right diagonal(called right diagonal)
            if (1 + CheckRightDiagonal(board, row + 1, column - 1, -1, mark) + CheckRightDiagonal(board, row - 1, column + 1, 1, mark) == 3)
            {
                return true;
            }
            //check 3D space
            //check 3D row
            //check 3D column
            //check 3D diagonal
            //Placeholder
            return false;
        }

        //This will run the game tree & AI
        private void AITurn()
        {


            //at the end, switch back to human
            humanTurn = true;
        }

        //This is called when any of the buttons is selected.
        //NEED TO HAVE A WAY TO TELL WHO'S TURN IT IS
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            //Ignore clicks not on human's turn
            if(humanTurn)
            {
                //cast the sender object, which is the button, to a button object so that I have access to
                //properties of the button such as text
                Button workingButton = (Button)sender;
                //gets the button number and converts to an int
                String test = workingButton.Name.Substring(11);
                int workingNum = Int16.Parse(test);

                //just for clarity, show all calcs
                int board = workingNum / 9;
                int intermediate = workingNum % 9;
                int row = intermediate / 3;
                int column = intermediate % 3;

                if (workingButton.Text == "")
                {
                    workingButton.Text = GetPlayerMark();
                    gameBoard[board, row, column] = GetPlayerMark();
                }

                //check to see if there is a win
                if(CheckForWinner(board, row, column))
                {
                    ShowWinningDialog(true);
                }

                //at the end, change to computer turn
                humanTurn = false;
                AITurn();
            }
            //might want to have a message saying it is the computer's turn
            else
            {

            }
        }

        private void ShowWinningDialog(bool humanwin)
        {
            WinnerDialog winnerDialog = new WinnerDialog(humanwin);
            winnerDialog.ShowDialog();

            //after user closes the window, pop up the new game dialog
            NewGame ngdigl = new NewGame(this);
            ngdigl.ShowDialog();
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
            HelpDialog help = new HelpDialog();
            help.ShowDialog();
        }

        #region Check Methods
        //These methods work by using recursion and return how many marks there are in that direction

        //This method is for a row in 2D space
        private int CheckRow(int board, int row, int column, int dir, String mark)
        {
            //check to see if out of bounds
            if(column < 0 || column > 2)
            {
                return 0;
            }
            if(gameBoard[board, row, column] != mark)
            {
                return 0;
            }
            //make sure the next spot in that direction is on the board
            else
            {
                return 1 + CheckRow(board, row, column + dir, dir, mark);
            }
        }

        //This method is for a column in 2D space
        private int CheckColumn(int board, int row, int column, int dir, String mark)
        {
            //check to see if out of bounds
            if (row < 0 || row > 2)
            {
                return 0;
            }
            if (gameBoard[board, row, column] != mark)
            {
                return 0;
            }
            else
            {
                return 1 + CheckColumn(board, row + dir, column, dir, mark);
            }
        }

        //Next two methods is for a diagonals in 2D space
        private int CheckLeftDiagonal(int board, int row, int column, int dir, String mark)
        {
            //check to see if out of bounds
            if (row < 0 || row > 2 || column < 0 || column > 2)
            {
                return 0;
            }
            if (gameBoard[board, row, column] != mark)
            {
                return 0;
            }
            else
            {
                return 1 + CheckLeftDiagonal(board, row + dir, column + dir, dir, mark);
            }
        }

        private int CheckRightDiagonal(int board, int row, int column, int dir, String mark)
        {
            //check to see if out of bounds
            if (row < 0 || row > 2 || column < 0 || column > 2)
            {
                return 0;
            }
            if (gameBoard[board, row, column] != mark)
            {
                return 0;
            }
            else
            {
                return 1 + CheckRightDiagonal(board, row - dir, column + dir, dir, mark);
            }
        }

        #endregion
    }
}
