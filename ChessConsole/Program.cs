using GameComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var player1 = new Player(board, "venkat", GameComponent.Enum.Colour.Black);
            var player2 = new Player(board, "arun", GameComponent.Enum.Colour.White);
            while (true)
            {
                if (!board.IsGameOver())
                {
                    player1.Play();
                }
                if (!board.IsGameOver())
                {
                    player2.Play();
                }
            }
        }
    }
}
