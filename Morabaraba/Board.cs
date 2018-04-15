using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    class Board : IBoard
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
        public void printBoard()
        {
            throw new NotImplementedException();
        }

        public void updateBoard()
        {
            throw new NotImplementedException();
        }
    }
}
