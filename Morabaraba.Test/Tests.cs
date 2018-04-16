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
            for (int i = 0; i < 8; i++)
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
            Game game = new Game();

            game.makeMove("A1", "A4");
            game.makeMove("F6", "F4");
            game.makeMove("D1", "F4");
            Assert.AreEqual(true, game.checkNeighbours("A1").Contains("A4"));
            Assert.AreEqual(true, game.checkNeighbours("F6").Contains("F4"));
            Assert.AreEqual(false, game.checkNeighbours("D1").Contains("F4"));
        }


        [Test]

        public void A_maximum_of_12_placements_per_player_are_allowed()
        {
            //Sakhele

            Game myGame = new Game();

            myGame.makePlacement("A1");
            myGame.makePlacement("A4");
            myGame.makePlacement("A7");
            myGame.makePlacement("B2");

            myGame.makePlacement("B4");
            myGame.makePlacement("B6");
            myGame.makePlacement("C3");
            myGame.makePlacement("C4");

            myGame.makePlacement("C5");
            myGame.makePlacement("D1");
            myGame.makePlacement("D2");
            myGame.makePlacement("D3");

            myGame.makePlacement("D5");
            myGame.makePlacement("D6");

            Assert.That(myGame.getNUmOfPlacedBlackCows() == 12);
            Assert.That(myGame.getNUmOfPlacedWhiteCows() == 0);
        }

        [Test]

        public void Cows_cannot_be_moved_during_placement()
        {
            //Sakhele

            Game myGame = new Game();

            myGame.makePlacement("A1");
            myGame.makePlacement("A4");
            myGame.makePlacement("A7");
            myGame.makePlacement("B2");

            myGame.makeMove("A1", "D1");

            Assert.That(myGame.getLastMove()[0] == "");
            Assert.That(myGame.getLastMove()[1] == "");
        }

        [Test]
        public void Cows_can_only_be_placed_on_empty_spaces()
        {
            //Sakhele

            Game myGame = new Game();

            myGame.makePlacement("A1");
            myGame.swapCurrentPlayer();
            myGame.makePlacement("A1");
            myGame.makePlacement("A4");

            Assert.That(myGame.getPieceAtPos("A1") == 'b');
            Assert.That(myGame.getPieceAtPos("A4") == 'w');

        }
       
        
        [Test]
        public void Can_Only_Move_To_An_EmptySpace()
        {
            //Sakhele

            Game myGame = new Game();

            myGame.makePlacement("A1");
            myGame.makePlacement("A4");
            myGame.makePlacement("A7");
            myGame.makePlacement("B2");

            myGame.makePlacement("B4");
            myGame.makePlacement("B6");
            myGame.makePlacement("C3");
            myGame.makePlacement("C4");

            myGame.makePlacement("C5");
            myGame.makePlacement("D1");
            myGame.makePlacement("D2");
            myGame.makePlacement("D3");

            myGame.makeMove("D1", "G1");
            myGame.swapCurrentPlayer();

            myGame.makePlacement("G4");
            myGame.swapCurrentPlayer();

            myGame.makeMove("G1", "G4");

            Assert.That(myGame.getPieceAtPos("G1") == 'b');
            Assert.That(myGame.getPieceAtPos("G4") == 'w');

        }

        [Test]

        public void Moving_does_not_increase_or_decrease_the_number_of_cows_on_the_board()
        {
            //Sakhele

            Game myGame = new Game();

            myGame.makePlacement("A1");
            myGame.makePlacement("A4");
            myGame.makePlacement("A7");
            myGame.makePlacement("B2");

            myGame.makePlacement("B4");
            myGame.makePlacement("B6");
            myGame.makePlacement("C3");
            myGame.makePlacement("C4");

            myGame.makePlacement("C5");
            myGame.makePlacement("D1");
            myGame.makePlacement("D2");
            myGame.makePlacement("D3");

            myGame.makeMove("D1", "G1");
            myGame.makeMove("G1", "G4");

            Assert.That(myGame.get_Number_of_cows_in_board() == 12);
            Assert.That(myGame.getPieceAtPos("G4") == 'b');
        }


    }    
}

