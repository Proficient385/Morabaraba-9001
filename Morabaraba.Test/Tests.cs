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
        public void Cow_in_a_mill_when_nonMill_cows_exist_cannot_be_shot()
        {
            IPlayer player1 = new Player("Black");
            IPlayer player2 = new Player("White");
            Game game = new Game();
            IBoard board = new Board();

            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("A4");
            player1.addPlayedPositions("A7");
            player1.AddMills(new List<string> { "A1", "A4", "A7" });
            player1.addPlayedPositions("B2");

            board.updateMoveToBoard("Black", "A1");
            board.updateMoveToBoard("Black", "A4");
            board.updateMoveToBoard("Black", "A7");
            board.updateMoveToBoard("Black", "B2");

            player2.addPlayedPositions("D7");
            player2.addPlayedPositions("D6");
            player2.addPlayedPositions("D5");
            player2.AddMills(new List<string> { "D7", "D6", "D5" });
            player2.addPlayedPositions("E5");

            board.updateMoveToBoard("White", "D7");
            board.updateMoveToBoard("White", "D6");
            board.updateMoveToBoard("White", "D5");
            board.updateMoveToBoard("White", "E5");

            game.eliminate(player1,board, "A1");
            game.eliminate(player2,board, "D5");

            Assert.That(player1.getPlayedPos().Contains("A1")==true);
            Assert.That(player2.getPlayedPos().Contains("D5") == true);
        }

        [Test]
        public void A_cow_in_a_mill_when_all_cows_are_in_mills_can_be_shot()
        {
            IPlayer player1 = new Player("Black");
            IPlayer player2 = new Player("White");
            Game game = new Game();
            IBoard board = new Board();

            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("A4");
            player1.addPlayedPositions("A7");
            player1.AddMills(new List<string> { "A1", "A4", "A7" });
            
            board.updateMoveToBoard("Black", "A1");
            board.updateMoveToBoard("Black", "A4");
            board.updateMoveToBoard("Black", "A7");
            
            player2.addPlayedPositions("D7");
            player2.addPlayedPositions("D6");
            player2.addPlayedPositions("D5");
            player2.AddMills(new List<string> { "D7", "D6", "D5" });
            
            board.updateMoveToBoard("White", "D7");
            board.updateMoveToBoard("White", "D6");
            board.updateMoveToBoard("White", "D5");
            
            game.eliminate(player1, board, "A1");
            game.eliminate(player2, board, "D5");

            Assert.That(player1.getPlayedPos().Contains("A1") == false);
            Assert.That(player2.getPlayedPos().Contains("D5") == false);
        }

        [Test]
        public void A_player_cannot_shoot_their_own_cows()
        {
            IPlayer player1 = new Player("Black");
            IPlayer player2 = new Player("White");
            Game game = new Game();
            IBoard board = new Board();

            player1.addPlayedPositions("A1");
            player1.addPlayedPositions("A4");
            player1.addPlayedPositions("A7");
            player1.AddMills(new List<string> { "A1", "A4", "A7" });

            board.updateMoveToBoard("Black", "A1");
            board.updateMoveToBoard("Black", "A4");
            board.updateMoveToBoard("Black", "A7");

            player2.addPlayedPositions("D7");
            player2.addPlayedPositions("D6");
            player2.addPlayedPositions("D5");
            player2.AddMills(new List<string> { "D7", "D6", "D5" });

            board.updateMoveToBoard("White", "D7");
            board.updateMoveToBoard("White", "D6");
            board.updateMoveToBoard("White", "D5");

            game.eliminate(player1, board, "D5");
            game.eliminate(player2, board, "A1");

            Assert.That(player1.getPlayedPos().Contains("A1") == true);
            Assert.That(player2.getPlayedPos().Contains("D5") == true);
        }
    }
}
