using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        private IPlayer playerBlack;
        private IPlayer playerWhite;
        private IReferee referee;
        private IBoard Board;

        public Game(IPlayer playerBlack, IPlayer playerWhite, IBoard Board, IReferee referee)
        {


            this.playerBlack = playerBlack;
            this.playerWhite = playerWhite;
            this.referee = referee;
            this.Board = Board;
            Board.printBoard(Board.getBoard());

        }

        public bool isBlankSpace(string pos)
        {
            return getPieceAtPos(pos) == ' ';
        }

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
            for (int i = 0; i < playedPos.Count; i++)
            {
                foreach (List<string> mill in mill_list)
                {
                    if (mill.Contains(playedPos[i]))
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


        public char getPieceAtPos(string position)
        {
            return getPieceAtPos(position, Board);
        }

        public char getPieceAtPos(string position, IBoard Board)
        {
            char[,] gameBoard = Board.getBoard();
            switch (position)
            {
                case "A1": return gameBoard[0, 0];
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


        private bool invalidKill(IPlayer player, IBoard board, string position)
        {
            if (!Board.isValidPosition(position))
            {
                return true;
            }

            char piece = getPieceAtPos(position, board);
            //Console.WriteLine(piece);
            if (piece == ' ')
            {
                return true;
            }
            else
            {
                if (player.currentPlayer() == "Black")
                {
                    if (!player.playerOwnPosition(position)) return true;
                    if (cowIn_MillPos(player.getMills(), position) && numberOf_Cow_NotInMill(player) == 0)

                    {
                        return false;
                    }
                    else if (cowIn_MillPos(player.getMills(), position))
                    {
                        Console.WriteLine("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }
                    return false;
                }
                else if (player.currentPlayer() == "White")
                {
                    if (cowIn_MillPos(player.getMills(), position) && numberOf_Cow_NotInMill(player) == 0)
                    {
                        // Console.WriteLine("Cannot kill a cow already\n in a mill, try\n another cow");
                        return false;
                    }
                    else if (cowIn_MillPos(player.getMills(), position))

                    {
                        Console.WriteLine("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }

                    return false;
                }
                else
                {
                    //Console.WriteLine("Don't kill yourself, Try again");
                    return true;
                }
            }
        }


        public void eliminate(IPlayer player, IBoard board, string position)
        {
            if (invalidKill(player, board, position))
            {
                //Console.WriteLine("Error!");
                return;
            }
            else
            {
                player.killCow(position);
                board.updateMoveFromBoard(position);
               
            }
        }

        private void placeCow(IPlayer plyr)// function for placing
        {
            Console.WriteLine("{0} make move:", referee.getcurrentPlayer());
            tryAgain:
            string Position = Console.ReadLine();
            //Check if the move is valid

            if (!Board.generatePossibleMoves().Exists(x => x == Position) || !isBlankSpace(Position))
            {
                Board.printBoard(Board.getBoard());
                Console.WriteLine("Invalid input or that position is occupied.\nplease try again");
                goto tryAgain;
            }
            plyr.makePlacement(Position, Board);
            Board.printBoard(Board.getBoard());
        }
        private void afterMill(IPlayer plyr)// function for the mill
        {

            Console.WriteLine("{0} choose The position of the cow to kill: ", referee.getcurrentPlayer());
            tryAgain1:
            string position = Console.ReadLine();
            if (isBlankSpace(position) || !Board.generatePossibleMoves().Exists(x => x == position) || !invalidKill(plyr, Board, position))
            {
                Console.WriteLine("Invalid position.\nTry again");
                goto tryAgain1;
            }
            eliminate(playerWhite, Board, position);
            Board.printBoard(Board.getBoard());
        }

        private void Moving(IPlayer plyr) // function for moving Moving
        {
            TryAgain3:
            Console.WriteLine("{0} Select the postion to move from", referee.getcurrentPlayer());
            string moveFrom = Console.ReadLine();
            Console.WriteLine("{0} Select position to move to", referee.getcurrentPlayer());
            string moveTo = Console.ReadLine();
            if (!Board.checkNeighbours(moveFrom).Exists(x => x == moveTo) || !Board.generatePossibleMoves().Exists(x => x == moveFrom) || !Board.generatePossibleMoves().Exists(x => x == moveTo))
            {
                Console.WriteLine("Invalid move.\n try again");
                goto TryAgain3;
            }
            plyr.makeMove(moveFrom, moveTo, Board);
            Board.printBoard(Board.getBoard());
        }

        private void Flying(IPlayer plyr)
        {
            TryAgain4:
            Console.WriteLine("{0} Select the position to fly from", plyr.currentPlayer());
            string flyFrom = Console.ReadLine();
            Console.WriteLine("{0} Select position to fly to", plyr.currentPlayer());
            string flyTo = Console.ReadLine();
            if (!Board.generatePossibleMoves().Exists(x => x == flyFrom) || !Board.generatePossibleMoves().Exists(x => x == flyTo))
            {
                Console.WriteLine("Invalid move.\n try again");
                goto TryAgain4;
            }
            plyr.makeMove(flyFrom, flyTo, Board);
            Board.printBoard(Board.getBoard());
        }
        public void runGame()
        {

            while (!referee.Winner(playerBlack, playerWhite))
            {
                //playerBlack.updateState();
                //playerWhite.updateState();

                string currentPlayer = referee.getcurrentPlayer();
                //PLACING
                if (currentPlayer == "Black")
                {
                    if (playerBlack.getState() == "Placing")
                    {
                        placeCow(playerBlack);
                    }
                    else if (playerBlack.getState() == "Moving")
                    {
                        Moving(playerBlack);
                    }
                    else
                    {
                        Flying(playerBlack);
                    }
                    if (referee.isMill(playerBlack))
                    {
                        afterMill(playerBlack);
                    }
                   
                }

                if (currentPlayer == "White")
                {
                    if (playerWhite.getState() == "Placing")
                    {
                        placeCow(playerWhite);
                    }
                    else if (playerWhite.getState() == "Moving")
                    {
                        Moving(playerWhite);
                    }
                    else
                    {
                        Flying(playerWhite);
                    }
                    if (referee.isMill(playerWhite))
                    {
                        afterMill(playerWhite);
                    }
                    
                }



                referee.swapcurrentPlayer();

                Board.printBoard(Board.getBoard());
                


            }

            if (playerBlack.numberOfCows() == 2) Console.WriteLine("GAMEOVER!!!!\nWhite has won");
            else if (playerWhite.numberOfCows() == 2) Console.WriteLine("GAMEOVER!!!!\nBlack has won");
            else Console.WriteLine("GAMEOVER!!!!\nIt's a draw");

        }



    }
}
