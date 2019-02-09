using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public class King : Piece
    {
        public King(Colour colour, Position position, Board board)
        {
            this.Colour = colour;
            this.CurrentPosition = position;
            this.Name = "King";
            this.board = board;
        }
        public override List<Position> ValidMoves()
        {
            var validMoves = new List<Position>();
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X + 1, this.CurrentPosition.Y);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X - 1, this.CurrentPosition.Y);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y + 1);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y - 1);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X + 1, this.CurrentPosition.Y + 1);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X + 1, this.CurrentPosition.Y - 1);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X - 1, this.CurrentPosition.Y + 1);
            AddIfNotOurPiece(validMoves, this.CurrentPosition.X - 1, this.CurrentPosition.Y - 1);
            FilterOutOfBoardMoves(validMoves);
            return validMoves;
        }
    }
}
