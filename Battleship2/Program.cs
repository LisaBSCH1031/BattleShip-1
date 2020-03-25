using System;

namespace Battleship2.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            GameManager gm = new GameManager();
            gm.Run();

        }


    }
}
