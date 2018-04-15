﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        private List<string> possibleMoves;
        private string currentPlayer;
        Player player;
        public Game()
        {
            currentPlayer = "Black";
            possibleMoves = generatePossibleMoves();
            player = new Player();
        }
        public string getCurrentPlayer()
        {
            return currentPlayer;
        }
        
        public void makeMove()
        {
            
        }
        List<string> generatePossibleMoves()
        {
            return new List<string> { "A1","A4","A7",
                                      "B2","B4","B6",
                                      "C3","C4","C5",
                                      "D1","D2","D3","D5","D6","D7",
                                      "E3","E4","E5",
                                      "F2","F4","F6",
                                      "G1","G4","G7"};
        }
    }
    
}
