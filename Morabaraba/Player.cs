﻿using System;
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
        private int placementCount;

        public Player(string symbol)
        {
            this.symbol = symbol;
            cowsLeft = 12;
            state = "Placing";
            playedPos = new List<string>();
            mill_List = new List<List<string>>();
            placementCount = 0;
        }


        public void AddMills(List<string> mill)
        {
            mill_List.Add(mill);
        }

        public string currentPlayer()
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
            if (cowsLeft == 3)
            {
                state = "Flying";
                return;
            }
            else if (playedPos.Count == cowsLeft && cowsLeft != 3 && playedPos.Count != 3)
            {
                state = "Moving";
            }
        }

        public bool playerOwnPosition(string position)
        {
            return playedPos.Contains(position);
        }

        public void killCow(string position)
        {
            updateState();
            removePlayedPositions(position);
            cowsLeft--;
        }
        
        public void makePlacement(string Position, IBoard board)

        {
            updateState();

            if ( placementCount < 12)
            {
                if (state == "Placing" && placementCount < 12 && board.getPieceAtPos(Position) == ' ')
                {
                    placementCount++;
                    board.updateMoveToBoard(symbol, Position);
                    board.updateNumberOfCows();

                    addPlayedPositions(Position);
                    updateState();
                    
                }
            }

        }

        public void makeMove(string moveFrom, string moveTo, IBoard board)
        {

            updateState();

            if (state == "Moving" && board.getPieceAtPos(moveTo) == ' ' && board.getPieceAtPos(moveFrom) != ' ')
            {
                board.updateMoveFromBoard(moveFrom);
                board.updateMoveToBoard(symbol, moveTo);

                addPlayedPositions(moveTo);
                removePlayedPositions(moveFrom);

            }

        }

        public void flyCow(string flyFrom, string flyTo, IBoard board)
        {
            updateState();

            if (state == "Flying" && board.getPieceAtPos(flyTo) == ' ' && board.getPieceAtPos(flyFrom) != ' ')
            {
                board.updateMoveFromBoard(flyFrom);
                board.updateMoveToBoard(symbol, flyTo);

                addPlayedPositions(flyTo);
                removePlayedPositions(flyFrom);

            }
        }
        public int getNUmOfPlacedCows()
        {
            return placementCount;
        }
    }
}
