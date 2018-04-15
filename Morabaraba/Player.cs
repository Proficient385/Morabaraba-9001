using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    class Player : IPlayer
    {
        int cowsLeft = 12;
        string state = "Placing";
        List<string> playedPos = new List<string>();
        List<List<string>> mill_List = new List<List<string>>();
        string symbol = "";



        public void AddMills(List<string> mill)
        {
            mill_List.Add(mill);
        }

        public string currentplayer()
        {
            
            throw new NotImplementedException();
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

        public void RemoveMill()
        {
            throw new NotImplementedException();
        }

        public void updatePlayed()
        {
            throw new NotImplementedException();
        }

        public void updateState()
        {
            throw new NotImplementedException();
        }
    }
}
