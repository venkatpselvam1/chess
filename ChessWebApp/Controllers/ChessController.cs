using System;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPIs.Controllers
{
    public class ChessController : Controller
    {
        private static Game.Game games;
        static ChessController()
        {
            var guid = Guid.NewGuid();
            games= new Game.Game(guid);
        }
        public string Get()
        {
            return games.board.GetJson();
        }

        [HttpPost]
        public string Reset()
        {
            var guid = Guid.NewGuid();
            games = new Game.Game(guid);
            return games.board.GetJson();
        }

        [HttpGet]
        public string Hints(int x, int y)
        {
            return games.board.GetHintJson(x, y);
        }

        [HttpPost]
        public bool PlayGame(int p, int x, int y, int x1, int y1)
        {
            if (p == 0)
            {
                games.player1.Play(x, y, x1, y1);
            }
            else
            {
                games.player2.Play(x, y, x1, y1);
            }

            return games.board.IsGameOver();
        }
    }
}
