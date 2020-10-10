using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TicTacToe3D
{
    class GameTree
    {
        private GameTreeNode root;
        const String playerOneMark = "X";
        const String playerTwoMark = "O";
        bool humanPlayerOne;
        public GameTree(String[,,] gameboard, bool humanPlayerOne)
        {
            this.humanPlayerOne = humanPlayerOne;
            root = new GameTreeNode((String[,,]) gameboard.Clone(), this);
        }

        string GetPlayerMark()
        {
            if (humanPlayerOne)
            {
                return playerOneMark;
            }
            else
            {
                return playerTwoMark;
            }
        }

        string GetAIMark()
        {
            if (!humanPlayerOne)
            {
                return playerOneMark;
            }
            else
            {
                return playerTwoMark;
            }
        }

        public int[] GetMove()
        {
            return root.NextMove;
        }
        internal class GameTreeNode
        {
            //this is a node for the tree. It will store 
            //the board, the move that was taken, alphaBeta value
            //along with the normal parent, childre, etc

            //variables
            String[,,] gameBoard;
            private List<GameTreeNode> children;
            private GameTreeNode parent;
            private int? alphaBeta;

            //This is used to keep track of if the node is alpha beta
            //as well as determine who is making the move
            private bool isHuman;
            private int? parentAlphaBeta;
            private int currentPly;
            private List<int[]> possibleMoves;
            private GameTree GameTree;

            //stor the move to get to the alpha beta that is currently stored
            private int[] nextMove;
            //store the move we took to get to the board
            private int[] move;

            //get and set properties
            public int[] Move
            {
                get { return move; }
            }
            public int[] NextMove
            {
                get { return nextMove; }
            }
            public int AlphaBeta
            {
                get;
            }
            public int ParentAlphaBeta
            {
                set { parentAlphaBeta = value; }
            }

            public GameTreeNode(GameTreeNode treeNode, String[,,] gameboard, int[] move, int ply, bool isHuman, GameTree gameTree, int? parentAlpha)
            {
                this.parent = treeNode;
                this.gameBoard = gameboard;
                this.move = move;
                this.currentPly = ply;
                this.GameTree = gameTree;
                this.isHuman = isHuman;
                this.parentAlphaBeta = parentAlpha;
                children = new List<GameTreeNode>();
                possibleMoves = new List<int[]>();

                MakeMove();
            }


            //this is for the root node
            //root will always be the AI
            public GameTreeNode(String[,,] gameboard, GameTree gameTree)
            {
                this.gameBoard = gameboard;
                this.currentPly = 0;
                this.isHuman = false;
                this.GameTree = gameTree;
                children = new List<GameTreeNode>();
                possibleMoves = new List<int[]>();
                CreateChildren();
            }

            //this is the method that will put the new move down
            //Since the isHuman is also used to determine the alphabeta
            // and MakeMove puts down the move to get here
            // MakeMove is opposite of isHuman
            void MakeMove()
            {
                if (!isHuman)
                {
                    gameBoard[move[0], move[1], move[2]] = GameTree.GetPlayerMark();
                }
                else
                {
                    gameBoard[move[0], move[1], move[2]] = GameTree.GetAIMark();
                }
            }

            //void AddChild(GameTreeNode treeNode)
            //{
            //    children.Add(treeNode);
            //}

            //this will be called by the parent
            //check for winner. if not, evaluate board if leaf.
            //if not a leaf, make childen
            int GetAlphaBeta()
            {
                if(WinningBoard())
                {
                    
                }
                else if (currentPly == 5)
                {
                    EvaluateBoard();
                }
                else
                {
                    CreateChildren();
                }
                //should be able to cast w/o issue since the 3 above should
                //set the value
                return (int) alphaBeta;
            }

            //if this node produces a winning board, set alphaBeta
            //As with MakeMove, this operates on the same principal
            //The move to get to this node is opposite of the alphaBeta
            bool WinningBoard()
            {
                if (tictactoeForm.CheckForWinner(gameBoard, move))
                {
                    if (!isHuman)
                    {
                        alphaBeta = -200;
                    }
                    else
                    {
                        alphaBeta = 100;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            ////this updates the children if the alpha beta is updated
            //void NotifyChildrenAlphaBeta()
            //{
            //    foreach(GameTreeNode child in children)
            //    {
            //        child.ParentAlphaBeta = AlphaBeta;
            //    }
            //}

            //will look at the board and evaluate
            //This will need to modify alpha beta
            void EvaluateBoard()
            {
                //get the scores from the boards
                int score = BoardScore(0) + BoardScore(1) + BoardScore(2);

                //get the scores from 3D 
                score += Score3DColumns() + Score3DDiagonals() + Score3DRows();

                alphaBeta = score;
            }

            //method to create children and update alpha beta of the node based on the children
            void CreateChildren()
            {
                CreateMoveList();
                foreach(int [] move in possibleMoves)
                {
                    //create a child and get its alphabeta value
                    GameTreeNode treeNode = new GameTreeNode(this, (string[,,]) gameBoard.Clone(), move, currentPly + 1, !isHuman, this.GameTree, alphaBeta);
                    int childAlpha = treeNode.GetAlphaBeta();

                    //if don't currently have alpha beta
                    //update alpha beta and store the move of that child node
                    if (alphaBeta == null)
                    {
                        alphaBeta = childAlpha;
                        nextMove = treeNode.Move;
                    }
                    //else, do checks to see if need to update value
                    //if this node is Min (ie human) check if child alpha is lower
                    //Or if AI (ie Max) check if child alpha is higher
                    else if ((isHuman && alphaBeta > childAlpha) || (!isHuman && alphaBeta < childAlpha))
                    {
                        alphaBeta = childAlpha;
                        nextMove = treeNode.Move;
                    }

                    //check and see if we need to continue checking
                    if (parentAlphaBeta != null)
                    {
                        //if we are at min level, return when our value is lower than the parent since parent won't chose us
                        //if at the max level, return when our value is higher than the parent since parent won't chose us
                        if ((isHuman && alphaBeta < parentAlphaBeta) || (!isHuman && alphaBeta > parentAlphaBeta))
                        {
                            return;
                        }
                    }
                }
            }

            //make a list of possible moves
            void CreateMoveList()
            {
                for(int i = 0; i < gameBoard.Length; i++)
                {
                    //if there is a blank string (so isn't occupied or blocked)
                    //add to list
                    int board = i / 9;
                    int intermediate = i % 9;
                    int row = intermediate / 3;
                    int column = intermediate % 3;
                    if (gameBoard[board, row, column] == "")
                    {
                        possibleMoves.Add(new int[] { board, row, column });
                    }
                }
            }

            //this will return a score for a board
            //this method looks only at 1D
            /* Possible numbers. I will look out for a few and emphasize those. Numbers might be tweaked 
             * 
             * 2 player marks = -2. Will make this -75 since next turn Player wins
             * 2 ai marks = 6. Will make this 25 (more interested in preventing than winning)
             * 2 player and 1 ai = 1. Will make this 50
             * 
             * Ones not currently looking for
             * 1 player = -1
             * 1 ai = 3
             * none = 0
             * 1 ai and 1 player = 2
             * 2 ai and 1 player = 5
             */
            int BoardScore(int board)
            {
                int score = 0;
                String player = GameTree.GetPlayerMark();
                String ai = GameTree.GetAIMark();

                //conver board to numbers
                //this is to make it easier to make decisions
                int[] numericalBoard = new int[9];
                for (int i = 0; i < numericalBoard.Length; i++)
                {
                    String mark = gameBoard[board, i / 3, i % 3];
                    if(mark == player)
                    {
                        numericalBoard[i] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[i] = 3;
                    }
                    else
                    {
                        numericalBoard[i] = 0;
                    }
                }

                //check rows
                for (int i = 0; i < numericalBoard.Length; i += 3)
                {
                    int x = numericalBoard[i] + numericalBoard[i + 1] + numericalBoard[i + 2];
                    if(x == -2)
                    {
                        score -= 75;
                    }
                    else if(x == 1)
                    {
                        score += 50;
                    }
                    else if (x == 6)
                    {
                        score += 25;
                    }
                }

                //check columns
                for (int i = 0; i < 3; i ++)
                {
                    int x = numericalBoard[i] + numericalBoard[i + 3] + numericalBoard[i + 6];
                    if (x == -2)
                    {
                        score -= 75;
                    }
                    else if (x == 1)
                    {
                        score += 50;
                    }
                    else if (x == 6)
                    {
                        score += 25;
                    }
                }

                //check diagonals
                // first right and then left
                int temp = numericalBoard[0] + numericalBoard[4] + numericalBoard[8];
                if (temp == -2)
                {
                    score -= 75;
                }
                else if (temp == 1)
                {
                    score += 50;
                }
                else if (temp == 6)
                {
                    score += 25;
                }

                temp = numericalBoard[6] + numericalBoard[4] + numericalBoard[3];
                if (temp == -2)
                {
                    score -= 75;
                }
                else if (temp == 1)
                {
                    score += 50;
                }
                else if (temp == 6)
                {
                    score += 25;
                }

                return score;
            }

            //int BoardScore3D()
            //{
            //    return ;
            //}

            int Score3DColumns()
            {
                //make a numerical array
                //1st array will hold those from top board to bottom board
                //2nd will be from bottom board to top board
                int[,] numericalBoard = new int[2, 9];
                String player = GameTree.GetPlayerMark();
                String ai = GameTree.GetAIMark();
                int score = 0;

                //create the 1st board
                for (int i = 0; i < 9; i++)
                {
                    String mark = gameBoard[i/3, i / 3, i % 3];
                    if (mark == player)
                    {
                        numericalBoard[0, i] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[0, i] = 3;
                    }
                    else
                    {
                        numericalBoard[0, i] = 0;
                    }
                }

                //create the 2nd board
                for (int i = 0; i < 9; i++)
                {
                    String mark = gameBoard[(2 - (i / 3)), i / 3, i % 3];
                    if (mark == player)
                    {
                        numericalBoard[0, i] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[0, i] = 3;
                    }
                    else
                    {
                        numericalBoard[0, i] = 0;
                    }
                }

                //check columns
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int x = numericalBoard[j,i] + numericalBoard[j,i + 3] + numericalBoard[j,i + 6];
                        if (x == -2)
                        {
                            score -= 75;
                        }
                        else if (x == 1)
                        {
                            score += 50;
                        }
                        else if (x == 6)
                        {
                            score += 25;
                        }
                    }
                }

                return score;
            }

            int Score3DRows()
            {
                //make a numerical array
                //1st array will hold those from top board to bottom board
                //2nd will be from bottom board to top board
                int[,] numericalBoard = new int[2, 9];
                String player = GameTree.GetPlayerMark();
                String ai = GameTree.GetAIMark();
                int score = 0;

                //create the 1st board
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        String mark = gameBoard[j, i, j];
                        if (mark == player)
                        {
                            numericalBoard[0, i + j] = -1;
                        }
                        else if (mark == ai)
                        {
                            numericalBoard[0, i + j] = 3;
                        }
                        else
                        {
                            numericalBoard[0, i + j] = 0;
                        }
                    }
                }

                //create the 2nd board
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        String mark = gameBoard[2 - j, i, 2 - j];
                        if (mark == player)
                        {
                            numericalBoard[0, i + j] = -1;
                        }
                        else if (mark == ai)
                        {
                            numericalBoard[0, i + j] = 3;
                        }
                        else
                        {
                            numericalBoard[0, i + j] = 0;
                        }
                    }
                }

                //check rows
                for(int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 9; i += 3)
                    {
                        int x = numericalBoard[j,i] + numericalBoard[j,i + 1] + numericalBoard[j,i + 2];
                        if (x == -2)
                        {
                            score -= 75;
                        }
                        else if (x == 1)
                        {
                            score += 50;
                        }
                        else if (x == 6)
                        {
                            score += 25;
                        }
                    }
                }

                return score;
            }

            int Score3DDiagonals()
            {
                int score = 0;
                String player = GameTree.GetPlayerMark();
                String ai = GameTree.GetAIMark();

                //every 3 will be from a diagonal.
                //Will search them like rows later
                int[] numericalBoard = new int[12];

                for (int i = 0; i < 3; i++)
                {
                    String mark = gameBoard[i, i, i];
                    if (mark == player)
                    {
                        numericalBoard[i] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[i] = 3;
                    }
                    else
                    {
                        numericalBoard[i] = 0;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    String mark = gameBoard[i, 2 - i, i];
                    if (mark == player)
                    {
                        numericalBoard[i + 3] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[i + 3] = 3;
                    }
                    else
                    {
                        numericalBoard[i + 3] = 0;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    String mark = gameBoard[2- i, i, i];
                    if (mark == player)
                    {
                        numericalBoard[i + 6] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[i + 6] = 3;
                    }
                    else
                    {
                        numericalBoard[i + 6] = 0;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    String mark = gameBoard[2 - i, 2 - i, i];
                    if (mark == player)
                    {
                        numericalBoard[i +9] = -1;
                    }
                    else if (mark == ai)
                    {
                        numericalBoard[i + 9] = 3;
                    }
                    else
                    {
                        numericalBoard[i + 9] = 0;
                    }
                }

                //check diagonals like rows
                for (int i = 0; i < numericalBoard.Length; i += 3)
                {
                    int x = numericalBoard[i] + numericalBoard[i + 1] + numericalBoard[i + 2];
                    if (x == -2)
                    {
                        score -= 75;
                    }
                    else if (x == 1)
                    {
                        score += 50;
                    }
                    else if (x == 6)
                    {
                        score += 25;
                    }
                }
                return score;
            }
        }
    }
}
