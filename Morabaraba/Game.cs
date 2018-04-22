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
            return Board.getPieceAtPos(pos) == ' ';
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
        private bool invalidKill(IPlayer player, IBoard board, string position)
        {
            if (referee.get_GameState() != "Mill") return true;
            if (!Board.isValidPosition(position))
            {
                return true;
            }

            char piece = Board.getPieceAtPos(position);
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
                    return true;
                }
                else if (player.currentPlayer() == "White")
                {
                    if (cowIn_MillPos(player.getMills(), position) && numberOf_Cow_NotInMill(player) == 0)
                    {
                         Console.WriteLine("Cannot kill a cow already\n in a mill, try\n another cow");
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
                    Console.WriteLine("Don't kill yourself, Try again");
                    return true;
                }
            }
        }


        public void eliminate(IPlayer player, IBoard board, string position)
        {
            if (invalidKill(player, board, position))
            {
                Console.WriteLine("Error!");
                return;
            }
            else
            {
                Console.WriteLine("KILLED");
                referee.updateGameStat("OnGoing");
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
                playerBlack.updateState();
                playerWhite.updateState();

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
