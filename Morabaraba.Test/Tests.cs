using NUnit.Framework;
using System;

namespace Morabaraba.Test
{   
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CheckEmptyBoard()
        {

        }
        [Test]
        public void BlackCowsStart()
        {
            Game game = new Game();
            string startingPlayer = game.getCurrentPlayer();
            Assert.That(startingPlayer == "Black");
        }
        [Test]
        public void OnlyBePlacedOnEmptySpaces()
        {

        }
    }
}
