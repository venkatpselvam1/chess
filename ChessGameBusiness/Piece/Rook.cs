using GameComponent.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Piece
{
    public class Rook : Piece
    {
        public Rook(Colour colour, Position position, Board board)
        {
            this.Colour = colour;
            this.CurrentPosition = position;
            this.Name = "Rook";
            this.board = board;
        }
        public override List<Position> ValidMoves()
        {
            var validMoves = new List<Position>();
            bool isFrontBlocked = false;
            bool isBackBlocked = false;
            bool isRightBlocked = false;
            bool isLeftBlocked = false;
            for (int i = 1; i < 8; i++)
            {
                if (!isFrontBlocked)
                {
                    isFrontBlocked = isFrontBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X + i, this.CurrentPosition.Y);
                }
                if (!isBackBlocked)
                {
                    isBackBlocked = isBackBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X - i, this.CurrentPosition.Y);
                }
                if (!isRightBlocked)
                {
                    isRightBlocked = isRightBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y + i);
                }
                if (!isLeftBlocked)
                {
                    isLeftBlocked = isLeftBlocked || AddIfNotOurPiece(validMoves, this.CurrentPosition.X, this.CurrentPosition.Y - i);
                }
            }

            FilterOutOfBoardMoves(validMoves);
            return validMoves;
        }
    }
}
