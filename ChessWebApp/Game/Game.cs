using GameComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAPIs.Game
{
    public class Game
    {
        public Board board;
        public Player player1;
        public Player player2;
        public Guid id { get; private set; }
        public Game(Guid id)
        {
            this.id = id;
            board = new Board();
            player1 = new Player(board, "player1", GameComponent.Enum.Colour.White);
            player2 = new Player(board, "player2", GameComponent.Enum.Colour.Black);
        }
    }
}