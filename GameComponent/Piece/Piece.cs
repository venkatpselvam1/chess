using GameComponent.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public abstract class Piece
    {
        protected Board board { get; set;}

        [JsonConverter(typeof(StringEnumConverter))]
        public Colour Colour { get; protected set; }
        public Position CurrentPosition { get; protected set; }
        public string Name { get; protected set; }
        public abstract List<Position> ValidMoves();
        public virtual void MakeMove(int x, int y)
        {
            this.CurrentPosition.X = x;
            this.CurrentPosition.Y = y;
        }

        public void FilterOutOfBoardMoves(List<Position> positions)
        {
            #region removing out of box moves
            positions.RemoveAll(x => (x.X > 8 || x.Y > 8 || x.X < 1 || x.Y < 1));
            #endregion
        }
        public bool AddIfNotOurPiece(List<Position> validMoves, int x, int y)
        {
            if (!board.IsAnyPieceAvailable(x, y, this.Colour))
            {
                validMoves.Add(new Position(x, y));
            }

            return board.IsAnyPieceAvailable(x, y);
        }
    }
}
