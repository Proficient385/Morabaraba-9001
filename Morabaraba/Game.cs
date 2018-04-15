using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        private string currentPlayer;
        public Game()
        {
            currentPlayer = "Black";
        }
        public string getCurrentPlayer()
        {
            return currentPlayer;
        }


    }
    
}
