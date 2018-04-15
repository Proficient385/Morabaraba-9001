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
        List<string[]> mill_List = new List<string[]>();
        string symbol = "";



        public void AddMills(string[] mill)
        {
            mill_List.Add(mill);
        }

        public string currentplayer()
        {
            
            throw new NotImplementedException();
        }

        public List<List<string>> getMills()
        {
           
            throw new NotImplementedException();
        }

        public List<string> getPlayedPos()
        {
            throw new NotImplementedException();
        }

        public string getState()
        {
            throw new NotImplementedException();
        }

        public int numberOfCows()
        {
            throw new NotImplementedException();
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
