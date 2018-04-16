using System;
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
        void Winner();
        bool isMill(IPlayer player);
    }


}

