using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        private int cowsLeft;
        private string state;
        private List<string> playedPos;
        private List<List<string>> mill_List;
        private string symbol;

        public Player(string symbol)
        {
            this.symbol = symbol;
            cowsLeft = 12;
            state = "Placing";
            playedPos = new List<string>();
            mill_List = new List<List<string>>();
        }


        public void AddMills(List<string> mill)
        {
            mill_List.Add(mill);
        }

        public string currentplayer()
        {

            return symbol;
        }

        public List<List<string>> getMills()
        {

            return mill_List;
        }

        public List<string> getPlayedPos()
        {
            return playedPos;
        }

        public string getState()
        {
            return state;
        }

        public int numberOfCows()
        {
            return cowsLeft;
        }

        public void RemoveMill(List<string> mill)
        {
            mill_List.Remove(mill);
        }

        public void addPlayedPositions(string position)
        {
            playedPos.Add(position);
        }

        public void removePlayedPositions(string position)
        {
            playedPos.Remove(position);
        }

        public void updateState()
        {
            if (playedPos.Count == cowsLeft)
            {
                state = "Moving"; 
            }
            if(cowsLeft == 3)
            {
               state = "Flying";
            }
        }

        public bool playerOwnPosition(string position)
        {
            return playedPos.Contains(position);
        }
    }
}
