using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        
        private string currentPlayer;
        private int blackPlacementCount;
        private int whitePlacementCount;
        private string[] lastMoveBlack;
        private string[] lastMoveWhite;
        private int numberOf_cows_in_the_board;


        private IPlayer playerBlack;
        private IPlayer playerWhite;
        private IReferee referee;
        private IBoard Board;

        public Game(IPlayer playerBlack, IPlayer playerWhite, IBoard Board, IReferee referee)
        {

            currentPlayer = "Black";
            blackPlacementCount = 0;
            whitePlacementCount = 0;
            numberOf_cows_in_the_board = 0;
            lastMoveBlack = new string[] { "", "" };
            lastMoveWhite = new string[] { "", "" };

            this.playerBlack = playerBlack;
            this.playerWhite = playerWhite;
            this.referee = referee;
            this.Board = Board;

            
            Board.printBoard(Board.getBoard());
            
            
        }


        public string getcurrentPlayer()
        {
            return currentPlayer;
        }



        public int get_Number_of_cows_in_board()
        {
            return numberOf_cows_in_the_board;
        }


       



        public void makePlacement(string Position) 

        {
            
            if (currentPlayer == "Black" && blackPlacementCount < 12 && isBlankSpace(Position)== true)
            {
              if (playerBlack.getState() == "Placing")
                {
                   blackPlacementCount++;
                   Board.updateMoveToBoard(currentPlayer, Position);
                   
                   playerBlack.addPlayedPositions(Position);
                   playerBlack.updateState();
                   numberOf_cows_in_the_board++;
                }
            }
            if(currentPlayer == "White" && whitePlacementCount < 12 && isBlankSpace(Position) == true)
            {
                if (playerWhite.getState() == "Placing")
                {
                   whitePlacementCount++;
                   Board.updateMoveToBoard(currentPlayer, Position);
                   
                   playerWhite.addPlayedPositions(Position);
                   playerWhite.updateState();
                   numberOf_cows_in_the_board++;
                }
            }


        }


        public void makeMove(string moveFrom, string moveTo)
        {

            //   if (player.getState() == "Moving" || checkNeighbours(fromPos).Contains(toPos))
            if (currentPlayer == "Black" && playerBlack.getState()=="Moving" && isBlankSpace(moveTo))
            {
                Board.updateMoveFromBoard(moveFrom);
                Board.updateMoveToBoard(currentPlayer,moveTo);

                playerBlack.addPlayedPositions(moveTo);
                playerBlack.removePlayedPositions(moveFrom);

                lastMoveBlack[0] = moveFrom;
                lastMoveBlack[1] = moveTo;
            }

            if (currentPlayer == "White" && playerWhite.getState() == "Moving" && isBlankSpace(moveTo))
            {
                Board.updateMoveFromBoard(moveFrom);
                Board.updateMoveToBoard(currentPlayer, moveTo);

                playerWhite.addPlayedPositions(moveTo);
                playerWhite.removePlayedPositions(moveFrom);

                lastMoveWhite[0] = moveFrom;
                lastMoveWhite[1] = moveTo;
            }
        }



        public int getNUmOfPlacedBlackCows()
        {
            return blackPlacementCount;
        }



        public int getNUmOfPlacedWhiteCows()
        {
            return whitePlacementCount;
        }



        public string[] getLastMove()
        {
            if (currentPlayer == "Black")
            {
                return lastMoveBlack;
            }
            else
            {
                return lastMoveWhite;

            }
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
            if (!isValidPosition(position))
            {
                // Console.WriteLine("Out of range!");
                // CLI -> print appropriate message
                return true;
            }

            char piece = getPieceAtPos(position,board);
            //Console.WriteLine(piece);
            if (piece == ' ')
            {
                //Console.WriteLine("Blank ");
                // CLI -> print appropriate message
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
                Console.WriteLine("KILLLLLLEDDDD!");
            }
        }

       
        public void runGame()
        {
            
            while(!referee.Winner(playerBlack, playerWhite))
            {
                playerBlack.updateState();
                playerWhite.updateState();

                ///PLACING
                if (playerWhite.getState() == "Placing" || playerBlack.getState() == "Placing")
                {
                    
                    Console.WriteLine("{0} make move:", currentPlayer);
                    tryAgain:
                    string Position = Console.ReadLine();
                    //Check if the move is valid

                    if (!generatePossibleMoves().Exists(x => x == Position) || !isBlankSpace(Position))
                    {
                        Board.printBoard(Board.getBoard());
                        Console.WriteLine("Invalid input or that position is occupied.\nplease try again");
                        goto tryAgain;
                    }
                    makePlacement(Position);
                    Board.printBoard(Board.getBoard());
                    
                }
                
                //Check Mill for Black Cows
                if(referee.isMill(playerBlack))
                {
                    //afterMill(playerBlack);   
                    Console.WriteLine("Choose The position of the white cow to kill: ");
                    tryAgain1:
                    string killWhitePos = Console.ReadLine();
                    if (isBlankSpace(killWhitePos) || !generatePossibleMoves().Exists(x => x == killWhitePos) || getPieceAtPos(killWhitePos) != 'w')
                    {
                        Console.WriteLine("Invalid position.\nTry again");
                        goto tryAgain1;
                    }
                    eliminate(playerWhite, Board, killWhitePos);
                    Board.printBoard(Board.getBoard());

                }
                //Check Mill for White Cows
                if (referee.isMill(playerWhite))
                {
                    //afterMill(playerWhite);
                    Console.WriteLine("Choose The position of the black cow to kill: ");
                    tryAgain2:
                    string killBlackPos = Console.ReadLine();
                    if (isBlankSpace(killBlackPos) || !generatePossibleMoves().Exists(x => x == killBlackPos) || getPieceAtPos(killBlackPos) != 'b')
                    {
                        Console.WriteLine("Invalid position.\nTry again");
                        goto tryAgain2;
                    }
                    eliminate(playerBlack, Board, killBlackPos);
                    Board.printBoard(Board.getBoard());
                }
                
                //MOVING

                if (playerBlack.getState() == "Moving" || playerWhite.getState() == "Moving")
                {
                    TryAgain3:
                    Console.WriteLine("{0} Select the postion to move from", currentPlayer);
                    string moveFrom = Console.ReadLine();
                    Console.WriteLine("{0} Select position to move to", currentPlayer);
                    string moveTo = Console.ReadLine();
                    if(!checkNeighbours(moveFrom).Exists(x => x == moveTo) || !possibleMoves.Exists(x => x == moveFrom) || !possibleMoves.Exists(x => x == moveTo))
                    {
                        Console.WriteLine("Invalid move.\n try again");
                        goto TryAgain3;
                    }
                    makeMove(moveFrom, moveTo);
                    Board.printBoard(Board.getBoard());
                }
                //FLYING
                if(playerBlack.getState() == "Flying" || playerWhite.getState() == "fLying")
                {
                    TryAgain4:
                    Console.WriteLine("{0} Select the position to fly from", currentPlayer);
                    string flyFrom = Console.ReadLine();
                    Console.WriteLine("{0} Select position to fly to", currentPlayer);
                    string flyTo = Console.ReadLine();
                    if(!possibleMoves.Exists(x => x == flyFrom) || !possibleMoves.Exists(x => x == flyTo))
                    {
                        Console.WriteLine("Invalid move.\n try again");
                        goto TryAgain4;
                    }
                    makeMove(flyFrom, flyTo);
                    Board.printBoard(Board.getBoard());
                }
                swapcurrentPlayer();
                Board.printBoard(Board.getBoard());
                Console.WriteLine("{0} black players left", playerBlack.numberOfCows());
                Console.WriteLine("{0} white players left", playerWhite.numberOfCows());


            }

            if (playerBlack.numberOfCows() == 2) Console.WriteLine("GAMEOVER!!!!\nWhite has won");
            else if (playerWhite.numberOfCows() == 2) Console.WriteLine("GAMEOVER!!!!\nBlack has won");
            else Console.WriteLine("GAMEOVER!!!!\nIt's a draw");

        }



    }
}
