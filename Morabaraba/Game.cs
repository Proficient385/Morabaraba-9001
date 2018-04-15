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

        void swapCurrentPlayer(Player tempPlayer)
        {
            switch (tempPlayer.currentplayer())
            {
                case "Black": currentPlayer = "White";
                    return;
                case "White": currentPlayer = "Black";
                    return;
            }
        }

    }
    
}
