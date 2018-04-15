using NUnit.Framework;
using System;
using NSubstitute;
using System.Linq;
using System.Collections.Generic;

namespace Morabaraba.Test
{   
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CheckEmptyBoard()
        {
            Board board = new Board();
            char[,] gameBoard = board.getBoard();
            int count = 0;
            for(int i=0;i<8;i++)
            {
                for (int k = 0; k < 3; k++) if (gameBoard[i, k] == ' ') count++;
            }

            Assert.That(count == 24);
        }
        [Test]
        
    }
}
