using System;

namespace Morabaraba
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game game = new Game(new Player("Black"), new Player("White"),new Board(), new Referee());
            game.runGame();
            Console.ReadLine();
        }
    }
}
