using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent
{
    public class Player
    {
        private Board board { get; }
        private string Name { get; }
        private Colour colour { get; set; }
        public Player(Board board, string name, Colour colour)
        {
            this.colour = colour;
            this.board = board;
            this.Name = name;
        }

        public bool Play(int x1, int y1, int x2, int y2)
        {
            return board.MakeMove(x1, y1, x2, y2);
        }

        public void Play()
        {
            if (this.colour == board.CurrenTurn)
            {
                while (true)
                {
                    Console.WriteLine($"{Name} - {colour} have to make move");
                    Console.WriteLine("Enter the piece's X:");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the piece's Y:");
                    int y1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter where to move X:");
                    int x2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter where to move Y:");
                    int y2 = int.Parse(Console.ReadLine());
                    bool isValidMove = false;
                    try
                    {
                        isValidMove = board.MakeMove(x1, y1, x2, y2);
                    }
                    catch (Exception)
                    {

                    }
                    
                    Console.WriteLine(isValidMove ? $"{Name} move the piece" : $"{Name} made an invalid move");
                    if (isValidMove)
                    {
                        break;
                    }
                }
            }
        }
    }
}
