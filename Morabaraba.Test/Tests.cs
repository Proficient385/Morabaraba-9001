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
            IBoard board = new Board();
            char[,] gameBoard = board.getBoard();
            int count = 0;
            for(int i=0;i<8;i++)
            {
                for (int k = 0; k < 3; k++) if (gameBoard[i, k] == ' ') count++;
            }

            Assert.That(count == 24);
        }

        [Test]
        public void CheckMill_Is_Formed()
        {
            IPlayer player1 = new Player("Black");
            IPlayer player2 = new Player("White");
            IReferee referee = new Referee();

            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("A4");
            player1.addPlayedPositions("A7");

            player2.addPlayedPositions("A7");
            player2.addPlayedPositions("B6");
            player2.addPlayedPositions("C5");

            Assert.That(referee.isMill(player1) == true);
            Assert.That(referee.isMill(player2) == true);

        }

        [Test]
        public void CheckMill_Is_Not_Formed_On_Different_Cows_On_SameLine()
        {
            IPlayer player1 = new Player("Black");
            IPlayer player2 = new Player("White");
            IReferee referee = new Referee();

            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("G4");
            player1.addPlayedPositions("A7");

            player2.addPlayedPositions("A4");
            player2.addPlayedPositions("G1");
            player2.addPlayedPositions("G7");

            Assert.That(referee.isMill(player1) == false);
            Assert.That(referee.isMill(player2) == false); 

        }

        [Test]
        public void CheckMill_ConnectedSpaces_ContainingCows_Do_Notform_ALine()
        {
            Player player1 = new Player("Black");
            Player player2 = new Player("White");
            IReferee referee = new Referee();

            player1.addPlayedPositions("D1");
            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("A4");

            player2.addPlayedPositions("A7");
            player2.addPlayedPositions("B6");
            player2.addPlayedPositions("D6");

            Assert.That(referee.isMill(player1) == false);
            Assert.That(referee.isMill(player2) == false);

        }
        [Test]
        public void BlackCowsGivenFirstChance()
        {
            Game game = new Game();
            string currentPlayer = game.getCurrentPlayer();
            Assert.AreEqual("Black", currentPlayer);
        }
        [Test]
        public void CanOnlyMoveToConnectedSpace()
        {

        }
    }
}
