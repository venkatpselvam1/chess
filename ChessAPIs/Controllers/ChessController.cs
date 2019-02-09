using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ChessAPIs.Game;
using GameComponent;

namespace ChessAPIs.Controllers
{
    public class ChessController : ApiController
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

        [System.Web.Http.HttpPost]
        public string Reset()
        {
            var guid = Guid.NewGuid();
            games = new Game.Game(guid);
            return games.board.GetJson();
        }

        [System.Web.Http.HttpGet]
        public string Hints(int x, int y)
        {
            return games.board.GetHintJson(x, y);
        }

        [System.Web.Http.HttpPost]
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
