using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        private List<string> possibleMoves;
        private string currentPlayer;

        Board brd;
        Player player;
        public Game()
        {
            currentPlayer = "Black";
            possibleMoves = generatePossibleMoves();
            brd = new Board();
            player = new Player("Black");
        }
        public string getCurrentPlayer()
        {
            return currentPlayer;
        }
        private List<string> checkNeighbours(string position)
        {
            switch (position)
            {
                case "A1": return new List<string> { "D1", "B2", "A4" };
                case "A4": return new List<string> { "A1", "A7", "B4" };
                case "A7": return new List<string> { "A4", "B6", "D7" };

                case "B2": return new List<string> { "A1", "C3", "B4", "D2" };
                case "B4": return new List<string> { "B2", "A4", "D6", "C4"};
                case "B6": return new List<string> { "A7", "B4", "D7", "C5" };

                case "C3": return new List<string> { "B2", "C4", "D3" };
                case "C4": return new List<string> { "C3", "B4", "C5" };
                case "C5": return new List<string> { "C4", "B6", "D5" };

                case "D1": return new List<string> { "A1", "D2", "G1" };
                case "D2": return new List<string> { "D1", "B2", "D3", "F2" };
                case "D3": return new List<string> { "C3","D2","E3" };

                case "D5": return new List<string> { "C5", "D6", "E5"};
                case "D6": return new List<string> { "D5", "B6", "D7", "F6" };
                case "D7": return new List<string> { "A7","D6","G7" };

                case "E3": return new List<string> { "D3", "E4", "F2" };
                case "E4": return new List<string> { "F4", "E3", "E5" };
                case "E5": return new List<string> { "D5","E4","F6" };

                case "F2": return new List<string> { "G1", "E3", "F4", "D2" };
                case "F4": return new List<string> { "E4", "F6", "G4", "F2" };
                case "F5": return new List<string> { "G7","D6","F4","E5" };

                case "G1": return new List<string> { "G1", "E3", "F4", "D2" };
                case "G4": return new List<string> { "E4", "F6", "G4", "F2" };
                case "G7": return new List<string> { "G7", "D6", "F4", "E5" };
            }
           
            return null;
        }
        public void makeMove(Board gameBoard, string fromPos, string toPos) 
        {
            if (player.getState() == "Placing")
            {
                gameBoard.updateMoveToBoard(currentPlayer, toPos);
            }

            if(player.getState() == "Moving" || checkNeighbours(fromPos).Contains(toPos) )
            {
                gameBoard.updateMoveFromBoard(fromPos);
                gameBoard.updateMoveToBoard(currentPlayer, toPos);
            }
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
