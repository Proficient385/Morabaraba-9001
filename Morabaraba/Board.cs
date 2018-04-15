using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Board : IBoard
    {
        private char[,] gameBoard;

        public Board()
        {
            gameBoard = emtyBaord();
        }

        private char[,] emtyBaord()
        {
            char[,] result = new char[8, 3];
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 3; k++) result[i, k] = ' ';
            }
            return result;
        }
        public void printBoard(char[,] brd)
        {
            //Console.WriteLine("\n\n\n\t\t\t\t  1    2    3       4      5    6    7 \n\n\n");
            Console.WriteLine("|{0}\\     {1}    /{2}|", brd[0, 0], brd[0, 1], brd[0, 2]);
            Console.WriteLine("|    \\     |    /    |");
            Console.WriteLine("|      {0} {1} {2}   |", brd[1, 0], brd[1, 1], brd[1, 2]);
        }

        public void updateMoveToBoard(string player, string PositionTo)
        {
            char symbol = ' ';
            if(player == "Black")
            {
                symbol = 'b';
            }
            else
            {
                symbol = 'w';
            }
            switch (PositionTo)
            {
                case "A1": gameBoard[0, 0]=  symbol; break;
                case "A4": gameBoard[0, 1] = symbol; break;
                case "A7": gameBoard[0, 2] = symbol; break;

                case "B2": gameBoard[1, 0] = symbol; break;
                case "B4": gameBoard[1, 1] = symbol; break;
                case "B6": gameBoard[1, 2] = symbol; break;

                case "C3": gameBoard[2, 0] = symbol; break;
                case "C4": gameBoard[2, 1] = symbol; break;
                case "C5": gameBoard[2, 2] = symbol; break;

                case "D1": gameBoard[3, 0] = symbol; break;
                case "D2": gameBoard[3, 1] = symbol; break;
                case "D3": gameBoard[3, 2] = symbol; break;

                case "D5": gameBoard[4, 0] = symbol; break;
                case "D6": gameBoard[4, 1] = symbol; break;
                case "D7": gameBoard[4, 2] = symbol; break;

                case "E3": gameBoard[5, 0] = symbol; break;
                case "E4": gameBoard[5, 1] = symbol; break;
                case "E5": gameBoard[5, 2] = symbol; break;

                case "F2": gameBoard[6, 0] = symbol; break;
                case "F4": gameBoard[6, 1] = symbol; break;
                case "F6": gameBoard[6, 2] = symbol; break;

                case "G1": gameBoard[7, 0] = symbol; break;
                case "G4": gameBoard[7, 1] = symbol; break;
                case "G7": gameBoard[7, 2] = symbol; break;
            }
        }

        public void updateMoveFromBoard(string PositionTo)
        {
            switch (PositionTo)
            {
                case "A1": gameBoard[0, 0] = ' '; break;
                case "A4": gameBoard[0, 1] = ' '; break;
                case "A7": gameBoard[0, 2] = ' '; break;

                case "B2": gameBoard[1, 0] = ' '; break;
                case "B4": gameBoard[1, 1] = ' '; break;
                case "B6": gameBoard[1, 2] = ' '; break;

                case "C3": gameBoard[2, 0] = ' '; break;
                case "C4": gameBoard[2, 1] = ' '; break;
                case "C5": gameBoard[2, 2] = ' '; break;

                case "D1": gameBoard[3, 0] = ' '; break;
                case "D2": gameBoard[3, 1] = ' '; break;
                case "D3": gameBoard[3, 2] = ' '; break;

                case "D5": gameBoard[4, 0] = ' '; break;
                case "D6": gameBoard[4, 1] = ' '; break;
                case "D7": gameBoard[4, 2] = ' '; break;

                case "E3": gameBoard[5, 0] = ' '; break;
                case "E4": gameBoard[5, 1] = ' '; break;
                case "E5": gameBoard[5, 2] = ' '; break;

                case "F2": gameBoard[6, 0] = ' '; break;
                case "F4": gameBoard[6, 1] = ' '; break;
                case "F6": gameBoard[6, 2] = ' '; break;

                case "G1": gameBoard[7, 0] = ' '; break;
                case "G4": gameBoard[7, 1] = ' '; break;
                case "G7": gameBoard[7, 2] = ' '; break;
            }
        }
        public char[,] getBoard()
        {
            return gameBoard;
        }


    }
}
