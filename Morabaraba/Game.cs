using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        private List<string> possibleMoves;
        private string currentPlayer;
<<<<<<< HEAD
        private IPlayer player1;
        private IPlayer player2;
        private IBoard Board;

        public Game()
        {
            currentPlayer = "Black";
            player1 = new Player("Black");
            player2 = new Player("White");
            Board = new Board();
=======

        Board brd;
        Player player;
        public Game()
        {
            currentPlayer = "Black";
            possibleMoves = generatePossibleMoves();
            brd = new Board();
            player = new Player();
>>>>>>> 8c33c82b5028c119042ddc20abb4d55ce5d4e84f
        }
        public string getCurrentPlayer()
        {
            return currentPlayer;
        }
        
        public void makeMove(Board gameBoard, string Position) 
        {
            if (player.getState() == "Placing")
            {
                gameBoard.updateMoveToBoard(currentPlayer, Position);
            }
        }
 

<<<<<<< HEAD
        private void swapCurrentPlayer(Player tempPlayer)
=======
<<<<<<< HEAD
            //return new List<char> { };
        
        List<string> generatePossibleMoves()
        {
            return new List<string> { "A1","A4","A7",
                                      "B2","B4","B6",
                                      "C3","C4","C5",
                                      "D1","D2","D3","D5","D6","D7",
                                      "E3","E4","E5",
                                      "F2","F4","F6",
                                      "G1","G4","G7"};
        }
=======
        void swapCurrentPlayer(Player tempPlayer)
>>>>>>> 8c33c82b5028c119042ddc20abb4d55ce5d4e84f
        {
            switch (tempPlayer.currentplayer())
            {
                case "Black": currentPlayer = "White";
                    return;
                case "White": currentPlayer = "Black";
                    return;
            }
        }

<<<<<<< HEAD
        private bool cowIn_MillPos(List<List<string>> mill_List, string pos)
        {
            for (int i = 0; i < mill_List.Count; i++)
            {
                if (mill_List[i].Contains(pos)) return true;
            }
            return false;
        }

        private int numberOf_Cow_NotInMill(IPlayer player)
        {
            int count = 0;
            List<string> playedPos = player.getPlayedPos();
            List<List<string>> mill_list = player.getMills();
            bool cowINmill = false;
            for (int i=0;i<playedPos.Count;i++)
            {
               
                foreach(List<string> mill in mill_list)
                {
                    if(mill.Contains(playedPos[i]))
                    {
                        cowINmill = true;
                        break;
                    }
                }
                if (!cowINmill) count++;
                cowINmill = false;
            }
            return count;
        }

        private char getPieceAtPos(string position)
        {
            char[,] gameBoard = Board.getBoard();
            switch(position)
            {
                case "A1":return gameBoard[0, 0];
                case "A4": return gameBoard[0, 1];
                case "A7": return gameBoard[0, 2];
                case "B2": return gameBoard[1, 0];
                case "B4": return gameBoard[1, 1];
                case "B6": return gameBoard[1, 2];
                case "C3": return gameBoard[2, 0];
                case "C4": return gameBoard[2, 1];
                case "C5": return gameBoard[2, 2];
                case "D1": return gameBoard[3, 0];
                case "D2": return gameBoard[3, 1];
                case "D3": return gameBoard[3, 2];
                case "D5": return gameBoard[4, 0];
                case "D6": return gameBoard[4, 1];
                case "D7": return gameBoard[4, 2];
                case "E3": return gameBoard[5, 0];
                case "E4": return gameBoard[5, 1];
                case "E5": return gameBoard[5, 2];
                case "F2": return gameBoard[6, 0];
                case "F4": return gameBoard[6, 1];
                case "F6": return gameBoard[6, 2];
                case "G1": return gameBoard[7, 0];
                case "G4": return gameBoard[7, 1];
                case "G7": return gameBoard[7, 2];
            }
            return ' ';
        }

        private bool invalidKill(string position)
        {
            char piece = getPieceAtPos(position);
            if (piece == ' ')
            {
                // CLI -> print appropriate message
                return true;
            }
            else
            {
                if (currentPlayer == "Black")
                {
                    if (cowIn_MillPos(player2.getMills(), position) && numberOf_Cow_NotInMill(player2) == 0)
                    {
                        //messageDisplay("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }
                    return false;

                }
                else if (currentPlayer == "White")
                {
                    if (cowIn_MillPos(player1.getMills(), position) && numberOf_Cow_NotInMill(player1) == 0)
                    {
                        //messageDisplay("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }
                    return false;
                }
                else
                {
                    //messageDisplay("Don't kill yourself, Try again");
                    return true;
                }
            }
        }
        private void eliminate(string Position)
        {

        }
=======
>>>>>>> 30b382e9ae0e9791c036755dfa42113de4079461
>>>>>>> 8c33c82b5028c119042ddc20abb4d55ce5d4e84f
    }
    
}
