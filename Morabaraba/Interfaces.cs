using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{

    public interface IBoard
    {
        void updateBoard();
        void printBoard();
    }

    public interface IPlayer
    {
        int numberOfCows();
        void AddMills(List<string> mill);
        void RemoveMill();
        void updatePlayed();
        string currentplayer();
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
        bool isMill();
    }


}

