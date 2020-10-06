using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe3D
{
    class GameTree
    {
        private GameTreeNode root;
        const String playerOneMark = "X";
        const String playerTwoMark = "O";
        bool humanPlayerOne;
        GameTree(String[,,] gameboard, bool humanPlayerOne)
        {
            root = new GameTreeNode(gameboard, this);
            this.humanPlayerOne = humanPlayerOne;
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
            private bool isHuman;
            private String playerMark;
            private int? parentAlphaBeta;
            private int currentPly;
            private List<int[]> possibleMoves;
            private GameTree GameTree;

            private int[] move;

            //get and set properties
            public int[] Move
            {
                get { return move; }
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
            void MakeMove()
            {
                if (isHuman)
                {
                    gameBoard[move[0], move[1], move[2]] = GameTree.GetPlayerMark();
                }
                else
                {
                    gameBoard[move[0], move[1], move[2]] = GameTree.GetAIMark();
                }
            }

            void AddChild(GameTreeNode treeNode)
            {
                children.Add(treeNode);
            }

            //this will be called by the parent
            //check for winner. if not, evaluate board if leaf.
            //if not a leaf, make childen
            int GetAlphaBeta()
            {
                if(WinningBoard())
                {
                    
                }
                else if (currentPly == 3)
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
            bool WinningBoard()
            {
                if (tictactoeForm.CheckForWinner(gameBoard, move[0], move[1], move[2]))
                {
                    if (isHuman)
                    {
                        alphaBeta = -100;
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
                
            }

            //method to create children
            void CreateChildren()
            {
                CreateMoveList();
                foreach(int [] move in possibleMoves)
                {
                    //create a child and get its alphabeta value
                    GameTreeNode treeNode = new GameTreeNode(this, (string[,,]) gameBoard.Clone(), move, currentPly + 1, !isHuman, this.GameTree, alphaBeta);
                    int childAlpha = treeNode.GetAlphaBeta();

                    //if don't currently have alpha beta
                    if (alphaBeta == null)
                    {
                        alphaBeta = childAlpha;
                    }
                    //else, do checks to see if need to update value
                    //if this node is Min (ie human) check if child alpha is lower
                    else if (isHuman && alphaBeta > childAlpha)
                    {
                        alphaBeta = childAlpha;
                    }
                    //if AI (ie Max) check if child alpha is higher
                    else if (alphaBeta < childAlpha)
                    {
                        alphaBeta = childAlpha;
                    }

                    //check and see if we need to continue checking
                    if (parentAlphaBeta != null)
                    {
                        if (isHuman && alphaBeta < parentAlphaBeta)
                        {
                            return;
                        }
                        else if (alphaBeta > parentAlphaBeta)
                        {

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
        }
    }
}
