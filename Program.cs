using System;
using WarCardGame.models;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'Yes' if you wish to simulate the game.");
            var simulateResponse = Console.ReadLine().ToLower();
            var game = new Game(true ? simulateResponse == "yes" : false);
            game.Start();
        }
    }
}
