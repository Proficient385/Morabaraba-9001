﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{

    public interface IBoard
    {
        void updateMoveToBoard(string tempPlayer, string PositionTo);

        void updateMoveFromBoard(string PositionTo);
        void printBoard(char[,] brd);

        char[,] getBoard();
    }

    public interface IPlayer
    {
        int numberOfCows();
        void AddMills(List<string> mill);
        void RemoveMill(List<string> mill);
        void addPlayedPositions(string position);
        void removePlayedPositions(string position);
        void killCow(string position);
        string currentPlayer();
        bool playerOwnPosition(string position);
        List<string> getPlayedPos();
        List<List<string>> getMills();
        string getState();
        void updateState();
        int getNUmOfPlacedCows();
        void makePlacement(string Position, Board board);
        void makeMove(string moveFrom, string moveTo, Board board);
    }

    public interface ICommandLineInterface
    {

        void printBoard();
        void printPlayerTurn(string currentPlayer);

        void printInvalidKill();
        void invalidMove();
        void printGameState();
    }

    public interface IReferee
    {
        bool IsDraw();
        void play();
        bool Winner(IPlayer player1, IPlayer player2);
        bool isMill(IPlayer player);
    }


}

