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
            Console.Clear();
            Console.WriteLine("     Morabaraba\n");
            Console.WriteLine("   1   2  3         4       5  6   7 ");
            Console.WriteLine("A  {0}---------------{1}-------------- {2}", brd[0, 0], brd[0, 1], brd[0, 2]);
            Console.WriteLine("   | \\              |             / |");
            Console.WriteLine("   |  \\             |            /  |");
            Console.WriteLine("B  |   {0}------------{1}-----------{2}   |", brd[1, 0], brd[1, 1], brd[1, 2]);
            Console.WriteLine("   |   |\\           |          /|   |");
            Console.WriteLine("   |   | \\          |         / |   |");
            Console.WriteLine("C  |   |  {0}---------{1}--------{2}  |   |", brd[2, 0], brd[2, 1], brd[2, 2]);
            Console.WriteLine("   |   |  |                  |  |   |");
            Console.WriteLine("   |   |  |                  |  |   |");
            Console.WriteLine("D  {0}---{1}--{2}                  {3}--{4}---{5} ", brd[3, 0], brd[3, 1], brd[3, 2], brd[4, 0], brd[4, 1], brd[4, 2]);
            Console.WriteLine("   |   |  |                  |  |   |");
            Console.WriteLine("   |   |  |                  |  |   |");
            Console.WriteLine("E  |   |  {0}---------{1}--------{2}  |   |", brd[5, 0], brd[5, 1], brd[5, 2]);
            Console.WriteLine("   |   | /          |         \\ |   |");
            Console.WriteLine("   |   |/           |          \\|   |");
            Console.WriteLine("F  |   {0}------------{1}-----------{2}   |", brd[6, 0], brd[6, 1], brd[6, 2]);
            Console.WriteLine("   |  /             |            \\  |");
            Console.WriteLine("   | /              |             \\ |");
            Console.WriteLine("G  {0}---------------{1}-------------- {2}", brd[7, 0], brd[7, 1], brd[7, 2]);
            Console.WriteLine("\n\n");
        }

        public void updateBoard(string position, char symbol)
        {
            switch (position)
            {
                case "A1": gameBoard[0, 0] = symbol;
                    break;
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
        public void updateMoveToBoard(string player, string PositionTo)
        {
            char symbol = ' ';
            if(player == "Black")
            {
                symbol = 'B';
            }
            else
            {
                symbol = 'W';
            }
            updateBoard(PositionTo, symbol);
        }

        public void updateMoveFromBoard(string PositionTo)
        {
            updateBoard(PositionTo, ' ');
        }
        public int[] fromPositionToIndex(string position)
        {
            switch (position)
            {
                case "A1": return new int[] { 0, 0 };
                case "A4": return new int[] { 0, 1 };
                case "A7": return new int[] { 0, 2 };

                case "B2": return new int[] { 1, 0 };
                case "B4": return new int[] { 1, 1 };
                case "B6": return new int[] { 1, 2 };

                case "C3": return new int[] { 2, 0 };
                case "C4": return new int[] { 2, 1 };
                case "C5": return new int[] { 2, 2 };

                case "D1": return new int[] { 3, 0 };
                case "D2": return new int[] { 3, 1 };
                case "D3": return new int[] { 3, 2 };

                case "D5": return new int[] { 4, 0 };
                case "D6": return new int[] { 4, 1 };
                case "D7": return new int[] { 4, 2 };

                case "E3": return new int[] { 5, 0 };
                case "E4": return new int[] { 5, 1 };
                case "E5": return new int[] { 5, 2 };

                case "F2": return new int[] { 6, 0 };
                case "F4": return new int[] { 6, 1 };
                case "F6": return new int[] { 6, 2 };

                case "G1": return new int[] { 7, 0 };
                case "G4": return new int[] { 7, 1 };
                case "G7": return new int[] { 7, 2 };
            }
            return null;
        }
        public char[,] getBoard()
        {
            return gameBoard;
        }


    }
}
