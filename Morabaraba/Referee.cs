using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        private string currentPlayer;
        private List<List<string>> possible_Mills;
        public Referee()
        {
            possible_Mills = generate_possible_Mills();
            currentPlayer = "Black";
        }

        private List<List<string>> generate_possible_Mills()
        {
            List<List<string>> result = new List<List<string>>();
            result.Add(new List<string>() { "A1", "A4", "A7" });
            result.Add(new List<string>() { "B2", "B4", "B6" });
            result.Add(new List<string>() { "C3", "C4", "C5" });
            result.Add(new List<string>() { "D1", "D2", "D3" });
            result.Add(new List<string>() { "D5", "D6", "D7" });
            result.Add(new List<string>() { "E3", "E4", "E5" });
            result.Add(new List<string>() { "E3", "E4", "E5" });
            result.Add(new List<string>() { "F2", "F4", "F6" });
            result.Add(new List<string>() { "G1", "G4", "G6" });
            result.Add(new List<string>() { "A1", "B2", "C3" });
            result.Add(new List<string>() { "A1", "D1", "G1" });
            result.Add(new List<string>() { "A4", "B4", "C4" });
            result.Add(new List<string>() { "A7", "B6", "C5" });
            result.Add(new List<string>() { "A7", "D7", "G7" });
            result.Add(new List<string>() { "B2", "D2", "F2" });
            result.Add(new List<string>() { "B6", "D6", "F6" });
            result.Add(new List<string>() { "C3", "E3", "D3" });
            result.Add(new List<string>() { "C5", "D5", "F6" });
            result.Add(new List<string>() { "E3", "F2", "G1" });
            result.Add(new List<string>() { "E4", "F4", "G4" });
            result.Add(new List<string>() { "E5", "F6", "G7" });

            return result;
        }

        public bool IsDraw()
        {
            throw new NotImplementedException();
        }

        public bool isMill(IPlayer player)
        {
            List<string> playedPos = player.getPlayedPos();
            List<List<string>> mill_List = player.getMills();

            for (int i = 0; i < possible_Mills.Count; i++)
            {
                int count = 0;
                for (int k = 0; k <playedPos.Count; k++)
                {
                    if (possible_Mills[i].Contains(playedPos[k])) count++;
                }

                if (count == 3 && !mill_List.Contains(possible_Mills[i]))
                {
                    player.AddMills(possible_Mills[i]);
                    return true;
                }
            }
            return false;
        }

        public void play()
        {
            throw new NotImplementedException();
        }

        public bool Winner(IPlayer player1, IPlayer player2)
        {
            if (player1.numberOfCows() == 2 || player2.numberOfCows() == 2) return true;
            return false;
        }

        public void swapcurrentPlayer()
        {
            switch (currentPlayer)

            {
                case "Black":
                    currentPlayer = "White";
                    return;
                case "White":
                    currentPlayer = "Black";
                    return;
            }
        }

        public string getcurrentPlayer()
        {
            return currentPlayer;
        }
    }

}
