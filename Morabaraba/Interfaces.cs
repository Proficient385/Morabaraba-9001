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
        List<string> checkNeighbours(string position);
        char[,] getBoard();
        List<string> generatePossibleMoves();
        bool isValidPosition(string position);
        char getPieceAtPos(string position);
        void updateNumberOfCows();
        void updateBoard(string position, char symbol);

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
        void makePlacement(string Position, IBoard board);
        void makeMove(string moveFrom, string moveTo, IBoard board);
        void flyCow(string flyFrom, string flyTo, IBoard board);
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
        string get_GameState();
        void updateGameStat(string state);
        string getcurrentPlayer();
        void swapcurrentPlayer();
        void updateGameStat(IPlayer p1, IPlayer p2);

    }


}

